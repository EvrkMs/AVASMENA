using ClosedXML.Excel;
using MaterialSkin.Controls;

namespace AVASMENA.Excel
{
    public class ExcelHelperZP : ExcelHelper
    {

        public static Task ZPexcelОтчет(in int zrp1, in int zrp2, in int zrp3, in MaterialComboBox NameBox1, in MaterialComboBox NameBox2, in MaterialComboBox NameBox3, in MaterialTextBox2 MinusBox, in MaterialTextBox2 Minus3)
        {
            if (string.IsNullOrEmpty(Pather) || !File.Exists(Pather))
            {
                Loggers.Logger.ErrorLog("Некорректный путь к файлу или файл не существует.");
                return Task.CompletedTask;
            }

            using (var workbook = new XLWorkbook(Pather))
            {
                ProcessWorksheet(workbook, NameBox1?.Text, zrp1);

                if (MinusBox.Visible && NameBox2 != null)
                {
                    ProcessWorksheet(workbook, NameBox2.Text, zrp2);
                }

                if (Minus3.Visible && NameBox3 != null)
                {
                    ProcessWorksheet(workbook, NameBox3.Text, zrp3);
                }

                workbook.Save();
            }

            return Task.CompletedTask;
        }

        private static void ProcessWorksheet(in XLWorkbook workbook, in string? sheetName, in int amount)
        {
            if (string.IsNullOrEmpty(sheetName)) return;

            var worksheet = workbook.Worksheet(sheetName);

            DateTime now = DateTime.Now;
            string shift = (now.Hour >= 9 && now.Hour < 21) ? "дневная" : "ночная";
            string date = $"{(now.Hour < 9 ? now.AddDays(-1) : now):dd} {shift}";

            var existingRow = worksheet.RowsUsed().FirstOrDefault(row => row.Cell(1).GetString() == date);
            int rowToUpdate = existingRow?.RowNumber() ?? (worksheet.LastRowUsed()?.RowNumber() + 1 ?? 1);

            worksheet.Cell(rowToUpdate, 1).Value = date;
            worksheet.Cell(rowToUpdate, 2).Value = amount;
            worksheet.Cell(2, 3).FormulaA1 = $"=SUM(B:B)";
        }

        public static void UpdateAvansRecord(in XLWorkbook workbook, string name, in int amount)
        {
            var worksheet = workbook.Worksheet($"{DateTime.Now.Year}.{DateTime.Now:MM}");
            var avansRow = worksheet.RowsUsed().FirstOrDefault(row => row.Cell(4).GetString() == $"{name} Аванс");

            if (avansRow != null)
            {
                int currentAmount = avansRow.Cell(3).GetValue<int>();
                avansRow.Cell(3).Value = currentAmount + amount;
            }
            else
            {
                int lastRow = worksheet.LastRowUsed()?.RowNumber() + 1 ?? 1;
                worksheet.Cell(lastRow, 4).Value = $"{name} Аванс";
                worksheet.Cell(lastRow, 3).Value = amount;
            }
        }

        public static Task AvansMinus(in int summ, in string name)
        {
            try
            {
                using var workbook = new XLWorkbook(Pather);
                var worksheet = workbook.Worksheet(name);
                string date = $"{DateTime.Now:dd/MM/HH}";

                int row = worksheet.LastRowUsed()?.RowNumber() + 1 ?? 1;
                worksheet.Cell(row, 1).Value = date;
                worksheet.Cell(row, 2).Value = summ;
                worksheet.Cell(2, 3).FormulaA1 = $"=SUM(B:B)";

                workbook.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            return Task.CompletedTask;
        }

        public static Task ЗаполнениеExcelInvent(in int inventSum, in ListBox listBoxNameInv)
        {
            using (var workbook = new XLWorkbook(Pather))
            {
                foreach (var selectedItem in listBoxNameInv.SelectedItems)
                {
                    string name = selectedItem?.ToString() ?? "Без имени";
                    var worksheet = workbook.Worksheet(name);

                    string date = $"{DateTime.Now:dd/MM/HH}";

                    var existingRow = worksheet.RowsUsed().FirstOrDefault(row => row.Cell(1).GetString() == date);
                    int lastRow = existingRow?.RowNumber() ?? (worksheet.LastRowUsed()?.RowNumber() + 1 ?? 1);

                    worksheet.Cell(lastRow, 1).Value = date;
                    worksheet.Cell(lastRow, 2).Value = inventSum;
                    worksheet.Cell(2, 3).FormulaA1 = $"=SUM(B:B)";
                }

                workbook.Save();
            }
            return Task.CompletedTask;
        }
    }
}