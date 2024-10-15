namespace AVASMENA.Loggers
{
    public static class Logger
    {
        // Путь к файлу лога
        private static readonly string logDirectoryPath = @"C:\Logs";
        private static readonly string logFilePath = $"{logDirectoryPath}\\log.txt";

        static Logger()
        {
            CheackAndCreaterFile();
        }
        public static void CheackAndCreaterFile()
        {
            try
            {
                // Проверяем, существует ли директория, если нет - создаем
                if (!Directory.Exists(logDirectoryPath))
                {
                    Directory.CreateDirectory(logDirectoryPath);
                    Log("Папка для логов создана");
                }
                else
                {
                    Log("Папка для логов есть");
                }
                if (!File.Exists(logFilePath))
                {
                    File.Create(logFilePath);
                    Log("Файл для логов создан");
                }
                else
                {
                    Log("Файл для логов есть");
                }
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException($"Ошиюка с созданием файлов: {ex}");
            }
        }
        public static void Log(string? message)
        {
            try
            {
                // Используем StreamWriter для записи в файл, с добавлением новой строки
                using StreamWriter writer = new(logFilePath, true);
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
            }
            catch (Exception ex)
            {
                // В случае ошибки, выводим сообщение об ошибке в консоль
                MessageBox.Show($"Не удалось записать лог: {ex.Message}");
            }
        }
        public static void ErrorLog(string? message)
        {
            try
            {
                Log($"[ERROR] {message}");
                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                // В случае ошибки, выводим сообщение об ошибке в консоль
                MessageBox.Show($"Не удалось записать лог: {ex.Message}");
            }
        }
    }
}