using UnityEngine;

namespace Assets.Scripts.Catch
{
    public static class CatchHUDManager{

        /// <summary>
        /// Returns the number of pressures the players needs to catch the pokémon
        /// </summary>
        /// <returns></returns>
        public static int GetPressures()
        {
            //int n = NumberFromCategory(pokemon.CatchCategory) * ((double)pokemon.CurrentHp / (double)pokemon.TotalHp);

            //if n < 10
            //    new = 10;

            return 5;
        }
    }
}
