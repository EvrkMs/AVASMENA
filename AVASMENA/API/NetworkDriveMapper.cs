using System;
using System.Diagnostics;
using AVASMENA.Loggers;

namespace AVASMENA.API
{
    public static class NetworkDriveMapper
    {
        public static void MapNetworkDrive()
        {
            // Получаем путь из app.config
            string networkPath = "\\\\45.88.209.160\\AVASMENAUpdate";
            string username = "man";
            string password = "2384";

            // Команда PowerShell для работы с UNC путем
            string psCommand = $"net use {networkPath} /user:{username} {password}";

            try
            {
                // Запускаем PowerShell команду
                RunPowerShellCommand(psCommand);
            }
            catch (Exception ex)
            {
                Logger.ErrorLog($"Ошибка при подключении сетевого ресурса: {ex.Message}");
            }
        }

        private static void RunPowerShellCommand(string command)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "powershell.exe";
                process.StartInfo.Arguments = $"-Command \"{command}\"";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (!string.IsNullOrEmpty(output))
                {
                    Logger.Log("Результат команды PowerShell: " + output);
                }

                if (!string.IsNullOrEmpty(error))
                {
                    Logger.ErrorLog("Ошибка выполнения команды PowerShell: " + error);
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorLog($"Ошибка при выполнении команды PowerShell: {ex.Message}");
            }
        }
    }
}
