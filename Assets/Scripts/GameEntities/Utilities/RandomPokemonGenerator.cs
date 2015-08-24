/// <summary>
/// Class which generates a random wild pokemon.
/// </summary>
public static class RandomPokemonGenerator 
{
    #region Static Methods

    /// <summary>
    /// Method which generates a wild random pokemon providing the name and level. TODO: istantiate the pokemon based on certain rules.
    /// </summary>
    public static Pokemon GenerateWildPokemon(string name, int level)
    {
        // TODO: make this dynamic
        return new Pokemon
        {
            Name = name,
            Level = level
        };
    }

    #endregion
}
