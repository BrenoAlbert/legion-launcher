using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Legion.Models;
using Legion.Util;

namespace Legion.Parsers
{
    internal static class AcfParser
    {
        private static string[] GetAcf(char drive)
        {
            string steamappsDir;
            string[] files;

            // ascii: 65 = A, 90 = Z
            if (!(drive >= 65 && drive <= 90))
                return null;

            steamappsDir = $"{drive}:\\SteamLibrary\\steamapps";
            files = Directory.GetFiles(steamappsDir, "*.acf");

            return files;
        }        
        private static string ExtractInfo(string linha)
        {           
            // levando em consideração que esse metodo só vai ler esses ACFs de um jogo steam,
            // é tudo padronizado, de qualquer jeito, então n precisa preocupar com validação         

            int primeiro = linha.IndexOf('"');
            int segundo = linha.IndexOf('"', primeiro + 1);
            primeiro = linha.IndexOf('"', segundo + 1);
            segundo = linha.IndexOf('"', primeiro + 1);            

            return linha.Substring(primeiro + 1, segundo - primeiro - 1);
        }        
        public static Game[] GetGames(char drive)
        {
            string[] acfFiles = GetAcf(drive);
            Game[] games = new Game[acfFiles.Length];

            string name = null;
            string appId = null;
            string installDir = null;

            string linha;

            for (int i = 0; i < games.Length || i < acfFiles.Length; i++)
            {
                using (StreamReader sr = new StreamReader(acfFiles[i]))
                {
                    while ((linha = sr.ReadLine()) != null)
                    {
                        if (linha.TrimStart().StartsWith("\"name\""))
                            name = ExtractInfo(linha);

                        else if (linha.TrimStart().StartsWith("\"appid\""))
                            appId = ExtractInfo(linha);

                        else if (linha.TrimStart().StartsWith("\"installdir\""))
                            installDir = ExtractInfo(linha);
                    }
                }
                games[i] = new Game(name, appId, installDir);
            }

            return Sorter.SortByName(games);
        }
        
    }
}
