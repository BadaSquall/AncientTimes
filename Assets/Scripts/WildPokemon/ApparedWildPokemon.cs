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
    private int percentageAppearance;
    private List<WildPokemon> tallGrass;
    private int pokemonSelected;
    private String namePokemonSelected;
    private int levelPokemonSelected;
    private float timeToAppared = 0.0F;
    private float TimeToApparedRate = 1.0F;

    #endregion Properties

        #region Methods

        void Start()
        {
            mapReader = (WildPokemonMap)XMLDeserializer.Deserialize(typeof(WildPokemonMap), 
                @"Assets/WildPokemonMap/" + GameVariables.Variables["CurrentMap"] + ".xml");
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
                        pokemonSelected = Random.Range(1, mapReader.tallGrass.Count);
                        namePokemonSelected = mapReader.tallGrass[pokemonSelected].pokemonName.ToString();
                        levelPokemonSelected = Random.Range(mapReader.tallGrass[pokemonSelected].levelMin,
                            mapReader.tallGrass[pokemonSelected].levelMax);

                        //TODO: add a interface to create an Pokemon Object
                        // Pokemon p = new Pokemon(namePokemonSelected, levelPokemonSelected);

                        //TODO: add an interface to Run a Pokèmon Battle
                        // Battle.GoBattle (p);
                    }
                }
            }

        }

        void OnTriggerEnter2D(Collider2D other)
        {
            isInside = true;
        }

        void OnTriggerExit2D(Collider2D other)
        {
            isInside = false;
        }

    #endregion Methods
    }

}