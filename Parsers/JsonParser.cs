using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

using Legion.Models;

namespace Legion.Parsers
{
    internal class JsonParser
    {
        public static async void WriteJson()
        {
            // escreve json em AppData Roaming

            string folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Legion"
            );
            Game[] gameInfo = AcfParser.GetGames('D');

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            await using FileStream create = File.Create($"{folder}\\library.json");

            await JsonSerializer.SerializeAsync(create, gameInfo, new JsonSerializerOptions
            {
                WriteIndented = true
            });

        }
        public static Game[] ReadJson()
        {
            string folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Legion"
            );

            string json = File.ReadAllText($"{folder}\\library.json");
            Game[] games = JsonSerializer.Deserialize<Game[]>(json);
            
            foreach(Game game in games)
            {
                Console.WriteLine(
                    $"{game.Name}\n"
                    );
            }
            return games;
        }        
    }
}
