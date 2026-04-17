using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Legion.Models;
using Legion.Parsers;

namespace Legion.Util
{
    internal static class GameSorter
    {
        public static List<Game> SortByName(List<Game> gameParam)
        {
            // essa implementação é meio burra e custosa, mas por enquanto vai ter que funcionar

            string[] sortOrder = new string[gameParam.Count];
            Dictionary<string, Game> gameDic = new Dictionary<string, Game>();

            for (int i = 0; i < sortOrder.Length; i++)
            {
                sortOrder[i] = gameParam[i].Name;
                gameDic.Add(gameParam[i].Name, gameParam[i]);
            }
            Array.Sort(sortOrder);
            
            for (int i = 0; i < gameParam.Count; i++)            
                gameParam[i] = gameDic[sortOrder[i]];            

            return gameParam;
        }        
    }
}
