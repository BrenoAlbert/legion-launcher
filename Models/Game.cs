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
        public Game(string Name, string InstallDir, string AppId = null)
        {
            this.Name = Name;            
            this.InstallDir = InstallDir;
            this.AppId = AppId;
        }
        public string Name { get { return this.name; } set { this.name = value; } }
        public string AppId { get { return this.appId; } set { this.appId = value; } }
        public string InstallDir { get { return this.installDir; } set { this.installDir = value; } }
        public string[] Tags { get { return this.tags; } set { this.tags = value; } }
    }
}
