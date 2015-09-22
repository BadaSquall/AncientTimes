using AncientTimes.Assets.Scripts.Utilities;
using UnityEngine;
using System.Collections;
using AncientTimes.Assets.Scripts;

namespace AncientTimes.Assets.Scripts.GameSystem
{
    public class MapLoader : GameSystemObject
    {
        #region Properties

        private static MapLoader instance;

        public static MapLoader Instance
        {
            get
            {
                instance = instance ?? new MapLoader();
                return instance;
            }
        }

        #endregion Properties

        #region Constructor

        private MapLoader() { }

        #endregion Constructor

        #region Methods

        public static void Load(string mapName, string EndWarp)
        {
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            Instance.RaiseDestroy(GameObject.FindGameObjectWithTag("Places"));
            Instance.RaiseInstantiate(Resources.Load("Maps/" + mapName, typeof(GameObject)));
            Player.transform.position = GameObject.Find(EndWarp).transform.position; 
            GameVariables.Update("CurrentMap", mapName);
        }

        public static void Load(string mapName)
        {
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            Instance.RaiseDestroy(GameObject.FindGameObjectWithTag("Places"));
            Instance.RaiseInstantiate(Resources.Load("Maps/" + mapName, typeof(GameObject)));
            GameVariables.Update("CurrentMap", mapName);
        }
        #endregion Methods
    }
}