using System.Collections.Generic;

/// <summary>
/// Class representing a single entry of the nature chart.
/// </summary>
public class NatureChartEntry
{
    /// <summary>
    /// Gets or sets the effects this nature has on other natures.
    /// </summary>
    /// <value>
    /// The effects this nature has on other natures.
    /// </value>
    public Dictionary<PokemonNature, NatureEffect> Effects { get; set; }

    /// <summary>
    /// Gets or sets the attack modifier.
    /// </summary>
    /// <value>
    /// The attack modifier.
    /// </value>
    public double AttackModifier { get; set; }

    /// <summary>
    /// Gets or sets the defense modifier.
    /// </summary>
    /// <value>
    /// The defense modifier.
    /// </value>
    public double DefenseModifier { get; set; }

    /// <summary>
    /// Gets or sets the special attack modifier.
    /// </summary>
    /// <value>
    /// The special attack modifier.
    /// </value>
    public double SpecialAttackModifier { get; set; }

    /// <summary>
    /// Gets or sets the special defense modifier.
    /// </summary>
    /// <value>
    /// The special defense modifier.
    /// </value>
    public double SpecialDefenseModifier { get; set; }

    /// <summary>
    /// Gets or sets the speed modifier.
    /// </summary>
    /// <value>
    /// The speed modifier.
    /// </value>
    public double SpeedModifier { get; set; }
}


/// <summary>
/// Class representing the effects which a nature can have on the stat of the pokemon and with other natures.
/// </summary>
public static class NatureChart
{
    #region Properties

    private static readonly Dictionary<PokemonNature, NatureChartEntry> natureChart = 
        new Dictionary<PokemonNature, NatureChartEntry>();

    #endregion

    /// <summary>
    /// Initializes the <see cref="NatureChart"/> class.
    /// </summary>
    static NatureChart()
    {
        // Hardy
        var hardyEntry = new NatureChartEntry
        {
            AttackModifier = 1.0f,
            DefenseModifier = 1.0f,
            SpecialAttackModifier = 1.0f,
            SpecialDefenseModifier = 1.0f,
            SpeedModifier = 1.0f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Hardy, hardyEntry);

        // Lonely
        var lonelyEntry = new NatureChartEntry
        {
            AttackModifier = 1.1f,
            DefenseModifier = 0.9f,
            SpecialAttackModifier = 1.0f,
            SpecialDefenseModifier = 1.0f,
            SpeedModifier = 1.0f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Lonely, lonelyEntry);

        // Brave
        var braveEntry = new NatureChartEntry
        {
            AttackModifier = 1.1f,
            DefenseModifier = 1.0f,
            SpecialAttackModifier = 1.0f,
            SpecialDefenseModifier = 1.0f,
            SpeedModifier = 0.9f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Brave, braveEntry);

        // Adamant
        var adamantEntry = new NatureChartEntry
        {
            AttackModifier = 1.1f,
            DefenseModifier = 1.0f,
            SpecialAttackModifier = 0.9f,
            SpecialDefenseModifier = 1.0f,
            SpeedModifier = 1.0f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Adamant, adamantEntry);

        // Naughty
        var naughtyEntry = new NatureChartEntry
        {
            AttackModifier = 1.1f,
            DefenseModifier = 1.0f,
            SpecialAttackModifier = 1.0f,
            SpecialDefenseModifier = 0.9f,
            SpeedModifier = 1.0f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Naughty, naughtyEntry);

        // Bold
        var boldEntry = new NatureChartEntry
        {
            AttackModifier = 0.9f,
            DefenseModifier = 1.1f,
            SpecialAttackModifier = 1.0f,
            SpecialDefenseModifier = 1.0f,
            SpeedModifier = 1.0f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Bold, boldEntry);

        // Docile
        var docileEntry = new NatureChartEntry
        {
            AttackModifier = 1.0f,
            DefenseModifier = 1.0f,
            SpecialAttackModifier = 1.0f,
            SpecialDefenseModifier = 1.0f,
            SpeedModifier = 1.0f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Docile, docileEntry);

        // Relaxed
        var relaxedEntry = new NatureChartEntry
        {
            AttackModifier = 1.0f,
            DefenseModifier = 1.1f,
            SpecialAttackModifier = 1.0f,
            SpecialDefenseModifier = 1.0f,
            SpeedModifier = 0.9f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Relaxed, relaxedEntry);

        // Impish
        var impishEntry = new NatureChartEntry
        {
            AttackModifier = 1.0f,
            DefenseModifier = 1.1f,
            SpecialAttackModifier = 0.9f,
            SpecialDefenseModifier = 1.0f,
            SpeedModifier = 1.0f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Impish, impishEntry);

        // Lax
        var laxEntry = new NatureChartEntry
        {
            AttackModifier = 1.0f,
            DefenseModifier = 1.1f,
            SpecialAttackModifier = 1.0f,
            SpecialDefenseModifier = 0.9f,
            SpeedModifier = 1.0f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Lax, laxEntry);

        // Timid
        var timidEntry = new NatureChartEntry
        {
            AttackModifier = 0.9f,
            DefenseModifier = 1.0f,
            SpecialAttackModifier = 1.0f,
            SpecialDefenseModifier = 1.0f,
            SpeedModifier = 1.1f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Timid, timidEntry);

        // Hasty
        var hastyEntry = new NatureChartEntry
        {
            AttackModifier = 1.0f,
            DefenseModifier = 0.9f,
            SpecialAttackModifier = 1.0f,
            SpecialDefenseModifier = 1.0f,
            SpeedModifier = 1.1f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Hasty, hastyEntry);

        // Serious
        var seriousEntry = new NatureChartEntry
        {
            AttackModifier = 1.0f,
            DefenseModifier = 1.0f,
            SpecialAttackModifier = 1.0f,
            SpecialDefenseModifier = 1.0f,
            SpeedModifier = 1.0f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Serious, seriousEntry);

        // Jolly
        var jollyEntry = new NatureChartEntry
        {
            AttackModifier = 1.0f,
            DefenseModifier = 1.0f,
            SpecialAttackModifier = 0.9f,
            SpecialDefenseModifier = 1.0f,
            SpeedModifier = 1.1f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Jolly, jollyEntry);

        // Naive
        var naiveEntry = new NatureChartEntry
        {
            AttackModifier = 1.0f,
            DefenseModifier = 1.0f,
            SpecialAttackModifier = 1.0f,
            SpecialDefenseModifier = 0.9f,
            SpeedModifier = 1.1f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Naive, naiveEntry);

        // Modest
        var modestEntry = new NatureChartEntry
        {
            AttackModifier = 0.9f,
            DefenseModifier = 1.0f,
            SpecialAttackModifier = 1.1f,
            SpecialDefenseModifier = 1.0f,
            SpeedModifier = 1.0f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Modest, modestEntry);

        // Mild
        var mildEntry = new NatureChartEntry
        {
            AttackModifier = 1.0f,
            DefenseModifier = 0.9f,
            SpecialAttackModifier = 1.1f,
            SpecialDefenseModifier = 1.0f,
            SpeedModifier = 1.0f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Mild, mildEntry);

        // Quiet
        var quietEntry = new NatureChartEntry
        {
            AttackModifier = 1.0f,
            DefenseModifier = 1.0f,
            SpecialAttackModifier = 1.1f,
            SpecialDefenseModifier = 1.0f,
            SpeedModifier = 0.9f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Quiet, quietEntry);

        // Bashful
        var bashfulEntry = new NatureChartEntry
        {
            AttackModifier = 1.0f,
            DefenseModifier = 1.0f,
            SpecialAttackModifier = 1.0f,
            SpecialDefenseModifier = 1.0f,
            SpeedModifier = 1.0f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Bashful, bashfulEntry);

        // Rash
        var rashEntry = new NatureChartEntry
        {
            AttackModifier = 1.0f,
            DefenseModifier = 1.0f,
            SpecialAttackModifier = 1.1f,
            SpecialDefenseModifier = 0.9f,
            SpeedModifier = 1.0f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Rash, rashEntry);

        // Calm
        var calmEntry = new NatureChartEntry
        {
            AttackModifier = 0.9f,
            DefenseModifier = 1.0f,
            SpecialAttackModifier = 1.0f,
            SpecialDefenseModifier = 1.1f,
            SpeedModifier = 1.0f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Calm, calmEntry);

        // Gentle
        var gentleEntry = new NatureChartEntry
        {
            AttackModifier = 1.0f,
            DefenseModifier = 0.9f,
            SpecialAttackModifier = 1.0f,
            SpecialDefenseModifier = 1.1f,
            SpeedModifier = 1.0f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Gentle, gentleEntry);

        // Sassy
        var sassyEntry = new NatureChartEntry
        {
            AttackModifier = 1.0f,
            DefenseModifier = 1.0f,
            SpecialAttackModifier = 1.0f,
            SpecialDefenseModifier = 1.1f,
            SpeedModifier = 0.9f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Sassy, sassyEntry);

        // Careful
        var carefulEntry = new NatureChartEntry
        {
            AttackModifier = 1.0f,
            DefenseModifier = 1.0f,
            SpecialAttackModifier = 0.9f,
            SpecialDefenseModifier = 1.1f,
            SpeedModifier = 1.0f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Careful, carefulEntry);

        // Quirky
        var quirkyEntry = new NatureChartEntry
        {
            AttackModifier = 1.0f,
            DefenseModifier = 1.0f,
            SpecialAttackModifier = 1.0f,
            SpecialDefenseModifier = 1.0f,
            SpeedModifier = 1.0f,
            Effects = new Dictionary<PokemonNature, NatureEffect>()
        };

        natureChart.Add(PokemonNature.Quirky, quirkyEntry);
    }

    /// <summary>
    /// Gets the chart entry from nature.
    /// </summary>
    /// <param name="nature">The nature.</param>
    /// <returns></returns>
    public static NatureChartEntry GetChartEntryFromNature(PokemonNature nature)
    {
        return natureChart.ContainsKey(nature) ? natureChart[nature] : null;
    }
}
