using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Legion.Models;
using Legion.Parsers;

namespace Legion.Util
{
    internal static class Sorter
    {
        public static Game[] SortByName(Game[] gameArray)
        {
            // essa implementação é meio burra e custosa, mas por enquanto vai ter que funcionar

            string[] sortOrder = new string[gameArray.Length];
            Dictionary<string, Game> gameDic = new Dictionary<string, Game>();

            for (int i = 0; i < sortOrder.Length; i++)
            {
                sortOrder[i] = gameArray[i].Name;
                gameDic.Add(gameArray[i].Name, gameArray[i]);
            }

            Array.Sort(sortOrder);

            for (int i = 0; i < gameArray.Length; i++)
            {
                gameArray[i] = gameDic[sortOrder[i]];
            }

            return gameArray;
        }
    }
}
