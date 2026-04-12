using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legion.Services
{
    internal static class SteamServices
    {
        internal static string GameStart(string appid)
        {
            string message = null;

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = $"steam://rungameid/{appid}",
                UseShellExecute = true,
            };

            try
            {
                Process.Start(psi);
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return message;
        }
    }
}
