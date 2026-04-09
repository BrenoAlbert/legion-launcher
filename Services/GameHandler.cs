using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legion.Services
{
    internal static class GameHandler
    {
        private static string GetExe(string diretorio)
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
        
        public static void Exec(string gameDir)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = gameDir,
            };

            Process.Start(psi);
        }
    }
}
