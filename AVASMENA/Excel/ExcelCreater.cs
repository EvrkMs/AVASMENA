using ClosedXML.Excel;

namespace AVASMENA.Excel
{
    public class ExcelHelperCreater : ExcelHelper
    {
        public static void ExcelCreat(in List<string> nameList)
        {
            if (FolderPath != null && Pather != null && PatherSeyf != null)
            {
                ExcelCreatDirectory(FolderPath);
                CheackCreat(Pather, true, nameList);
                CheackCreat(PatherSeyf, false);
            }
        }
        private static void ExcelCreatDirectory(in string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }
        private static void CheackCreat(in string path, bool name, in List<string>? names = null)
        {
            if (!File.Exists(path))
            {
                CreateFile(path, name, true, names);
            }
            else
            {
                CreateFile(path, name, false, names);
            }
        }
        private static void CreateFile(in string path, bool name, in bool _new, List<string>? names = null)
        {
            if (_new)
            {
                using XLWorkbook wb = new();
                CheackFileData(wb, name, names);
                wb.SaveAs(path);
            }
            else
            {
                using XLWorkbook wb = new(path);
                CheackFileData(wb, name, names);
                wb.Save();
            }
        }
        private static void CheackFileData(XLWorkbook wb, in bool _name, in List<string>? names)
        {
            if (names != null && _name == true)
            {
                foreach (string name in names)
                {
                    if (!wb.Worksheets.TryGetWorksheet(name, out _))
                    {
                        wb.Worksheets.Add(name);
                    }
                    if (!wb.Worksheets.TryGetWorksheet("All", out _))
                    {
                        wb.Worksheets.Add("All");
                    }
                    IXLWorksheet? sheet = wb.Worksheet(name);
                    IXLWorksheet? sheetAll = wb.Worksheet("All");
                    SheetListCreater(sheet);
                    AllName(name, sheetAll);
                }

                return;
            }

            if (!wb.Worksheets.TryGetWorksheet("seyf", out _))
            {
                wb.Worksheets.Add("seyf");
            }
            IXLWorksheet? sheetS = wb.Worksheet("seyf");
            SheetListCreater(sheetS);
        }
        private static void AllName(string name, IXLWorksheet sheet)
        {
            if (!ColumnContainsData(sheet, 2, name))
            {
                int row = GetFirstEmptyRow(sheet);
                sheet.Cell(row, 2).Value = name;
                sheet.Cell(row, 1).FormulaA1 = $"='{name}'!C2";
            }
            AutoFitColumnsAndRows(sheet);
        }
        private static void SheetListCreater(IXLWorksheet sheet)
        {
            // Проверяем и заполняем ячейки, если они пустые
            CeackAndCreater(sheet, 1, 1, "Дата");

            CeackAndCreater(sheet, 1, 2, "Суммы");

            CeackAndCreater(sheet, 1, 3, "Суммы");

            CeackAndCreater(sheet, 2, 2, "0");

            if (sheet.Cell(2, 3).IsEmpty())
            {
                sheet.Cell(2, 3).FormulaA1 = "=SUM(B:B)";
            }
            AutoFitColumnsAndRows(sheet);
        }
        private static void CeackAndCreater(IXLWorksheet sheet, int column, int row, string value)
        {
            if (sheet.Cell(column, row).IsEmpty())
            {
                sheet.Cell(column, row).Value = value;
            }
        }
    }
}