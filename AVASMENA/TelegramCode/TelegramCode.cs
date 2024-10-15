using AVASMENA.API.DataStore;
using AVASMENA.Excel;
using AVASMENA.Loggers;
using AVASMENA.MainForms.Designer;
using MaterialSkin.Controls;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AVASMENA.TelegramCode
{
    public static class Telegrame
    {
        private static readonly Dictionary<string, int> UserOffsets = []; // Обновлено на корректную инициализацию словаря
        private static bool _isSending = false;
        private static ITelegramBotClient? Bot;

        static Telegrame()
        {
            LoadData();
        }
        private static void LoadData()
        {
            DataStore.Initialize();
        }
        private static string DataStoreTokenBotReturn()
        {
            if (string.IsNullOrEmpty(DataStore.TokenBot))
            {
                // Используем более конкретное исключение и предоставляем информацию об ошибке
                var errorMessage = "Ошибка токена: TokenBot в DataStore не установлен.";
                Logger.ErrorLog(errorMessage);
                throw new InvalidOperationException(errorMessage);
            }
            return DataStore.TokenBot;
        }
        public async static void DeleteWebhookAsync(ThisListBox listBox)
        {
            Bot = new TelegramBotClient(DataStoreTokenBotReturn());
            try
            {
                await Bot.DeleteWebhookAsync();
                listBox.Invoke((MethodInvoker)delegate
                {
                    listBox.Items.Add("Webhook removed.");
                });
            }
            catch (Exception ex)
            {
                listBox.Invoke((MethodInvoker)delegate
                {
                    listBox.Items.Add($"Error removing webhook: {ex.Message}");
                });
            }
        }
        public static async Task ProcessUpdates(long userId, int treadId, string selectedName, ListBox listBox, MaterialButton button)
        {
            Bot = new TelegramBotClient(DataStoreTokenBotReturn());
            int offset = UserOffsets.GetValueOrDefault(selectedName, 0);
            DateTime requestTimestamp = DateTime.UtcNow;
            var photosToBeSent = new List<IAlbumInputMedia>();

            if (_isSending)
            {
                ShowInListBox(listBox, "Отчет в процессе отправки. Пожалуйста, дождитесь окончания работы таймера.");
                return;
            }
            if (string.IsNullOrWhiteSpace(selectedName) || !DataStore.Users.ContainsKey(selectedName))
            {
                ShowErrorAndEnableButton("Вы забыли выбрать имя из выпадающего списка или пользователь не существует.", button);
                return;
            }

            DisableButtonAndClearList(button, listBox, $"Запрос отправлен в {DateTime.Now:T}", "Ожидание фотографий. Пожалуйста, отправьте фотографии...");

            await Bot.SendTextMessageAsync(userId, "Ожидаю ваши фотографии...");

            while (true)
            {
                var updates = await Bot.GetUpdatesAsync(offset: offset, timeout: 1);
                photosToBeSent.Clear();

                foreach (var update in updates)
                {
                    if (update.Message?.Photo != null && update.Message.Chat.Id == userId && update.Message.Date > requestTimestamp)
                    {
                        string fileId = update.Message.Photo.Last().FileId;
                        photosToBeSent.Add(new InputMediaPhoto(new InputFileId(fileId)));
                    }

                    offset = updates.Max(u => u.Id) + 1;
                    UserOffsets[selectedName] = offset;
                }

                if (photosToBeSent.Count != 0)
                {
                    await SendPhotosAsync(photosToBeSent, listBox, treadId);
                    break;
                }

                await Task.Delay(1000);
            }

            EnableButtonAndResetState(button);
        }
        public static async Task SendMessageAsync(int zap1, int zap2, int zap3, string name, string name2, string name3, MaterialButton button)
        {
            Bot = new TelegramBotClient(DataStoreTokenBotReturn());

            if (string.IsNullOrWhiteSpace(name))
                return;

            string currentDate = DateTime.Now.ToString("yyyy.MM.dd");
            await SendZpMessageAsync(name, zap1, currentDate);

            if (!string.IsNullOrWhiteSpace(name2) && name2 != "нет")
            {
                await SendZpMessageAsync(name2, zap2, currentDate);
            }

            if (!string.IsNullOrWhiteSpace(name3) && name3 != "нет")
            {
                await SendZpMessageAsync(name3, zap3, currentDate);
            }

            EnableButtonAndResetState(button);
        }
        public static async Task SendMessageToSelectedNamesAsync(List<string> selectedNames, string message)
        {
            Bot = new TelegramBotClient(DataStoreTokenBotReturn());

            int valuse;
            foreach (var name in selectedNames)
            {
                if (DataStore.Names.TryGetValue(name, out int id))
                {
                    valuse = ExcelHelper.GetCellValueAsInt("ZP", name);
                    await Bot.SendTextMessageAsync(DataStore.ChatId, message + valuse, replyToMessageId: id);
                }
            }
        }
        private static async Task SendZpMessageAsync(string name, int zap, string date)
        {
            Bot = new TelegramBotClient(DataStoreTokenBotReturn());

            if (DataStore.Names.TryGetValue(name, out int tradeId))
            {
                int value = ExcelHelper.GetCellValueAsInt("ZP", name);
                string message = $"{date}\n+{zap}p\n теперь: {value}";
                await Bot.SendTextMessageAsync(DataStore.ChatId, message, replyToMessageId: tradeId);
            }
        }
        private static async Task SendPhotosAsync(List<IAlbumInputMedia> photos, ListBox listBox, int treadId)
        {
            Bot = new TelegramBotClient(DataStoreTokenBotReturn());

            ShowInListBox(listBox, $"Получено {photos.Count} фотографий. Отправляю в чат...");
            await Bot.SendMediaGroupAsync(DataStore.ForwardChat, photos, replyToMessageId: treadId);
            ShowInListBox(listBox, $"Отправлено {photos.Count} фотографий в чат.");
        }
        private static void DisableButtonAndClearList(MaterialButton button, ListBox listBox, params string[] messages)
        {
            button.Enabled = false;
            listBox.Items.Clear();
            foreach (var message in messages)
            {
                listBox.Items.Add(message);
            }
        }
        private static void ShowErrorAndEnableButton(string errorMessage, MaterialButton button)
        {
            MessageBox.Show(errorMessage);
            _isSending = false;
            button.Enabled = true;
        }
        private static void ShowInListBox(ListBox listBox, string message)
        {
            listBox.Invoke((MethodInvoker)delegate
            {
                listBox.Items.Add(message);
            });
        }
        private static void EnableButtonAndResetState(MaterialButton button)
        {
            _isSending = false;
            button.Enabled = true;
        }
        public static async Task SendPhoto(string filePath, string name)
        {
            Bot = new TelegramBotClient(DataStoreTokenBotReturn());
            if (name != "All")
            {
                if (DataStore.Names.TryGetValue(name, out int tradeId))
                {
                    using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    await Bot.SendPhotoAsync(DataStore.ChatId, new InputFileStream(stream), replyToMessageId: tradeId);
                }
            }
            else if (name == "seyf")
            {
                using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                await Bot.SendPhotoAsync(DataStore.ForwardChat, new InputFileStream(stream), replyToMessageId: 1);
            }
            else
            {
                using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                await Bot.SendPhotoAsync(DataStore.ChatId, new InputFileStream(stream), replyToMessageId: 1);
            }
        }
    }
}