using AVASMENA.Loggers;
using Newtonsoft.Json.Linq;

namespace AVASMENA.API
{
    public static class UpdateVersionCheck
    {
        private static readonly string _endpoint = "api/Version";
        private static readonly Version _currentVersion = new("1.0.13"); // Замените на текущую версию вашей программы

        public static async Task<bool> MainVersion()
        {
            return await MainVersionAsync();
        }

        private static async Task<bool> MainVersionAsync()
        {
            if (_endpoint != null)
            {
                try
                {
                    // Получаем данные JSON из API
                    JObject jsonData = await ApiClient.GetJsonDataSync(_endpoint);
                    Logger.Log("Полученные данные: " + jsonData.ToString());

                    // Извлекаем версию из JSON
                    var versionString = jsonData["version"]?.ToString();
                    if (Version.TryParse(versionString, out Version? apiVersion))
                    {
                        // Сравниваем версии
                        int comparisonResult = _currentVersion.CompareTo(apiVersion);
                        if (comparisonResult < 0)
                        {
                            Logger.Log("Найдено новое обновление.");

                            // Уведомляем пользователя о новом обновлении
                            DialogResult result = MessageBox.Show(
                                "Доступно новое обновление. Хотите установить его сейчас?",
                                "Обновление программы",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                            if (result == DialogResult.OK)
                            {
                                Logger.Log("Пользователь согласился на обновление. Начинаем загрузку...");

                                string downloadEndpoint = _endpoint + "/download";
                                string installerPath = Path.Combine(Path.GetTempPath(), versionString + ".exe"); // Путь к установщику

                                await ApiClient.GetDownloadFileAsync(downloadEndpoint, installerPath);
                                ApiClient.StartInstaller(installerPath);

                                Logger.Log("Обновление загружено и запущено. Программа завершает работу.");

                                // Корректное завершение работы программы
                                Environment.Exit(0); // Полностью закрываем программу
                            }
                        }
                        else if (comparisonResult == 0)
                        {
                            Logger.Log("Вы используете последнюю версию программы.");
                        }
                        else
                        {
                            Logger.Log("Вы используете более новую версию программы.");
                        }
                    }
                    else
                    {
                        Logger.ErrorLog($"Не удалось разобрать версию из ответа: {versionString}");
                    }
                }
                catch (Exception ex)
                {
                    Logger.ErrorLog($"Ошибка при получении данных: {ex.Message}");
                }
            }
            else
            {
                Logger.ErrorLog("Ошибка в MainVersion в классе UpdateVersionCheck\n данные равны null");
            }

            return true; // Нет обновления, можно запускать форму
        }
    }
}