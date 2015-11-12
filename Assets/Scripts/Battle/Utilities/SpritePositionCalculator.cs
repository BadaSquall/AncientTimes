using AncientTimes.Assets.Scripts.GameSystem;
using UnityEngine;

/// <summary>
/// Class which calculates the correct position of a battle sprite.
/// It will be used specifically for Pokemons, Moves and Abilities.
/// </summary>
public static class SpritePositionCalculator 
{
    /// <summary>
    /// Gets the offset for a pokemon.
    /// </summary>
    /// <param name="pokemonPrefab">The pokemon prefab.</param>
    /// <param name="isPlayer">if set to <c>true</c> the offset is calculated for the player's pokemon,
    ///  for the enemy otherwise.</param>
    /// <returns></returns>
    public static Vector3 GetOffsetForPokemon(GameObject pokemonPrefab, bool isPlayer)
    {
        double finalX = 0.0f, finalY = 0.0f;

        /* TODO: implement a way to define the two points of the map 
           to load the pokemons into. */

        if (isPlayer)
        {
            finalX = -4.26f;
            finalY = -2.91f;
        }
        else
        {
            finalX = 3.53f;
            finalY = 0.56f;
        }

        var prefabSize = pokemonPrefab.renderer.bounds.size;
        finalY = finalY + prefabSize.y / 2.7f;

        return new Vector3((float) finalX, (float) finalY);
    }
}
