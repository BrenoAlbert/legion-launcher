using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Legion.Parsers;
using Legion.Services;

namespace Legion.Models
{
    public class Library
    {
        private string folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Legion"
            );
        private string jsonFile = "library.json";
        private string jsonPath;
        private char[] drives;
        private Game[] games;

        public Library(char[] drives)
        {
            this.jsonPath = $"{folder}\\{jsonFile}";
            this.drives = drives;
            this.games = JsonParser.ReadLibrary();
        }
        public string JsonFile { get; set; }
        public string Folder { get; set; }
        public char[] Drives { get; set; }
        public void AddGame(Game newGame)
        {

        }
        public void AddGamesSteam()
        {
            JsonParser parse = new JsonParser(jsonFile);
            Fetcher fetch;
            Game[] games;

            if (drives.Length < 1)            
                throw new ArgumentOutOfRangeException(nameof(drives), "Drives (SSD/HDD) are non-existent or invalid!");

            else if (drives.Length == 1)
            {
                fetch = new Fetcher(drives[0]);
                games = fetch.FetchGamesSteam();
                parse.WriteLibrary(games);
            }
            else
            {
                foreach (char drive in drives)
                {
                    fetch = new Fetcher(drive);
                    games = fetch.FetchGamesSteam();
                    parse.WriteLibrary(games);
                }
            }
        }
        public void RemoveGame(Game targetGame)
        {

        }
        public Game[] LoadGames()
        {
            return JsonParser.ReadLibrary();
        }
    }
}
