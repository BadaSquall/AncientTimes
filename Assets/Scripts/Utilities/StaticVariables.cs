using System.Collections.Generic;

namespace AncientTimes.Assets.Scripts.Utilities 
{
    /// <summary>
    /// Class containing all properties which need to be global in the game.
    /// </summary>
	public static class StaticVariables 
	{
        /// <summary>
        /// Gets or sets the player team.
        /// </summary>
        /// <value>
        /// The player team.
        /// </value>
		public static List<Pokemon> PlayerTeam { get; set; }

        /// <summary>
        /// Gets or sets the name of the trainer.
        /// </summary>
        /// <value>
        /// The name of the trainer.
        /// </value>
		public static string TrainerName { get; set; }

        /// <summary>
        /// Initializes the <see cref="StaticVariables"/> class.
        /// </summary>
	    static StaticVariables()
	    {
	        PlayerTeam = new List<Pokemon>();
	    }
	}
}
