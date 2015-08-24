using System.Collections.Generic;

/// <summary>
/// Internal class used for definition of relationships between types.
/// </summary>
public class TypeChartEntry
{
    #region Properties

    public List<PokemonType> Weak { get; set; }
    public List<PokemonType> Resistant { get; set; }
    public List<PokemonType> NoEffect { get; set; }

    #endregion
}

/// <summary>
/// Static class exposing methods for the purpose of simplifing type damage calculations.
/// </summary>
static public class TypeChart
{
    #region Properties

    private static readonly Dictionary<PokemonType, TypeChartEntry> typeChart = new Dictionary<PokemonType, TypeChartEntry>();

    #endregion

    #region Methods

    /// <summary>
    /// Initializes the <see cref="TypeChart"/> class.
    /// </summary>
    static TypeChart()
    {
        // Normal type chart
        var normEntry = new TypeChartEntry
        {
            NoEffect = new List<PokemonType>(),
            Resistant = new List<PokemonType>(),
            Weak = new List<PokemonType>()
        };

        normEntry.Weak.Add(PokemonType.Fight);

        normEntry.NoEffect.Add(PokemonType.Ghost);

        typeChart[PokemonType.Normal] = normEntry;

        // Fire type chart
        var fireEntry = new TypeChartEntry
        {
            NoEffect = new List<PokemonType>(),
            Resistant = new List<PokemonType>(),
            Weak = new List<PokemonType>()
        };

        fireEntry.Weak.Add(PokemonType.Water);
        fireEntry.Weak.Add(PokemonType.Ground);
        fireEntry.Weak.Add(PokemonType.Rock);

        fireEntry.Resistant.Add(PokemonType.Fire);
        fireEntry.Resistant.Add(PokemonType.Grass);
        fireEntry.Resistant.Add(PokemonType.Ice);
        fireEntry.Resistant.Add(PokemonType.Bug);
        fireEntry.Resistant.Add(PokemonType.Steel);
        fireEntry.Resistant.Add(PokemonType.Fairy);

        typeChart[PokemonType.Fire] = fireEntry;

        // Water type chart
        var waterEntry = new TypeChartEntry
        {
            NoEffect = new List<PokemonType>(),
            Resistant = new List<PokemonType>(),
            Weak = new List<PokemonType>()
        };

        waterEntry.Weak.Add(PokemonType.Electric);
        waterEntry.Weak.Add(PokemonType.Grass);

        waterEntry.Resistant.Add(PokemonType.Fire);
        waterEntry.Resistant.Add(PokemonType.Water);
        waterEntry.Resistant.Add(PokemonType.Ice);
        waterEntry.Resistant.Add(PokemonType.Steel);

        typeChart[PokemonType.Water] = waterEntry;

        // Electric type chart
        var eleEntry = new TypeChartEntry
        {
            NoEffect = new List<PokemonType>(),
            Resistant = new List<PokemonType>(),
            Weak = new List<PokemonType>()
        };

        eleEntry.Weak.Add(PokemonType.Ground);

        eleEntry.Resistant.Add(PokemonType.Electric);
        eleEntry.Resistant.Add(PokemonType.Flying);
        eleEntry.Resistant.Add(PokemonType.Steel);

        typeChart[PokemonType.Electric] = eleEntry;

        // Grass type chart
        var grassEntry = new TypeChartEntry
        {
            NoEffect = new List<PokemonType>(),
            Resistant = new List<PokemonType>(),
            Weak = new List<PokemonType>()
        };

        grassEntry.Weak.Add(PokemonType.Fire);
        grassEntry.Weak.Add(PokemonType.Ice);
        grassEntry.Weak.Add(PokemonType.Poison);
        grassEntry.Weak.Add(PokemonType.Flying);
        grassEntry.Weak.Add(PokemonType.Bug);

        grassEntry.Resistant.Add(PokemonType.Water);
        grassEntry.Resistant.Add(PokemonType.Electric);
        grassEntry.Resistant.Add(PokemonType.Grass);
        grassEntry.Resistant.Add(PokemonType.Ground);

        typeChart[PokemonType.Grass] = grassEntry;

        // Ice type chart
        var iceEntry = new TypeChartEntry
        {
            NoEffect = new List<PokemonType>(),
            Resistant = new List<PokemonType>(),
            Weak = new List<PokemonType>()
        };

        iceEntry.Weak.Add(PokemonType.Fire);
        iceEntry.Weak.Add(PokemonType.Fight);
        iceEntry.Weak.Add(PokemonType.Rock);
        iceEntry.Weak.Add(PokemonType.Steel);

        iceEntry.Resistant.Add(PokemonType.Ice);

        typeChart[PokemonType.Ice] = iceEntry;

        // Fighting type chart
        var fightEntry = new TypeChartEntry
        {
            NoEffect = new List<PokemonType>(),
            Resistant = new List<PokemonType>(),
            Weak = new List<PokemonType>()
        };

        fightEntry.Weak.Add(PokemonType.Flying);
        fightEntry.Weak.Add(PokemonType.Psychic);
        fightEntry.Weak.Add(PokemonType.Fairy);

        fightEntry.Resistant.Add(PokemonType.Bug);
        fightEntry.Resistant.Add(PokemonType.Rock);
        fightEntry.Resistant.Add(PokemonType.Dark);

        typeChart[PokemonType.Fight] = fightEntry;

        // Poison type chart
        var poisonEntry = new TypeChartEntry
        {
            NoEffect = new List<PokemonType>(),
            Resistant = new List<PokemonType>(),
            Weak = new List<PokemonType>()
        };

        poisonEntry.Weak.Add(PokemonType.Ground);
        poisonEntry.Weak.Add(PokemonType.Psychic);

        poisonEntry.Resistant.Add(PokemonType.Grass);
        poisonEntry.Resistant.Add(PokemonType.Fight);
        poisonEntry.Resistant.Add(PokemonType.Poison);
        poisonEntry.Resistant.Add(PokemonType.Bug);
        poisonEntry.Resistant.Add(PokemonType.Fairy);

        typeChart[PokemonType.Poison] = poisonEntry;

        // Ground type chart
        var groundEntry = new TypeChartEntry
        {
            NoEffect = new List<PokemonType>(),
            Resistant = new List<PokemonType>(),
            Weak = new List<PokemonType>()
        };

        groundEntry.Weak.Add(PokemonType.Water);
        groundEntry.Weak.Add(PokemonType.Grass);
        groundEntry.Weak.Add(PokemonType.Ice);

        groundEntry.Resistant.Add(PokemonType.Poison);
        groundEntry.Resistant.Add(PokemonType.Rock);

        groundEntry.NoEffect.Add(PokemonType.Electric);

        typeChart[PokemonType.Ground] = groundEntry;

        // Flying type chart
        var flyEntry = new TypeChartEntry
        {
            NoEffect = new List<PokemonType>(),
            Resistant = new List<PokemonType>(),
            Weak = new List<PokemonType>()
        };

        flyEntry.Weak.Add(PokemonType.Electric);
        flyEntry.Weak.Add(PokemonType.Ice);
        flyEntry.Weak.Add(PokemonType.Rock);

        flyEntry.Resistant.Add(PokemonType.Grass);
        flyEntry.Resistant.Add(PokemonType.Fight);
        flyEntry.Resistant.Add(PokemonType.Bug);

        flyEntry.NoEffect.Add(PokemonType.Ground);

        typeChart[PokemonType.Flying] = flyEntry;

        // Psychic type chart
        var psyEntry = new TypeChartEntry
        {
            NoEffect = new List<PokemonType>(),
            Resistant = new List<PokemonType>(),
            Weak = new List<PokemonType>()
        };

        psyEntry.Weak.Add(PokemonType.Bug);
        psyEntry.Weak.Add(PokemonType.Ghost);
        psyEntry.Weak.Add(PokemonType.Dark);

        psyEntry.Resistant.Add(PokemonType.Fight);
        psyEntry.Resistant.Add(PokemonType.Psychic);

        typeChart[PokemonType.Psychic] = psyEntry;

        // Bug type chart
        var bugEntry = new TypeChartEntry
        {
            NoEffect = new List<PokemonType>(),
            Resistant = new List<PokemonType>(),
            Weak = new List<PokemonType>()
        };

        bugEntry.Weak.Add(PokemonType.Fire);
        bugEntry.Weak.Add(PokemonType.Flying);
        bugEntry.Weak.Add(PokemonType.Rock);

        bugEntry.Resistant.Add(PokemonType.Grass);
        bugEntry.Resistant.Add(PokemonType.Fight);
        bugEntry.Resistant.Add(PokemonType.Ground);

        typeChart[PokemonType.Bug] = bugEntry;

        // Rock type chart
        var rockEntry = new TypeChartEntry
        {
            NoEffect = new List<PokemonType>(),
            Resistant = new List<PokemonType>(),
            Weak = new List<PokemonType>()
        };

        rockEntry.Weak.Add(PokemonType.Water);
        rockEntry.Weak.Add(PokemonType.Grass);
        rockEntry.Weak.Add(PokemonType.Fight);
        rockEntry.Weak.Add(PokemonType.Ground);

        rockEntry.Resistant.Add(PokemonType.Normal);
        rockEntry.Resistant.Add(PokemonType.Fire);
        rockEntry.Resistant.Add(PokemonType.Poison);
        rockEntry.Resistant.Add(PokemonType.Flying);

        typeChart[PokemonType.Rock] = rockEntry;

        // Ghost type chart
        var ghostEntry = new TypeChartEntry
        {
            NoEffect = new List<PokemonType>(),
            Resistant = new List<PokemonType>(),
            Weak = new List<PokemonType>()
        };

        ghostEntry.Weak.Add(PokemonType.Ghost);
        ghostEntry.Weak.Add(PokemonType.Dark);

        ghostEntry.Resistant.Add(PokemonType.Poison);
        ghostEntry.Resistant.Add(PokemonType.Bug);

        ghostEntry.NoEffect.Add(PokemonType.Normal);
        ghostEntry.NoEffect.Add(PokemonType.Fight);

        typeChart[PokemonType.Ghost] = ghostEntry;

        // Dragon type chart
        var dragonEntry = new TypeChartEntry
        {
            NoEffect = new List<PokemonType>(),
            Resistant = new List<PokemonType>(),
            Weak = new List<PokemonType>()
        };

        dragonEntry.Weak.Add(PokemonType.Ice);
        dragonEntry.Weak.Add(PokemonType.Dragon);
        dragonEntry.Weak.Add(PokemonType.Fairy);

        dragonEntry.Resistant.Add(PokemonType.Fire);
        dragonEntry.Resistant.Add(PokemonType.Water);
        dragonEntry.Resistant.Add(PokemonType.Electric);
        dragonEntry.Resistant.Add(PokemonType.Grass);

        typeChart[PokemonType.Dragon] = dragonEntry;

        // Dark type chart
        var darkEntry = new TypeChartEntry
        {
            NoEffect = new List<PokemonType>(),
            Resistant = new List<PokemonType>(),
            Weak = new List<PokemonType>()
        };

        darkEntry.Weak.Add(PokemonType.Fight);
        darkEntry.Weak.Add(PokemonType.Bug);
        darkEntry.Weak.Add(PokemonType.Fairy);

        darkEntry.Resistant.Add(PokemonType.Ghost);
        darkEntry.Resistant.Add(PokemonType.Dark);

        darkEntry.NoEffect.Add(PokemonType.Psychic);

        typeChart[PokemonType.Dark] = darkEntry;

        // Steel type chart
        var steelEntry = new TypeChartEntry
        {
            NoEffect = new List<PokemonType>(),
            Resistant = new List<PokemonType>(),
            Weak = new List<PokemonType>()
        };

        steelEntry.Weak.Add(PokemonType.Fire);
        steelEntry.Weak.Add(PokemonType.Fight);
        steelEntry.Weak.Add(PokemonType.Ground);

        steelEntry.Resistant.Add(PokemonType.Normal);
        steelEntry.Resistant.Add(PokemonType.Grass);
        steelEntry.Resistant.Add(PokemonType.Ice);
        steelEntry.Resistant.Add(PokemonType.Flying);
        steelEntry.Resistant.Add(PokemonType.Psychic);
        steelEntry.Resistant.Add(PokemonType.Bug);
        steelEntry.Resistant.Add(PokemonType.Rock);
        steelEntry.Resistant.Add(PokemonType.Dragon);
        steelEntry.Resistant.Add(PokemonType.Steel);
        steelEntry.Resistant.Add(PokemonType.Fairy);

        steelEntry.NoEffect.Add(PokemonType.Poison);

        typeChart[PokemonType.Steel] = steelEntry;

        // Fairy type chart
        var fairyEntry = new TypeChartEntry
        {
            NoEffect = new List<PokemonType>(),
            Resistant = new List<PokemonType>(),
            Weak = new List<PokemonType>()
        };

        fairyEntry.Weak.Add(PokemonType.Poison);
        fairyEntry.Weak.Add(PokemonType.Steel);

        fairyEntry.Resistant.Add(PokemonType.Fight);
        fairyEntry.Resistant.Add(PokemonType.Bug);
        fairyEntry.Resistant.Add(PokemonType.Dark);

        fairyEntry.NoEffect.Add(PokemonType.Dragon);

        typeChart[PokemonType.Fairy] = fairyEntry;
    }

    /// <summary>
    /// Gets the type chart entry for the specified type.
    /// </summary>
    /// <param name="type">The pokemon type.</param>
    /// <returns></returns>
    public static TypeChartEntry GetChartEntryFromType(PokemonType type)
    {
        return typeChart.ContainsKey(type) ? typeChart[type] : null;
    }

    /// <summary>
    /// Gets the weaknesses of the specified type.
    /// </summary>
    /// <param name="type">The pokemon type.</param>
    /// <returns></returns>
    public static List<PokemonType> GetWeaknesses(PokemonType type)
    {
        return typeChart.ContainsKey(type) ? typeChart[type].Weak : null;
    }

    /// <summary>
    /// Gets the resistances of the specified type.
    /// </summary>
    /// <param name="type">The pokemon type.</param>
    /// <returns></returns>
    public static List<PokemonType> GetResistances(PokemonType type)
    {
        return typeChart.ContainsKey(type) ? typeChart[type].Resistant : null;
    }

    /// <summary>
    /// Gets the type(s) which has no effect on the specified type.
    /// </summary>
    /// <param name="type">The pokemon type.</param>
    /// <returns></returns>
    public static List<PokemonType> GetNoEffects(PokemonType type)
    {
        return typeChart.ContainsKey(type) ? typeChart[type].NoEffect : null;
    }

    #endregion
}
