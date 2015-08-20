using AncientTimes.Assets.Scripts.Utilities;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Team
{
    public class TeamManager : MonoBehaviour {

        public enum TeamType
        {
            Battle,
            Menu
        }

        private TeamType teamType;

        //lista squadra
        
        void Start ()
        {
            if (ScenesCommunicator.IsBattleTeam)
                teamType = TeamType.Battle;
            else teamType = TeamType.Menu;

            
        }
	
        
        void Update () {
	
        }
    }
}
