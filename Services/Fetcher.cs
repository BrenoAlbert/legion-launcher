using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Legion.Models;
using Legion.Parsers;

namespace Legion.Services
{
    internal class Fetcher
    {
        private char drive;
        public Fetcher(char drive)
        {
            this.drive = drive;
        }
        public char Drive { get; set; }

        public string[] FetchAcf()
        {
            string steamappsDir;
            string[] files;
            List<string> list = new List<string>();

            // ascii: 65 = A, 90 = Z
            if (!(drive >= 65 && drive <= 90))
                return null;

            steamappsDir = $"{drive}:\\SteamLibrary\\steamapps";
            files = Directory.GetFiles(steamappsDir, "*.acf");
            foreach (string file in files)
            {
                if (!file.Contains("480"))
                    list.Add(file);
            }

            return files = list.ToArray();
        }        
        public List<Game> FetchGamesSteam()
        {            
            string[] acfFiles = FetchAcf();
            List<Game> games = new List<Game>(acfFiles.Length);

            string name = null;
            string appId = null;
            string installDir = null;

            string linha;

            for (int i = 0; i < games.Count; i++)
            {
                using (StreamReader sr = new StreamReader(acfFiles[i]))
                {
                    while ((linha = sr.ReadLine()) != null)
                    {
                        if (linha.TrimStart().StartsWith("\"name\""))
                            name = AcfParser.ReadLine(linha);

                        else if (linha.TrimStart().StartsWith("\"appid\""))
                            appId = AcfParser.ReadLine(linha);

                        else if (linha.TrimStart().StartsWith("\"installdir\""))
                            installDir = AcfParser.ReadLine(linha);
                    }
                }
                games[i] = new Game(name, appId, installDir);
            }
            return games;
        }
        public static string FetchExe(string diretorio)
        {
            string[] caminhosArquivos;

            try
            {
                caminhosArquivos = Directory.GetFiles(diretorio, "*.exe", SearchOption.AllDirectories);

                if (caminhosArquivos[0] == null)
                    return null;

                return caminhosArquivos[0];
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
