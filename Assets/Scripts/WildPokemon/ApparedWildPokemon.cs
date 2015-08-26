using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AncientTimes.Assets.Scripts.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AncientTimes.Assets.Scripts.WildPokemon
{

    public class ApparedWildPokemon : MonoBehaviour
    {
        #region Properties

        private bool isInside;
        private WildPokemonMap mapReader;
        //private WildPokemon wildPokemonSelected;
        private float timeToAppared = 0.0F;
        private float TimeToApparedRate = 1.5F;

        #endregion Properties

        #region Methods

        void Start()
        {
            mapReader = (WildPokemonMap)XMLDeserializer.Deserialize(typeof(WildPokemonMap), 
                @"Assets/WildPokemonMap/" + GameVariables.Get("CurrentMap", "Isola") + ".xml");
        }

        void Update()
        {
            if (isInside)
            {
                if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) ||
                    Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || 
                    Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && Time.time > timeToAppared)
                {
                    timeToAppared = Time.time + TimeToApparedRate;
                    if (Random.Range(1, 100) < mapReader.percentageAppearance)
                    {
                        try
                        {
                            //wildPokemonSelected = GetWildPokemon(gameObject.tag);

                            //TODO: add a interface to create an Pokemon Object
                            // Pokemon p = new Pokemon(wildPokemonSelected.pokemonName, wildPokemonSelected.level);

                            //TODO: add an interface to Run a Pokèmon Battle
                            // Battle.GoBattle (p);
                        }
                        catch
                        {
                            Debug.Log("tag Name of field is not insert correctly");
                            throw;
                        } 
                    }
                }
            }

        }

        WildPokemon GetWildPokemon(string field)
        {
            WildPokemon wildPokemon = null;

            switch (field)
            {
                case "tallGrass":
                    wildPokemon = new WildPokemon(mapReader.tallGrass);
                    break;
                case "sea":
                    wildPokemon = new WildPokemon(mapReader.sea);
                    break;
                case "cave":
                    wildPokemon = new WildPokemon(mapReader.cave);
                    break;
            }

            return wildPokemon;
        }

        void OnTriggerEnter2D(Collider2D other) { isInside = true; }

        void OnTriggerExit2D(Collider2D other) { isInside = false; }

        #endregion Methods
    }
}