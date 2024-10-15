using AVASMENA.Loggers;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Diagnostics;

namespace AVASMENA.API
{
    public static class ApiClient
    {
        private static readonly HttpClient _httpClient;
        private static readonly string? _apiKey;

        static ApiClient()
        {
            var apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
            _apiKey = ConfigurationManager.AppSettings["ApiKey"];

            if (apiUrl != null && _apiKey != null)
            {
                _httpClient = new HttpClient
                {
                    BaseAddress = new Uri(apiUrl)
                };
                // Устанавливаем заголовок X-API-KEY
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("X-API-KEY", _apiKey);
            }
            else
            {
                Logger.ErrorLog("Ошибка с данными в конфигурации API подключения");
                throw new InvalidOperationException("Конфигурация API неверна");
            }
        }


        public static async Task<JObject> GetJsonDataSync(string endpoint)
        {
            return await GetJsonDataAsync(endpoint);
        }
        public static async Task GetDownloadFileAsync(string downloadEndpoint, string outputFilePath)
        {
            await DownloadUpdateAsync(downloadEndpoint, outputFilePath);
        }

        private static async Task<JObject> GetJsonDataAsync(string endpoint)
        {
            if (endpoint == null)
            {
                Logger.ErrorLog("Endpoint для запроса равен null");
                throw new ArgumentNullException(nameof(endpoint));
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    Logger.ErrorLog($"Ошибка при выполнении HTTP запроса: {response.StatusCode} {response.ReasonPhrase}");
                    response.EnsureSuccessStatusCode();
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JObject.Parse(jsonResponse);
            }
            catch (HttpRequestException httpEx)
            {
                Logger.ErrorLog($"Ошибка при выполнении HTTP запроса: {httpEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Logger.ErrorLog($"Произошла ошибка: {ex.Message}");
                throw;
            }
        }

        private static async Task DownloadUpdateAsync(string downloadEndpoint, string outputFilePath)
        {
            if (downloadEndpoint == null || outputFilePath == null)
            {
                Logger.ErrorLog("Endpoint или путь для скачивания равны null");
                throw new ArgumentNullException(downloadEndpoint == null ? nameof(downloadEndpoint) : nameof(outputFilePath));
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(downloadEndpoint);

                if (!response.IsSuccessStatusCode)
                {
                    Logger.ErrorLog($"Ошибка при выполнении HTTP запроса: {response.StatusCode} {response.ReasonPhrase}");
                    response.EnsureSuccessStatusCode();
                }

                using (var fileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await response.Content.CopyToAsync(fileStream);
                }

                Logger.Log($"Обновление загружено и сохранено в: {outputFilePath}");
            }
            catch (HttpRequestException httpEx)
            {
                Logger.ErrorLog($"Ошибка при скачивании обновления: {httpEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Logger.ErrorLog($"Произошла ошибка: {ex.Message}");
                throw;
            }
        }

        public static void StartInstaller(string installerPath)
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = installerPath,
                    Arguments = "", // Добавьте аргументы, если необходимо
                    UseShellExecute = true // Используем ShellExecute для запуска установщика
                };

                using var process = Process.Start(processInfo);
                if (process != null)
                {
                    process.WaitForExit(); // Ждем завершения процесса установки
                    Logger.Log("Установщик завершил свою работу.");
                }
                else
                {
                    Logger.ErrorLog("Не удалось запустить установщик.");
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorLog($"Ошибка при запуске установщика: {ex.Message}");
                throw;
            }
        }
    }
}