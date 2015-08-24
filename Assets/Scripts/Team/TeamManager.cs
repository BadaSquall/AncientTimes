using System.Collections.Generic;
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

        private Pokemon firstPokemon;

        private List<Pokemon> Pokemons;
        
        void Start ()
        {
            if (ScenesCommunicator.IsBattleTeam)
                teamType = TeamType.Battle;
            else teamType = TeamType.Menu;

            Pokemons = (List<Pokemon>) GameVariables.Get("PlayerTeam", new List<Pokemon>());
            firstPokemon = ScenesCommunicator.PokemonInBattle;

            Pokemons.Remove(firstPokemon);
            Pokemons.Insert(0, firstPokemon);

        }
	
        
        void Update () {
	
        }
    }
}
