using AVASMENA.API;
using AVASMENA.API.DataStore;
using AVASMENA.Loggers;
using ClosedXML.Excel;
using Newtonsoft.Json.Linq;
using Telegram.Bot;

namespace AVASMENA.Excel
{
    public partial class ExcelHelper
    {
        public static string? FolderPath { get; private set; }
        public static string? PatherSeyf { get; private set; }
        public static string? Pather { get; private set; }
        public static ITelegramBotClient? bot;

        static ExcelHelper()
        {
            LoadData();
            if (JsonConfig.Needed != null)
            {
                FolderPath = Path.Combine(JsonConfig.Needed, "Excel");
                PatherSeyf = Path.Combine(FolderPath, "seyf.xlsx");
                Pather = Path.Combine(FolderPath, "ZP.xlsx");
            }
        }
        private static void LoadData()
        {
            DataStore.Initialize();
            if (!Directory.Exists(FolderPath) && FolderPath != null)
            {
                Directory.CreateDirectory(FolderPath);
            }
        }

        public static Task SeyfMinus(in int plusSeyf, in int? i = null)
        {
            try
            {
                using var workbook = new XLWorkbook(PatherSeyf);
                var worksheet = workbook.Worksheet("seyf");
                DateTime now = DateTime.Now;
                string date;
                if (i != null)
                {
                    string shift = (now.Hour >= 9 && now.Hour < 21) ? "ночная" : "дневная";
                    date = $"{(now.Hour < 9 ? now.AddDays(-1) : now):dd} {shift}";
                }
                else
                {
                    date = $"{DateTime.Now: MM.dd HH:mm}";
                }
                // Проверка существования строки с текущей датой
                var existingRow = worksheet.RowsUsed().FirstOrDefault(row => row.Cell(1).GetString() == date);

                if (existingRow != null)
                {
                    existingRow.Cell(2).Value = plusSeyf;
                }
                else
                {
                    int row = worksheet.LastRowUsed().RowNumber() + 1;
                    worksheet.Cell(row, 1).Value = date;
                    worksheet.Cell(row, 2).Value = plusSeyf;
                }
                worksheet.Cell(2, 3).FormulaA1 = $"=SUM(B:B)";

                workbook.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            return Task.CompletedTask;
        }
        public static int GetCellValueAsInt(string fileName, string sheetName, int? i = null)
        {
            // Запуск асинхронного метода в отдельном потоке и ожидание его завершения
            int result = Task.Run(() => GetCellValueAsIntAsync(fileName, sheetName, i)).GetAwaiter().GetResult();
            return result;
        }
        private static async Task<int> GetCellValueAsIntAsync(string fileName, string sheetName, int? i = null)
        {
            // Формируем базовый URL
            string endpoint = $"api/Excel/GetCellValue?fileName={fileName}&sheetName={sheetName}";

            // Если параметр i передан, добавляем его к запросу
            if (i.HasValue)
            {
                endpoint += $"&i={i.Value}";
            }

            // Получаем JObject через метод GetJsonDataSync
            JObject jsonObject = await ApiClient.GetJsonDataSync(endpoint);

            // Логируем полученный JSON для отладки
            Logger.Log("Полученный JSON ответ: " + jsonObject.ToString());

            // Извлекаем значение по ключу "value"
            if (jsonObject.TryGetValue("value", out JToken value))
            {
                if (int.TryParse(value.ToString(), out int intValue))
                {
                    return intValue;
                }
                else
                {
                    Logger.ErrorLog("Ошибка: значение 'value' не является числом.");
                    throw new ArgumentException("Значение 'value' не является числом.");
                }
            }
            else
            {
                Logger.ErrorLog("Ошибка: ключ 'value' не найден в JSON объекте.");
                throw new KeyNotFoundException("Ключ 'value' не найден в JSON объекте.");
            }
        }



        public static void AutoFitColumnsAndRows(IXLWorksheet worksheet)
        {
            worksheet.Columns().AdjustToContents(); // Автоматическое подстраивание ширины столбцов
            worksheet.Rows().AdjustToContents(); // Автоматическое подстраивание высоты строк
        }
        public static int GetFirstEmptyRow(IXLWorksheet worksheet)
        {
            int row = 1;
            while (!worksheet.Cell(row, 2).IsEmpty())
            {
                row++;
            }
            return row;
        }
        public static bool ColumnContainsData(IXLWorksheet worksheet, int columnIndex, string data)
        {
            foreach (var cell in worksheet.Column(columnIndex).CellsUsed())
            {
                if (cell.GetValue<string>() == data)
                {
                    return true;
                }
            }
            return false;
        }
    }
}