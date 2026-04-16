using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using Legion.Models;
using Legion.Services;
using Legion.Util;

namespace Legion.Parsers
{
    internal class JsonParser
    {
        // appdata roaming
        private string folder;
        // library: "library.json"
        private string jsonPath;

        public JsonParser(string fileName)
        {
            this.folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Legion"
            );
            this.jsonPath = $"{folder}\\{fileName}";

        }

        public async void WriteLibrary(Game[] gamesA)
        {                                    
            JsonSerializerOptions jso = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            
            // /////////////////////////////////////////////////////////////

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            // função anônima para criar arquivo json
            //
            var createjson = async () =>
            {
                await using FileStream stream = File.Create(jsonPath);
                await JsonSerializer.SerializeAsync(stream, gamesA, jso);
            };
            //
            // END

            if (File.Exists(jsonPath))
            {                
                string gameJson = File.ReadAllText(jsonPath);
                List<Game> gamesL = JsonSerializer.Deserialize<List<Game>>(gameJson);
                
                foreach (Game game in gamesA)
                {
                    if (!gamesL.Contains(game))
                        gamesL.Add(game);
                }

                gamesA = GameSorter.SortByName(gamesL.ToArray());
                await createjson();
            }
            else
            {
                await createjson();
            }
            
        }

        public static Game[] ReadLibrary()
        {
            string folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Legion"
            );
            string jsonLibrary = File.ReadAllText($"{folder}\\library.json");
            Game[] games = JsonSerializer.Deserialize<Game[]>(jsonLibrary);
            
            /*
            foreach(Game game in games)
            {
                Console.WriteLine(
                    $"{game.Name}\n"
                    );
            }
            */
            return GameSorter.SortByName(games);
        }        
    }
}
