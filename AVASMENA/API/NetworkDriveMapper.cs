using System;
using System.Diagnostics;
using System.Configuration;
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


            // Команда net use для подключения сетевого ресурса
            string connectCommand = $"net use {networkPath} /user:{username} {password}";

            try
            {
                // Подключаем новый сетевой ресурс
                RunCommand(connectCommand);
            }
            catch (Exception ex)
            {
                Logger.ErrorLog($"Ошибка при подключении сетевого ресурса: {ex.Message}");
            }
        }

        private static void RunCommand(string command)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = $"/C {command}";
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
                    Logger.Log("Результат команды: " + output);
                }

                if (!string.IsNullOrEmpty(error))
                {
                    Logger.ErrorLog("Ошибка выполнения команды: " + error);
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorLog($"Ошибка при выполнении команды: {ex.Message}");
            }
        }
    }
}
