using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AncientTimes.Assets.Scripts.WildPokemon
{
    public class WildPokemonMap
    {
        #region Properties

        public int percentageAppearance;
        public List<WildPokemon> tallGrass;
        public List<WildPokemon> cave;
        public List<WildPokemon> sea;
        public List<WildPokemon> rockSmash;
        public List<WildPokemon> fishing; 

        #endregion Properties

        #region Constructor

        public WildPokemonMap()
        {
            tallGrass = new List<WildPokemon>();
            cave = new List<WildPokemon>();
            sea = new List<WildPokemon>();
            rockSmash = new List<WildPokemon>();
            fishing = new List<WildPokemon>();
        }

        #endregion Constructor
    }
}