using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legion.Models
{
    public class Game
    {
        private string name;
        private string appId;
        private string installDir;
        public Game(string n, string id, string d)
        {
            this.installDir = d;
            this.name = n;
            this.appId = id;
        }

        public string Name
        {
            get { return this.name; }
        }
        public string AppId
        {
            get { return this.appId; }
        }
        public string InstallDir
        {
            get { return this.installDir; }
        }        
    }
}
