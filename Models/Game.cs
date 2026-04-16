using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Legion.Models
{
    public class Game
    {
        private string name;
        private string appId;
        private string installDir;
        private string[] tags;

        [JsonConstructor]
        public Game(string Name, string AppId, string InstallDir)
        {
            this.Name = Name;
            this.AppId = AppId;
            this.InstallDir = InstallDir;
        }
        public string Name { get; set; }
        public string AppId { get; set; }
        public string InstallDir { get; set; }
        public string[] Tags { get; set; }
    }
}
