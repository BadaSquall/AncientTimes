using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GUISizer
{
    #region Properties

    public static float WIDTH = 1280;
    public static float HEIGHT = 720;

    static List<Matrix4x4> stack = new List<Matrix4x4>();

    #endregion Properties

    #region Methods

    /// <summary>
    /// Begins the resize of the GUI.
    /// </summary>
    static public void BeginGUI()
    {
        stack.Add(GUI.matrix);
        Matrix4x4 m = new Matrix4x4();
        float scale = 1f;

        if ((float)Screen.width / (float)Screen.height < (WIDTH / HEIGHT)) scale = (Screen.width / WIDTH);
        else scale = (Screen.height / HEIGHT);

        m.SetTRS(Vector3.zero, Quaternion.identity, Vector3.one * scale);
        GUI.matrix *= m;
    }

    /// <summary>
    /// Ends the GUI resize.
    /// </summary>
    static public void EndGUI()
    {
        GUI.matrix = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);
    }

    #endregion Methods
}