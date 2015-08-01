using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Random = UnityEngine.Random;

namespace AncientTimes.Assets.Scripts.WildPokemon
{
    public class WildPokemon
    {
        #region Properties

        public string pokemonName;
        public int levelMin;
        public int levelMax;
        public int level;

        #endregion Properties

        #region Constructor

        public WildPokemon()
        {
        }

        public WildPokemon(List<WildPokemon> listOfPokemons)
        {
            int pokemonSelected = UnityEngine.Random.Range(1, listOfPokemons.Count);
            this.pokemonName = listOfPokemons[pokemonSelected].pokemonName.ToString();
            this.level = Random.Range(listOfPokemons[pokemonSelected].levelMin,
                listOfPokemons[pokemonSelected].levelMax);
        }

        #endregion Constructor
    }
}