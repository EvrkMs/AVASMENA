using AVASMENA.API.DataStore;
using AVASMENA.Loggers;
using MaterialSkin.Controls;

namespace AVASMENA.MainForms
{
    public partial class MainForm
    {
        private const string ShtraphFilePath = "files\\shtraph.txt";

        public static void SetupComboBoxes(params MaterialComboBox[] Box)
        {
            foreach (var box in Box)
            {
                foreach (var name in DataStore.NameList)
                {
                    box.Items.Add(name);
                }
            }
        }
        public static void InitializeListBox(in ListBox box)
        {
            foreach (var name in DataStore.NameList)
            {
                box.Items.Add(name);
            }
            box.SelectionMode = SelectionMode.MultiExtended; // Разрешить множественный выбор
        }
        public static void LoadItemsToListBox(in ListBox list)
        {
            try
            {
                string[] lines = File.ReadAllLines(ShtraphFilePath);
                list.Items.Clear();
                foreach (string line in lines)
                {
                    list.Items.Add(line);
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorLog($"Ошибка при загрузке пунктов из файла {ShtraphFilePath}: {ex.Message}");
            }
        }
        public static void RemoveTabPage(in MaterialTabControl TabC, in List<TabPage> tabs)
        {
            foreach (var tab in tabs)
            {
                if (TabC.TabPages.Contains(tab))
                    TabC.TabPages.Remove(tab);
            }
        }
        public static void PasswordBoxText(in MaterialTextBox2 PasswordBox, in bool i)
        {
            PasswordBox.Visible = i;
        }
        public static void ShtraphBox(in ListBox listBox4, in ListBox listBox5)
        {
            listBox4.BeginUpdate(); // Начать обновление listBox4

            listBox4.Items.Clear(); // Очистить все элементы listBox4

            string opisanie = ""; // Переменная для хранения описания
            foreach (var item in listBox5.SelectedItems)
            {
                opisanie += item.ToString() + "\n"; // Добавляем текущий элемент с символом новой строки
                listBox4.Items.Add(item); // Добавляем выбранный элемент в listBox4
            }

            listBox4.EndUpdate(); // Завершить обновление listBox4
        }
    }
}