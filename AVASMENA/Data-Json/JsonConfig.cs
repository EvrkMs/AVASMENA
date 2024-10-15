using Newtonsoft.Json.Linq;
using System.Configuration;

namespace AVASMENA.API.DataStore
{
    public static class JsonConfig
    {
#pragma warning disable CA2211 // Поля, не являющиеся константами, не должны быть видимыми
        public static string? Needed = ConfigurationManager.AppSettings["Folder"];
#pragma warning restore CA2211 // Поля, не являющиеся константами, не должны быть видимыми
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
        private static readonly string? JsonBasePath = Path.Combine(Needed, "config");
        private static readonly string FileData = Path.Combine(JsonBasePath, "User.json");
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

        public static void LoadData()
        {
            LoadUserData();
        }

        private static void LoadUserData()
        {
            try
            {
                if (JsonBasePath == null)
                {
                    Loggers.Logger.ErrorLog("ERROR: не найдена директория с json");
                    return;
                }
                if (!Directory.Exists(JsonBasePath))
                {
                    Directory.CreateDirectory(JsonBasePath);
                }

                if (!File.Exists(FileData))
                {
                    Loggers.Logger.ErrorLog($"Файл {FileData} не найден.");
                }

                string jsonResponse = File.ReadAllText(FileData);
                JObject jsonObject = JObject.Parse(jsonResponse);

                // Загрузка пользователей
                if (jsonObject["users"] is JArray usersArray)
                {
                    foreach (var user in usersArray)
                    {
                        string name = user["name"]?.ToString() ?? string.Empty;
                        long telegramId = user["telegramId"]?.ToObject<long>() ?? LogAndThrow("telegramId");
                        int count = user["count"]?.ToObject<int>() ?? LogAndThrow("count");
                        int zarp = user["zarp"]?.ToObject<int>() ?? LogAndThrow("count");


                        if (!DataStore.NameList.Contains(name))
                        {
                            DataStore.NameList.Add(name);
                        }
                        DataStore.Users[name] = telegramId;
                        DataStore.Names[name] = count;
                        DataStore.ZarpNames[name] = zarp;
                    }
                }
                else
                {
                    Loggers.Logger.ErrorLog("WARNING: Не найдена секция 'users' в JSON-файле.");
                }

                // Загрузка настроек Telegram
                if (jsonObject["telegrams"] is JObject telegramsObject)
                {
                    DataStore.TokenBot = telegramsObject["TokenBot"]?.ToString() ?? LogStringAndThrow("TokenBot");
                    DataStore.ForwardChat = telegramsObject["ForwardChat"]?.ToObject<long>() ?? LogAndThrow("ForwardChat");
                    DataStore.ChatId = telegramsObject["ChatId"]?.ToObject<long>() ?? LogAndThrow("ChatId");
                    DataStore.PhotoChat = telegramsObject["PhotoChat"]?.ToObject<long>() ?? LogAndThrow("PhotoChat");
                    DataStore.TraidSmena = telegramsObject["TraidSmena"]?.ToObject<int>() ?? LogAndThrow("TraidSmena");
                    DataStore.TreidShtraph = telegramsObject["TreidShtraph"]?.ToObject<int>() ?? LogAndThrow("TreidShtraph");
                    DataStore.TraidRashod = telegramsObject["TraidRashod"]?.ToObject<int>() ?? LogAndThrow("TraidRashod");
                    DataStore.TraidPostavka = telegramsObject["TraidPostavka"]?.ToObject<int>() ?? LogAndThrow("TraidPostavka");
                    DataStore.TraidPhoto = telegramsObject["TraidPhoto"]?.ToObject<int>() ?? LogAndThrow("TraidPhoto");
                    DataStore.Password = telegramsObject["Password"]?.ToObject<string>() ?? LogAndThrow("Password").ToString();
                }
                else
                {
                    Loggers.Logger.ErrorLog("WARNING: Не найдена секция 'telegrams' в JSON-файле.");
                }
            }
            catch (Exception ex)
            {
                Loggers.Logger.ErrorLog($"Ошибка при загрузке данных из {FileData}: {ex.Message}");
            }
        }
        private static int LogAndThrow(string? message)
        {
            message = message + "не найден в конфигурации или имеет недопустимое значение." ?? string.Empty;
            Loggers.Logger.ErrorLog(message);
            return -1;
        }
        private static string LogStringAndThrow(string? message)
        {
            message = message + "не найден в конфигурации или имеет недопустимое значение." ?? string.Empty;
            Loggers.Logger.ErrorLog(message);
            return string.Empty;
        }
    }
}