using AVASMENA.API.DataStore;
using AVASMENA.TelegramCode;
using ClosedXML.Excel;
using System.Drawing.Imaging;
using Color = System.Drawing.Color;
using File = System.IO.File;

namespace AVASMENA.Excel
{
    public class ExcelHelperPhoto : ExcelHelper
    {
        // Основной метод для создания снимка указанного диапазона
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rangeAddress">Диапозон фотографии</param>
        /// <param name="nameFile">какой файл надо фоткать</param>
        /// <param name="sheetName">Имя листа</param>
        /// <param name="topic">топик чата</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static async Task ScreenExcelRange(string rangeAddress, string nameFile, string sheetName)
        {
            string? _folderPath = FolderPath;
            if (FolderPath == null)
            {
                string message = "Ошибка в отпарвке фотографии, путь не наеден";
                Loggers.Logger.ErrorLog(message);
                throw new InvalidOperationException(message);
            }
            string path = Path.Combine(FolderPath, nameFile);
            Loggers.Logger.Log("Метод ScreenExcelRange вызван.");

            try
            {
                Loggers.Logger.Log($"Проверка существования файла: {path}");
                if (!File.Exists(path))
                {
                    Loggers.Logger.ErrorLog($"Файл не найден: {path}");
                    return;
                }

                using var workbook = new XLWorkbook(path);
                var worksheet = workbook.Worksheets.FirstOrDefault(ws => ws.Name == sheetName);
                if (worksheet == null)
                {
                    Loggers.Logger.ErrorLog($"Лист с именем '{sheetName}' не найден.");
                    return;
                }

                // Получение указанного диапазона ячеек
                var range = worksheet.Range(rangeAddress);
                if (range == null)
                {
                    Loggers.Logger.ErrorLog($"Диапазон '{rangeAddress}' не найден.");
                    return;
                }

                // Удаление пустых строк из диапазона
                var cleanedRange = RemoveEmptyRows(range);

                // Обработка данных рабочего листа и сохранение в изображение
                var columnWidths = CalculateColumnWidths(cleanedRange, new Font("Segoe UI", 12));
                var cellHeight = new Font("Segoe UI", 12).Height + 10;

                var outputFilePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.png");
                SaveRangeAsImage(cleanedRange, outputFilePath, columnWidths, cellHeight);

                // Отправка изображения в Telegram
                Loggers.Logger.Log("Отправка изображения в Telegram.");
                if (DataStore.TokenBot != null)
                {
                    await Telegrame.SendPhoto(outputFilePath, sheetName);

                    // Удаление временного файла после отправки
                    if (File.Exists(outputFilePath))
                    {
                        File.Delete(outputFilePath);
                        Loggers.Logger.Log("Временный файл изображения удален.");
                    }
                }
                else
                {
                    Loggers.Logger.ErrorLog("Ошибка токена");
                }
            }
            catch (Exception ex)
            {
                Loggers.Logger.ErrorLog($"Произошла ошибка: {ex.Message}");
                Loggers.Logger.ErrorLog(ex.StackTrace);
            }
        }

        // Метод для удаления пустых строк из диапазона
        private static IXLRange RemoveEmptyRows(IXLRange range)
        {
            var nonEmptyRows = range.Rows().Where(row => !row.IsEmpty()).ToList();
            return range.Worksheet.Range(nonEmptyRows.First().RowNumber(), range.FirstColumn().ColumnNumber(),
                                         nonEmptyRows.Last().RowNumber(), range.LastColumn().ColumnNumber());
        }

        // Метод для вычисления ширины колонок
        private static int[] CalculateColumnWidths(IXLRange range, Font font)
        {
            int width = range.ColumnCount();
            int height = range.RowCount();
            int[] columnWidths = new int[width];

            using (Bitmap tempBitmap = new(1, 1))
            using (Graphics tempGraphics = Graphics.FromImage(tempBitmap))
            {
                for (int col = 1; col <= width; col++)
                {
                    int maxWidth = 0;
                    for (int row = 1; row <= height; row++)
                    {
                        string cellValue = range.Cell(row, col).GetFormattedString();
                        SizeF textSize = tempGraphics.MeasureString(cellValue, font);
                        maxWidth = Math.Max(maxWidth, (int)textSize.Width);
                    }
                    columnWidths[col - 1] = maxWidth + 10;
                }
            }

            return columnWidths;
        }

        // Метод для отрисовки и сохранения данных рабочего листа
        private static void SaveRangeAsImage(IXLRange range, string filePath, int[] columnWidths, int cellHeight)
        {
            try
            {
                int totalWidth = columnWidths.Sum();
                int totalHeight = range.RowCount() * cellHeight;

                using Bitmap dataBitmap = new(totalWidth, totalHeight);
                using Graphics graphics = Graphics.FromImage(dataBitmap);
                graphics.Clear(Color.White);
                DrawWorksheetData(graphics, range, columnWidths, new Font("Arial", 12), cellHeight);
                dataBitmap.Save(filePath, ImageFormat.Png);
                Loggers.Logger.Log($"Изображение данных таблицы сохранено: {filePath}");
            }
            catch (Exception ex)
            {
                Loggers.Logger.ErrorLog($"Ошибка при сохранении изображения данных таблицы: {ex.Message}");
            }
        }

        // Метод для отрисовки данных рабочего листа
        private static void DrawWorksheetData(Graphics graphics, IXLRange range, int[] columnWidths, Font font, int cellHeight)
        {
            int xOffset = 0;
            int width = range.ColumnCount();
            int height = range.RowCount();

            for (int col = 1; col <= width; col++)
            {
                int yOffset = 0;
                for (int row = 1; row <= height; row++)
                {
                    var cell = range.Cell(row, col);
                    string cellValue = cell.GetFormattedString();
                    var cellRect = new RectangleF(xOffset, yOffset, columnWidths[col - 1], cellHeight);

                    if (cell.Style.Fill.BackgroundColor.ColorType == XLColorType.Color)
                    {
                        var backgroundColor = XLColorToColor(cell.Style.Fill.BackgroundColor);
                        using Brush brush = new SolidBrush(backgroundColor);
                        graphics.FillRectangle(brush, cellRect);
                    }

                    graphics.DrawString(cellValue, font, Brushes.Black, cellRect);
                    yOffset += cellHeight;
                }
                xOffset += columnWidths[col - 1];
            }
        }

        private static Color XLColorToColor(XLColor xlColor)
        {
            return Color.FromArgb(xlColor.Color.ToArgb());
        }
    }
}