using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using Legion.Models;
using Legion.Parsers;
using Legion.Services;
using Legion.Util;
namespace Winforms
{    
    public partial class Main : Form
    {                       
        public Main()
        {
            InitializeComponent();

            // TODO: DB local
            // achar um jeito de abrir um jogo usando a steam (dados em acf) :DONE
            // criar cards/botões gerando dinamicamente ao detectar jogos instalados
            // ajeitar minimamente a UI

            // Sobrescrever FormBorder
            
            //this.FormBorderStyle = FormBorderStyle.None;            

            // END


        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Main_Load(object sender, EventArgs e)
        {            
            Game[] games = JsonParser.ReadJson();
            
            // Definir propriedades de elementos UI
            gamesPanel.Dock = DockStyle.Fill;
            gamesPanel.WrapContents = false;
            gamesPanel.AutoScroll = true;
            // END
            
            // Função adicionar botões dinamicamente
            foreach (Game game in games)
            {
                Button btn = new Button();
                btn.Text = game.Name;
                btn.Tag = game;

                btn.Width = 270;
                btn.Height = 40;
   
                btn.Click += (sender, e) =>
                {
                    var g = (Game)((Button)sender).Tag;

                    if (game.AppId != null)
                    {
                        SteamServices.GameStart(game.AppId);
                    }
                    else
                    {
                        GameServices.GameStart(game.InstallDir);
                    }
                };

                gamesPanel.Controls.Add(btn);
                
            }
            // END                        
        }
    }
}
