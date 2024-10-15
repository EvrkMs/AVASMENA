using AVASMENA.Excel;
using AVASMENA.API.DataStore;

namespace AVASMENA.MainForms
{
    public partial class MainForm
    {
        private static int nalf, bnf, nalp, bnp, seyf, minus1, minus2, minus3, hours1, hours2, hours3, minusSeyf, minus, minusAndSeyf, SeyfExcel, zp, haurs, zp4, seyfEnd, viruchka, itog, zarp1, zarp2, zarp3, zp2, zp3;
        private static string? name, name2, name3;

        private (int SeyfExcel, int nalf, int bnf, int nalp, int bnp, int seyf, int minus, int zp, int zp2, int zp3, int haurs, int zp4, int seyfEnd, int viruchka, int itog, int zarp1, int zarp2, int zarp3, string name, string name2, string name3, int minus1, int minus2, int minus3, int minusSeyf, int minusAndSeyf) GetValues()
        {
            SeyfExcel = ExcelHelper.GetCellValueAsInt("s", "seyf", 1);
            name = NameComboBoxOtchet.Text;
            name2 = SecondComboBoxNameOtchet.Text;
            name3 = ThertyComboBox.Text;

            // Парсинг значений
            nalf = ParseTextBoxValue(textBox2.Text);
            bnf = ParseTextBoxValue(textBox3.Text);
            nalp = ParseTextBoxValue(textBox4.Text);
            bnp = ParseTextBoxValue(textBox5.Text);
            seyf = ParseTextBoxValue(textBox7.Text);
            minus1 = ParseTextBoxValue(Minus1.Text);
            minus2 = ParseTextBoxValue(Minus2.Text);
            minus3 = ParseTextBoxValue(Minus3.Text);
            hours1 = ParseTextBoxValue(HaursBox1.Text);
            hours2 = ParseTextBoxValue(HaursBox2.Text);
            hours3 = ParseTextBoxValue(HaursBox3.Text);

            // Расчёты
            minusSeyf = CalculatCheackSeyf(SeyfExcel, seyf);
            minus = CalculateMinus(nalf, nalp, bnf, bnp);
            minusAndSeyf = minusSeyf < -20 ? minus + minusSeyf : minus;

            zp = DataStore.ZarpNames[name];
            zp2 = DataStore.ZarpNames[name];
            zp3 = DataStore.ZarpNames[name];

            haurs = hours1 + hours2 + hours3;
            zp4 = CalculateFinalZp(zp, haurs, minusAndSeyf);

            seyfEnd = seyf + nalf - 1000;
            viruchka = nalf + bnf - 1000;
            itog = viruchka - zp4;

            zarp1 = CalculateZarp(hours1, zp, GetAdjustedMinus(Minus1.Visible, minusAndSeyf, minus1));
            zarp2 = CalculateZarp(hours2, zp2, minus2);
            zarp3 = CalculateZarp(hours3, zp3, minus3);

            return (SeyfExcel, nalf, bnf, nalp, bnp, seyf, minus, zp, zp2, zp3, haurs, zp4, seyfEnd, viruchka, itog, zarp1, zarp2, zarp3, name, name2, name3, minus1, minus2, minus3, minusSeyf, minusAndSeyf);
        }

        // Парсинг значения из текстбокса
        private static int ParseTextBoxValue(string textBoxValue)
        {
            return int.TryParse(textBoxValue, out int value) ? value : 0;
        }

        private static int CalculatCheackSeyf(in int SeyfExcel, in int seyf)
        {
            return seyf - SeyfExcel;
        }

        private static int CalculateMinus(in int nalf, in int nalp, in int bnf, in int bnp)
        {
            int minus = (nalf - nalp) + (bnf - bnp);
            return minus > 0 ? 0 : minus;
        }

        private static int CalculateZarp(in int hours, in int zp, in int minus)
        {
            return zp * hours - minus;
        }

        private static int CalculateFinalZp(in int zp, in int haurs, in int minusAndSeyf)
        {
            return zp * haurs + (minusAndSeyf > 0 ? 0 : minusAndSeyf);
        }

        // Метод для определения корректного значения штрафа
        private static int GetAdjustedMinus(bool isMinusVisible, in int minusAndSeyf, in int minus)
        {
            return isMinusVisible ? minus : minusAndSeyf * -1;
        }

        private static int CalculateShtraph(int syu)
        {
            if (syu > 0)
                return syu *= -1;
            return syu;
        }
    }
}