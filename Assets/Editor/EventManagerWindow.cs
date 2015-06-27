﻿using UnityEditor;
using System.Collections.Generic;
using UnityEngine;
using AncientTimes.Assets.Scripts.Events;
using System.Reflection;
using System;
using System.Linq;
using AncientTimes.Assets.Scripts.Events.Actions;
using System.IO;

public class EventManagerWindow : EditorWindow
{
    #region Properties

    private int typeIndex;
    private List<EventLayoutManagerBase> eventManagers;
    private GameObject previousGameObject;

    #endregion Properties

    #region Constructors

    public EventManagerWindow()
    {
        eventManagers = new List<EventLayoutManagerBase>();
        eventManagers.Add(new ChangeSwitchLayoutManager());
        eventManagers.Add(new ShowDialogueLayoutManager());
    }

    #endregion Constructors

    #region Methods

    [MenuItem("Window/Event Manager")]
    public static void ShowWindow() { EditorWindow.GetWindow(typeof(EventManagerWindow)); }

    void OnEnable() { title = "Event Manager"; }

    void OnGUI()
    {
        if (!Selection.activeGameObject) return;

        bool gameObjectChanged = false;

        if (Selection.activeGameObject != previousGameObject)
        {
            gameObjectChanged = true;

            foreach (var manager in eventManagers) manager.FreeMemory();

            previousGameObject = Selection.activeGameObject;
        }

        var currentEvent = Selection.activeGameObject.GetComponent<GameEvent>();

        if (!currentEvent)
        {
            if (GUILayout.Button("Create event"))
            {
                Selection.activeGameObject.AddComponent(typeof(GameEvent));
                currentEvent = Selection.activeGameObject.GetComponent<GameEvent>();
            }
            else return;
        };

        var evt = currentEvent.Event;

        if (gameObjectChanged)
        {
            var currentScenePath = UnityEditor.EditorApplication.currentScene.Split('/');
            currentScenePath[currentScenePath.Length - 1] = currentScenePath[currentScenePath.Length - 1].Remove(currentScenePath[currentScenePath.Length - 1].IndexOf(".unity"));
            var filePath = @"Assets/Events/" + currentScenePath[currentScenePath.Length - 1] + "/" + Selection.activeGameObject.name + ".xml";
            
            if (File.Exists(filePath))
            {
                currentEvent.Event = (SerializableGameEvent)AncientTimes.Assets.Scripts.Utilities.XMLDeserializer.Deserialize(typeof(SerializableGameEvent), filePath);
                evt = currentEvent.Event;
            }
        }

        GUILayout.Label("Containers", EditorStyles.boldLabel);
        
        for (var containerIndex = 0; containerIndex < evt.Containers.Count; containerIndex++)
        {
            var container = evt.Containers[containerIndex];

            var showContainer = currentEvent.ContainersVisibles[container] = EditorGUILayout.Foldout(currentEvent.ContainersVisibles[container], "Container n° " + containerIndex + ":");

            var selectablesTypes = new List<Type>();

            if (showContainer)
            {
                container.Condition = EditorGUILayout.TextField("   Condition:", container.Condition);
                GUILayout.Label("   Actions", EditorStyles.boldLabel);

                for (var actionIndex = 0; actionIndex < container.Actions.Count; actionIndex++)
                {
                    var action = container.Actions[actionIndex];
                    var showAction = currentEvent.ActionsVisibles[container][action] = EditorGUILayout.Foldout(currentEvent.ActionsVisibles[container][action], "Action n° " + actionIndex + ":");

                    if (showAction)
                    {
                        foreach (var manager in eventManagers)
                        {
                            var actionType = action.GetType();
                            if (manager.EventType == actionType)
                                manager.OnGUI(action);
                        }
                    }
                }

                foreach (var type in Assembly.GetAssembly(typeof(ActionBase)).GetTypes().Where(t => string.Equals(t.Namespace, "AncientTimes.Assets.Scripts.Events.Actions", StringComparison.Ordinal)).ToArray())
                    selectablesTypes.Add(type);

                selectablesTypes.Remove(selectablesTypes.Where(x => x.Name == "ActionBase").FirstOrDefault());

                var selectable = new List<string>();
                foreach (var type in selectablesTypes)
                    selectable.Add(type.Name);

                typeIndex = EditorGUILayout.Popup(typeIndex, selectable.ToArray());
            }

            if (GUILayout.Button("Add action"))
            {
                var actionInstantiated = Activator.CreateInstance(selectablesTypes[typeIndex]);

                container.Actions.Add(actionInstantiated as ActionBase);
            }
        }

        if (GUILayout.Button("Add container")) evt.Containers.Add(new Container());
        if (GUILayout.Button("Save"))
        {
            var currentScenePath = EditorApplication.currentScene.Split('/');
            currentScenePath[currentScenePath.Length - 1] = currentScenePath[currentScenePath.Length - 1].Remove(currentScenePath[currentScenePath.Length - 1].IndexOf(".unity"));
            AncientTimes.Assets.Scripts.Utilities.XMLSerializer.Serialize(evt, @"Assets/Events/" + currentScenePath[currentScenePath.Length - 1] + "/",
               Selection.activeGameObject.name + ".xml");
        }
    }

    void OnInspectorUpdate() { Repaint(); }

    #endregion Methods
}