#pragma warning disable CA1806
#pragma warning disable IDE0042 // Деконструировать объявление переменной
using AVASMENA.API.DataStore;
using AVASMENA.Excel;
using AVASMENA.TelegramCode;
using MaterialSkin.Controls;
using System.Data;
using System.Text;
using Telegram.Bot;
using Timer = System.Windows.Forms.Timer;

namespace AVASMENA.MainForms
{
    public partial class MainForm : MaterialForm
    {
        //по форме
        private readonly Timer timer = new();
        // Установите ваш пароль здесь
        private static string CorrectPassword;
        private bool RemoveDa = false;
        public List<TabPage>? _RootList;
        public List<TabPage>? _Auth;
        private static ITelegramBotClient? bot;
        private static bool Cheacked;
        private static bool Loading = true;

        public MainForm()
        {
            InitializeMaterialSkin();
            InitializeComponent();
            LoadData();
            InitializeUI();
        }
        private void InitializeUI()
        {
            //лист вкладок доступных только админу
            _RootList = [ShtraphPage, InventPage, AvansPage];
            //вкладка аунтификации
            _Auth = [AutherPage];
            //лист текстов
            LoadItemsToListBox(listBox5);

            SecondComboBoxNameOtchet.Items.Add("нет");
            WhoVipisl.Items.Add("нет");
            ThertyComboBox.Items.Add("нет");
            LoginBox.Text = "Admin";
            InitializeListBox(listBoxNameInv);
            SetupComboBoxes(NameComboBoxOtchet, KomuVipisal, materialComboBox2, SecondComboBoxNameOtchet, WhoVipisl, comboBoxNameRas, ThertyComboBox);
            SetupTimer();
        }

        private static void LoadData()
        {
            DataStore.Initialize();
            if (DataStore.Password != null)
            {
                CorrectPassword = DataStore.Password;
            }
            else
            {
                MessageBox.Show("В файле конфигурации упущен пункт пароля");
            }
        }
        public void LoginBox_SelectedIndex(object sender, EventArgs e)
        {
            if (LoginBox.Text == "Root")
                PasswordBoxText(PasswordTextBox, true);
            else
                PasswordBoxText(PasswordTextBox, false);
        }
        private void Logining()
        {
            if (IsPasswordRequired() && !IsPasswordCorrect())
            {
                MessageBox.Show("Incorrect password");
                return;
            }
            UpdateTabControlForUser();
            if (_Auth != null)
                RemoveAuthTabs(materialTabControl1, _Auth);
            HideShowSelector(materialTabSelector1, true);
            ExitBtn.Visible = true;
        }
        private bool IsPasswordRequired()
        {
            return PasswordTextBox.Visible;
        }
        private bool IsPasswordCorrect()
        {
            return PasswordTextBox.Text == CorrectPassword;
        }
        private void UpdateTabControlForUser()
        {
            if (LoginBox.Text == "Admin")
            {
                RemoveDa = true;
                if (_RootList != null)
                {
                    RemoveTabPage(materialTabControl1, _RootList);
                }
            }
            materialTabControl1.SelectedTab = OtchetPage;
        }
        private static void RemoveAuthTabs(in MaterialTabControl control, in List<TabPage> _Auth)
        {
            RemoveTabPage(control, _Auth);
        }
        private static void HideShowSelector(in MaterialTabSelector TabSel, in bool i)
        {
            TabSel.Visible = i;
        }
        private void RestoreTabs()
        {
            if (RemoveDa == true)
            {
                if (_RootList != null)
                {
                    foreach (var tab in _RootList)
                    {
                        materialTabControl1.TabPages.Add(tab);
                    }
                }
            }
        }
        private async static void SendPhotoExcelZp()
        {
            foreach (string name in DataStore.NameList)
                await ExcelHelperPhoto.ScreenExcelRange("A1:C64", "ZP", name);
        }
        private async static void SendPhotoExcelSeyfAndAll()
        {
            await ExcelHelperPhoto.ScreenExcelRange("A1:C64", "ZP", "All");
            await ExcelHelperPhoto.ScreenExcelRange("A1:C64", "seyf", "seyf");
        }
        private void SetupTimer()
        {
            timer.Interval = 30000;
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            Отправить.Enabled = true;
            timer.Stop();
        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            List<MaterialCheckbox> list = [AvansCheack, ZPcheak, MinusPoSeyf, Premia, Otpusknie];
            CheckBoxUpdateInPagesAvans(sender, list);
        }
        private void ListBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShtraphBox(listBox4, listBox5);
        }
        private void CheakPlsHaurs()
        {
            if (HaursBox1 == null || HaursBox2 == null || HaursBox3 == null)
            {
                MessageBox.Show("Укажи сначало отработанное время, пожадуйста(а то будет ошибка)");
                return;
            }
        }
        private void ChengedHaurs(object sender, EventArgs e)
        {
            // Преобразуем текстовые значения в числа
            int.TryParse(HaursBox1.Text, out int hours1);
            int.TryParse(HaursBox2.Text, out int hours2);
            int.TryParse(HaursBox3.Text, out int hours3);
            if (hours1 + hours2 + hours3 > 12)
            {
                MessageMaxHaurs();
                return;
            }
        }
        private void MessageMaxHaurs()
        {
            ResetHours();
            MessageBox.Show("Борщанул с часами, указываешь меньше часов чем дозволено (12 часов)");
        }
        private void ResetHours()
        {
            // Сбрасываем значения текстбоксов в 0
            HaursBox1.Text = "0";
            HaursBox2.Text = "0";
            HaursBox3.Text = "0";
        }
        private void MethodSekectedIndex(object sender, EventArgs e)
        {
            if (sender == null) return;
            if (sender == SecondComboBoxNameOtchet)
                if (SecondComboBoxNameOtchet.SelectedItem != null && SecondComboBoxNameOtchet.SelectedItem.ToString() != "нет")
                {
                    VisibleBox(true);
                }
                else
                {
                    VisibleBox(false);
                }
            if (sender == ThertyComboBox)
                if (ThertyComboBox.SelectedItem != null && ThertyComboBox.SelectedItem.ToString() != "нет")
                {
                    VisibleBox3(true);
                }
                else
                {
                    VisibleBox3(false);
                }
        }
        private void VisibleBox(bool i)
        {
            Minus1.Visible = i;
            Minus2.Visible = i;
            label19.Visible = i;
            label20.Visible = i;
            HaursBox2.Visible = i;
            ThertyComboBox.Visible = i;
            if (i == false)
                SecondComboBoxNameOtchet.Text = "нет";
        }
        private void VisibleBox3(bool i)
        {
            Minus3.Visible = i;
            label22.Visible = i;
            HaursBox3.Visible = i;
            if (i == false)
                ThertyComboBox.Text = "нет";
        }
        private static void VisableReset(List<MaterialTextBox2> Boxs)
        {
            foreach (var box in Boxs)
            {
                if (!box.Visible)
                    box.Text = "0";
            }
        }
        private void ZPBox(string name, string name2, string name3, int zarp1, int zarp2, int zarp3)
        {
            var list = listBox6.Items;
            list.Clear();
            list.Add(name + ": " + zarp1);
            if (Minus2.Visible)
                list.Add(name2 + ": " + zarp2);
            if (Minus3.Visible)
                list.Add(name3 + ": " + zarp3);
        }
        private void PopulateListBox(int nalf, int bnf, int viruchka, int minus, int minusSeyf, int minusAndSeyf, int zp4, int itog, int seyf, int seyfEnd, int SeyfExcel, int nalp, int bnp)
        {
            var name = NameComboBoxOtchet.Text;
            if (!string.IsNullOrWhiteSpace(SecondComboBoxNameOtchet.Text) && SecondComboBoxNameOtchet.Text != "нет")
                name = $"{name}/{SecondComboBoxNameOtchet.Text}";
            if (!string.IsNullOrWhiteSpace(ThertyComboBox.Text) && ThertyComboBox.Text != "нет")
                name = $"{name}/{ThertyComboBox.Text}";

            var list = new List<string>
            {
                $"ДАТА: {DateTime.Now:yyyy.MM.dd HH:mm:ss}",
                $"{name}\n",
                $"Нал: {nalf}р",
                $"Б/Н: {bnf}р",
                "-1000р размен.",
                $"Выручка: {viruchka}р",
                $"Минус по кассе: {minus}р {(string.IsNullOrWhiteSpace(TextBox8.Text) ? string.Empty : $"({TextBox8.Text})")}",
                $"Минус по Сейфу: {MinusSeyf(minusSeyf)}р",
                $"Суммарный минус: {MinusAndSeyf(minusAndSeyf)}р",
                $"ЗП: {zp4}р",
                $"Итог: {itog}р\n",
                $"Факт сейф во время закрытие: {seyf}",
                $"Факт сейф после закрытия: {seyfEnd}р\n",
                $"Сейф программы: {SeyfExcel}р",
                $"Нала в программе: {nalp}р",
                $"Б/Н в программе: {bnp}р"
            };

            // Convert List<string> to string array
            listBox1.Items.AddRange([.. list]);
        }
        private static int MinusSeyf(int minusSeyf)
        {
            return minusSeyf > -20 ? 0 : minusSeyf;
        }
        private static int MinusAndSeyf(int minusSeyf)
        {
            return minusSeyf > 0 ? 0 : minusSeyf;
        }
        private static void SetDefaultValuesAndTextBoxes(MaterialTextBox2 textBox1, MaterialTextBox2 textBox2, params MaterialTextBox2[] textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                    textBox.Text = "";
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
                textBox1.Text = "";
            if (string.IsNullOrWhiteSpace(textBox2.Text))
                textBox2.Text = "";
        }
        private void UpdateInPagesSeyfPlus(object sender, EventArgs e)
        {
            var value = CalculetMessagePageSeyfPlus();

            listBox3.Items.Clear();
            listBox3.Items.Add($"{value.message}");
        }
        private (string message, int Qwerty2) CalculetMessagePageSeyfPlus()
        {
            string Qwerty = materialTextBox21.Text;
            int.TryParse(materialTextBox22.Text, out int Qwerty2);
            string message = $"+{Qwerty2} {Qwerty}\n";
            return (message, Qwerty2);
        }

        private void AuthBtn_Click(object sender, EventArgs e)
        {
            Logining();
        }
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            RestoreTabs();
            materialTabControl1.TabPages.Insert(0, AutherPage);
            materialTabControl1.SelectedTab = AutherPage;
            materialTabSelector1.Visible = false;
            ExitBtn.Visible = false;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameComboBoxOtchet.Text) && !Loading)
            {
                MessageBox.Show("Вы забыли имя");
                return;
            }
            SetDefaultValuesAndTextBoxes(HaursBox1, HaursBox2, textBox2, textBox3, textBox4, textBox5, textBox7);
            CheakPlsHaurs();
            List<MaterialTextBox2> _listHaursBox = [HaursBox1, HaursBox2, HaursBox3];
            VisableReset(_listHaursBox);

            var values = GetValues();
            if (sender == Расчитать)
            {
                if (Minus1.Visible)
                {
                    if (-1 * (values.minus1 + values.minus2 + values.minus3) != values.minusAndSeyf)
                    {
                        MessageBox.Show($"ваша сумма минуса не равна общему минусу, вами указанно {-1 * (values.minus1 + values.minus2 + values.minus3)}, а надо {values.minus}");
                        return;
                    }
                }
            }
            listBox1.Items.Clear();
            PopulateListBox(values.nalf, values.bnf, values.viruchka, values.minus, values.minusSeyf, values.minusAndSeyf, values.zp4, values.itog, values.seyf, values.seyfEnd, values.SeyfExcel, values.nalp, values.bnp);
            ZPBox(values.name, values.name2, values.name3, values.zarp1, values.zarp2, values.zarp3);

        }
        private async void Button2_Click(object sender, EventArgs e)
        {
            if (DataStore.TokenBot == null)
                throw new Exception("Ошибка токена");
            bot = new TelegramBotClient(DataStore.TokenBot);
            string? selectedName = NameComboBoxOtchet.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(selectedName)) { MessageBox.Show("Не выбранно имя"); return; }
            var values = GetValues();
            if (Minus1.Visible)
            {
                if (-1 * (values.minus1 + values.minus2 + values.minus3) != values.minusAndSeyf)
                {
                    MessageBox.Show($"ваша сумма минуса не равна общему минусу, вами указанно {-1 * (values.minus1 + values.minus2 + values.minus3)}, а надо {values.minus}");
                    return;
                }
            }
            long userId = DataStore.Users[selectedName];
            int TredID = DataStore.TraidSmena;

            StringBuilder listBox1StringBuilder = new();
            listBox1.Invoke((MethodInvoker)delegate
            {
                foreach (var item in listBox1.Items)
                    listBox1StringBuilder.AppendLine(item.ToString());
            });
            await Telegrame.ProcessUpdates(userId, TredID, selectedName, listBox2, Отправить);
            Cheacked = true;
            await bot.SendTextMessageAsync(DataStore.ForwardChat, listBox1StringBuilder.ToString(), replyToMessageId: TredID);

            await ExcelHelperZP.ZPexcelОтчет(values.zarp1, values.zarp2, values.zarp3, NameComboBoxOtchet, SecondComboBoxNameOtchet, ThertyComboBox, Minus2, Minus3);
            await Telegrame.SendMessageAsync(values.zarp1, values.zarp2, values.zarp3, values.name, values.name2, values.name3, Отправить);
            int Seyf = values.nalf - 1000;
            await ExcelHelper.SeyfMinus(Seyf + values.minusSeyf, 1);
            Cheacked = false;
            return;
        }
        private async void PlusSeyf_Click(object sender, EventArgs e)
        {
            try
            {
                if (materialCheckbox1.Checked)
                {
                    if (DataStore.TokenBot == null)
                        throw new Exception("Ошибка токена");
                    bot = new TelegramBotClient(DataStore.TokenBot);
                    if ((string.IsNullOrWhiteSpace(materialTextBox21.Text)) || (string.IsNullOrWhiteSpace(materialTextBox22.Text)))
                    {
                        MessageBox.Show("Поля не заполнены");
                        materialCheckbox1.Checked = false; // Снимаем галочку
                        return; // Прекращаем выполнение метода, если поле не заполнено
                    }
                    var value = CalculetMessagePageSeyfPlus();
                    PlusSeyf.Enabled = false;
                    await ExcelHelper.SeyfMinus(value.Qwerty2);
                    int values = ExcelHelper.GetCellValueAsInt("s", "seyf");
                    string endMessage = value.message + "Теперь: " + values;
                    await bot.SendTextMessageAsync(DataStore.ForwardChat, endMessage, replyToMessageId: DataStore.TraidSmena);
                    await Task.Delay(5000);
                    PlusSeyf.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Подтверди отправку");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
            finally
            {
                PlusSeyf.Enabled = true;
            }
        }
        private async void Штраф_Click(object sender, EventArgs e)
        {
            if (DataStore.TokenBot == null)
                throw new Exception("Ошибка токена");
            bot = new TelegramBotClient(DataStore.TokenBot); Аванс.Enabled = false;
            if (string.IsNullOrEmpty(WhoVipisl.Text) || WhoVipisl.Text == "нет")
            {
                MessageBox.Show("Укажите кто выписывает");
                return;
            }
            var messag = string.Join(Environment.NewLine, listBox4.Items.Cast<string>());
            var name = KomuVipisal.Text;
            int.TryParse(textBox2.Text, out int syu);
            var nameVipi = WhoVipisl.Text;
            var message = $"Выписал: {nameVipi}\n\n{name}\n\n{messag}\n\n-{syu}";

            await bot.SendTextMessageAsync(DataStore.ForwardChat, message, replyToMessageId: DataStore.TreidShtraph);
            int summ = CalculateShtraph(syu);
            await ExcelHelperZP.AvansMinus(summ, name);
            if (DataStore.Names.TryGetValue(name, out int value))
                await bot.SendTextMessageAsync(DataStore.ChatId, message, replyToMessageId: value);
            Аванс.Enabled = true;
        }
        private async void Аванс_Click(object sender, EventArgs e)
        {
            if (DataStore.TokenBot == null)
                throw new Exception("Ошибка токена");
            bot = new TelegramBotClient(DataStore.TokenBot); string name = materialComboBox2.Text; // Инициализирует имя
            if (name == null)
            {
                MessageBox.Show("Выберите имя");
                return;
            }
            Аванс.Enabled = false; // Блокирует кнопку, чтобы повторно не нажали

            // Переводит CheckBox'ы в переменные
            bool premia = Premia.Checked;
            bool avans = AvansCheack.Checked;
            bool zp = ZPcheak.Checked;
            bool minusPoSeyf = MinusPoSeyf.Checked;
            bool otpusknie = Otpusknie.Checked;

            // Определяет тип выписывания по CheckBox'ам
            string type = avans ? "Аванс" : zp ? "ЗП" : minusPoSeyf ? "Был минус по сейфу у" : premia ? "Премия" : otpusknie ? "отпускные" : "";

            if (!int.TryParse(materialTextBox23.Text, out int summ))
            {
                MessageBox.Show("Неверная сумма.");
                Аванс.Enabled = true;
                return;
            }

            if (!premia) // Если не премия, то будет минус
                summ *= -1;

            var message = $"{summ} {type} {name}"; // Составление сообщения для Telegram
            if (premia)
                message = $"+{summ} {type} {name}";

            try
            {
                await ExcelHelperZP.AvansMinus(summ, name);
                if (!BnAvansCheck.Checked && !premia) // Выписывает с сейфа, если не Б/Н и не премия
                {
                    await bot.SendTextMessageAsync(DataStore.ForwardChat, message, replyToMessageId: DataStore.TraidSmena);
                    await ExcelHelper.SeyfMinus(summ);
                }
                if (DataStore.Names.TryGetValue(name, out int trade1))
                {
                    var value = ExcelHelper.GetCellValueAsInt("ZP", name);
                    await bot.SendTextMessageAsync(DataStore.ChatId, message + $"\nТеперь: {value}р", replyToMessageId: trade1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
            finally
            {
                Аванс.Enabled = true;
            }
        }
        private async void Расход_Click(object sender, EventArgs e)
        {
            if (DataStore.TokenBot == null)
                throw new Exception("ошибка токена");
            bot = new TelegramBotClient(DataStore.TokenBot);
            string? selectedName = comboBoxNameRas.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(materialTextBox25.Text) || string.IsNullOrWhiteSpace(materialTextBox26.Text) || selectedName == null)
            {
                MessageBox.Show("Вы заполнели не все поля");

                return;
            }
            Аванс.Enabled = false;
            long userId = DataStore.Users[selectedName];
            int TredID = !PostavkaRashod.Checked ? DataStore.TraidRashod : DataStore.TraidPostavka;

            int.TryParse(materialTextBox25.Text, out int summ);

            string message = $"{summ} {materialTextBox26.Text}";
            // Call the method
            if (PhotoMessageRashod.Checked)
                await Telegrame.ProcessUpdates(userId, TredID, selectedName, listBoxRas, Расход);

            await bot.SendTextMessageAsync(DataStore.ForwardChat, message, replyToMessageId: TredID);
            if (SeyfRasHod.Checked)
            {
                if (summ > 0)
                    summ *= -1;
                await ExcelHelper.SeyfMinus(summ);
                var value = ExcelHelper.GetCellValueAsInt("s", "seyf");
                string messageExcl = $"\nТеперь: {value}";
                var messag = $"{summ} {materialTextBox26.Text} {messageExcl}";
                await bot.SendTextMessageAsync(DataStore.ForwardChat, messag, replyToMessageId: DataStore.TraidSmena);
            }
            Аванс.Enabled = true;
        }
        private async void InventBTN_Click(object sender, EventArgs e)
        {
            // Парсим значение из InventSum
            if (!int.TryParse(InventSum.Text, out int inventSum))
            {
                MessageBox.Show("Введите корректное число.");
                return;
            }

            // Получаем количество выбранных элементов в listBoxNameInv
            int selectedCount = listBoxNameInv.SelectedItems.Count;
            if (listBoxNameInv.SelectedItems == null)
            {
                MessageBox.Show("Вы не выбрали ни одно имя");
                return;
            }
            // Проверяем, чтобы выбрано было хотя бы одно имя
            if (selectedCount == 0)
            {
                MessageBox.Show("Выберите хотя бы одно имя.");
                return;
            }
            Аванс.Enabled = true;
            // Расчет результата деления
            int result = inventSum / selectedCount;
            result *= -1;
            DateTime now = DateTime.Now;
            var date = $"{now:MM.dd HH:mm}";
            // Формирование сообщения
            string message = $"{date}\n{result}р инвентаризация\nТеперь: ";

            List<string>? selectedNames = [];
            foreach (var item in listBoxNameInv.SelectedItems)
            {
                selectedNames.Add(item.ToString() ?? string.Empty);
            }
            await ExcelHelperZP.ЗаполнениеExcelInvent(result, listBoxNameInv);
            await Telegrame.SendMessageToSelectedNamesAsync(selectedNames, message);
            Аванс.Enabled = true;
        }
        private async void ThisButton1_click(object sender, EventArgs args)
        {
            if (DataStore.NameList != null)
            {
                DateTime now = DateTime.Now;
                var date = $"{now:MM.dd HH:mm}";
                string message = $"{date}\nИтог: ";
                try
                {
                    await Telegrame.SendMessageToSelectedNamesAsync(DataStore.NameList, message);
                    SendPhotoExcelZp();
                    SendPhotoExcelSeyfAndAll();
                }
                catch (Exception e)
                {
                    Loggers.Logger.ErrorLog($"{e}");
                }
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            materialTabControl1.SelectedTab = AutherPage;
            VisibleBox(false);
            VisibleBox3(false);
            ResetHours();
            ExcelHelperCreater.ExcelCreat(DataStore.NameList);
            Telegrame.DeleteWebhookAsync(listBox2);
            Loading = false;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Cheacked)
            {
                e.Cancel = true;
                MessageBox.Show("Завершите процесс");
                return;
            }
            DialogResult result = MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Подтверждение закрытия", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Если пользователь выбрал "Нет", отменяем закрытие программы
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Отменяем закрытие формы
            }
        }
    }
}