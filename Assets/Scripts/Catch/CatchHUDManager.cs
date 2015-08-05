using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace Assets.Scripts.Catch
{
    public static class CatchHUDManager{

        /// <summary>
        /// Returns the number of pressures the players needs to catch the pokémon
        /// </summary>
        /// <returns></returns>
        public static double GetMaxPressures(Pokemon pokemon)
        {
            var n = NumberFromCategory(pokemon.CatchCategory) * ((double)pokemon.Hp / (double)pokemon.HpMax) * ((double)pokemon.Level/100);

            if (n < 10)
                n = 10;

            return n;
        }

        /// <summary>
        /// Determines how many pressures are needed for the pokemon based on its category
        /// </summary>
        /// <param name="catchCategory"></param>
        /// <returns></returns>
        public static int NumberFromCategory(CatchCategory catchCategory)
        {
            switch (catchCategory)
            {
                case CatchCategory.Common:
                    return 100;
                case CatchCategory.NonCommon:
                    return 200;
                case CatchCategory.Rare:
                    return 400;
                case CatchCategory.SemiLegendary:
                    return 800;
                default:
                    return 1200;
            }
        }
    }
}
