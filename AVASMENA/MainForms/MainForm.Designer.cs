using MaterialSkin;
using MaterialSkin.Controls;
using AVASMENA.MainForms.Designer;

namespace AVASMENA.MainForms
{
    public class ControlTemplate<T> where T : Control, new()
    {
        public T CreateControl(Action<T> configurator)
        {
            T control = new T();
            configurator(control);
            return control;
        }
    }
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeMaterialSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.DeepPurple900, Primary.DeepPurple900, Primary.Purple100, Accent.Purple100, TextShade.WHITE);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ExitBtn = new ThisButton();
            materialTabControl1 = new MaterialTabControl();
            AutherPage = new ThisTabPage();
            PasswordTextBox = new ThisTextBox();
            AuthBtn = new ThisButton();
            LoginBox = new ThisComboBox();
            OtchetPage = new ThisTabPage();
            listBox6 = new ThisListBox();
            label22 = new ThisLabel();
            Minus3 = new ThisTextBox();
            ThertyComboBox = new ThisComboBox();
            HaursBox3 = new ThisTextBox();
            Расчитать = new ThisButton();
            Отправить = new ThisButton();
            label20 = new ThisLabel();
            label19 = new ThisLabel();
            Minus2 = new ThisTextBox();
            Minus1 = new ThisTextBox();
            label18 = new ThisLabel();
            HaursBox1 = new ThisTextBox();
            SecondComboBoxNameOtchet = new ThisComboBox();
            HaursBox2 = new ThisTextBox();
            listBox2 = new ThisListBox();
            listBox1 = new ThisListBox();
            NameComboBoxOtchet = new ThisComboBox();
            TextBox8 = new ThisTextBox();
            textBox7 = new ThisTextBox();
            textBox5 = new ThisTextBox();
            textBox4 = new ThisTextBox();
            textBox3 = new ThisTextBox();
            textBox2 = new ThisTextBox();
            label8 = new ThisLabel();
            label7 = new ThisLabel();
            label5 = new ThisLabel();
            label4 = new ThisLabel();
            label3 = new ThisLabel();
            label2 = new ThisLabel();
            label12 = new ThisLabel();
            AvansPage = new ThisTabPage();
            Otpusknie = new ThisCheackBox();
            BnAvansCheck = new ThisCheackBox();
            ZPcheak = new ThisCheackBox();
            Premia = new ThisCheackBox();
            AvansCheack = new ThisCheackBox();
            MinusPoSeyf = new ThisCheackBox();
            Аванс = new ThisButton();
            label17 = new ThisLabel();
            label16 = new ThisLabel();
            materialTextBox23 = new ThisTextBox();
            materialComboBox2 = new ThisComboBox();
            SeyfPlusPage = new ThisTabPage();
            materialCheckbox1 = new ThisCheackBox();
            listBox3 = new ThisListBox();
            PlusSeyf = new ThisButton();
            label11 = new ThisLabel();
            label10 = new ThisLabel();
            materialTextBox22 = new ThisTextBox();
            materialTextBox21 = new ThisTextBox();
            RashodPage = new ThisTabPage();
            PhotoMessageRashod = new ThisCheackBox();
            SeyfRasHod = new ThisCheackBox();
            PostavkaRashod = new ThisCheackBox();
            listBoxRas = new ThisListBox();
            comboBoxNameRas = new ThisComboBox();
            Расход = new ThisButton();
            label21 = new ThisLabel();
            label9 = new ThisLabel();
            materialTextBox26 = new ThisTextBox();
            materialTextBox25 = new ThisTextBox();
            ShtraphPage = new ThisTabPage();
            label6 = new ThisLabel();
            WhoVipisl = new ThisComboBox();
            listBox4 = new ThisListBox();
            label15 = new ThisLabel();
            label14 = new ThisLabel();
            materialTextBox2 = new ThisTextBox();
            Штраф = new ThisButton();
            listBox5 = new ThisListBox();
            KomuVipisal = new ThisComboBox();
            InventPage = new ThisTabPage();
            listBoxNameInv = new ThisListBox();
            InventBTN = new ThisButton();
            InventSum = new ThisTextBox();
            materialTabSelector1 = new MaterialTabSelector();
            thisButton1 = new ThisButton();
            TextBoxType = new ThisTextBox();
            labelType = new ThisLabel();
            materialTabControl1.SuspendLayout();
            AutherPage.SuspendLayout();
            OtchetPage.SuspendLayout();
            AvansPage.SuspendLayout();
            SeyfPlusPage.SuspendLayout();
            RashodPage.SuspendLayout();
            ShtraphPage.SuspendLayout();
            InventPage.SuspendLayout();
            SuspendLayout();
            // 
            // ExitBtn
            // 
            ExitBtn.AccessibleRole = AccessibleRole.None;
            ExitBtn.AllowDrop = true;
            ExitBtn.AutoSize = false;
            ExitBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ExitBtn.BackColor = Color.FromArgb(64, 0, 64);
            ExitBtn.CausesValidation = false;
            ExitBtn.Density = ThisButton.MaterialButtonDensity.Default;
            ExitBtn.Depth = 0;
            ExitBtn.DrawShadows = false;
            ExitBtn.ForeColor = Color.White;
            ExitBtn.HighEmphasis = true;
            ExitBtn.Icon = null;
            ExitBtn.ImeMode = ImeMode.NoControl;
            ExitBtn.Location = new Point(1631, 31);
            ExitBtn.Margin = new Padding(4, 6, 4, 6);
            ExitBtn.MouseState = MouseState.HOVER;
            ExitBtn.Name = "ExitBtn";
            ExitBtn.NoAccentTextColor = Color.Empty;
            ExitBtn.Size = new Size(73, 34);
            ExitBtn.TabIndex = 5;
            ExitBtn.Text = "Выход";
            ExitBtn.Type = ThisButton.MaterialButtonType.Text;
            ExitBtn.UseAccentColor = true;
            ExitBtn.UseVisualStyleBackColor = false;
            ExitBtn.Visible = false;
            ExitBtn.Click += ExitBtn_Click;
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(AutherPage);
            materialTabControl1.Controls.Add(OtchetPage);
            materialTabControl1.Controls.Add(AvansPage);
            materialTabControl1.Controls.Add(SeyfPlusPage);
            materialTabControl1.Controls.Add(RashodPage);
            materialTabControl1.Controls.Add(ShtraphPage);
            materialTabControl1.Controls.Add(InventPage);
            materialTabControl1.Depth = 0;
            materialTabControl1.Location = new Point(-3, 23);
            materialTabControl1.MouseState = MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1721, 880);
            materialTabControl1.TabIndex = 4;
            // 
            // AutherPage
            // 
            AutherPage.Controls.Add(PasswordTextBox);
            AutherPage.Controls.Add(AuthBtn);
            AutherPage.Controls.Add(LoginBox);
            AutherPage.Name = "AutherPage";
            AutherPage.TabIndex = 7;
            AutherPage.Text = "Авторизация";
            // 
            // PasswordTextBox
            //
            PasswordTextBox.Location = new Point(629, 334);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '●';
            PasswordTextBox.Size = new Size(231, 48);
            PasswordTextBox.TabIndex = 2;
            PasswordTextBox.UseSystemPasswordChar = true;
            PasswordTextBox.Visible = false;
            PasswordTextBox.KeyDown += PasswordTextBox_KeyDown;
            // 
            // AuthBtn
            // 
            AuthBtn.Location = new Point(685, 391);
            AuthBtn.Name = "AuthBtn";
            AuthBtn.Size = new Size(125, 36);
            AuthBtn.TabIndex = 1;
            AuthBtn.Text = "Продолжить";
            AuthBtn.Click += AuthBtn_Click;
            // 
            // LoginBox
            //
            LoginBox.Items.AddRange(new object[] { "Admin", "Root" });
            LoginBox.Location = new Point(588, 279);
            LoginBox.Name = "LoginBox";
            LoginBox.Size = new Size(318, 49);
            LoginBox.SelectedIndexChanged += LoginBox_SelectedIndex;
            // 
            // OtchetPage
            // 
            OtchetPage.Controls.Add(listBox6);
            OtchetPage.Controls.Add(label22);
            OtchetPage.Controls.Add(Minus3);
            OtchetPage.Controls.Add(ThertyComboBox);
            OtchetPage.Controls.Add(HaursBox3);
            OtchetPage.Controls.Add(Расчитать);
            OtchetPage.Controls.Add(Отправить);
            OtchetPage.Controls.Add(label20);
            OtchetPage.Controls.Add(label19);
            OtchetPage.Controls.Add(Minus2);
            OtchetPage.Controls.Add(Minus1);
            OtchetPage.Controls.Add(label18);
            OtchetPage.Controls.Add(HaursBox1);
            OtchetPage.Controls.Add(SecondComboBoxNameOtchet);
            OtchetPage.Controls.Add(HaursBox2);
            OtchetPage.Controls.Add(listBox2);
            OtchetPage.Controls.Add(listBox1);
            OtchetPage.Controls.Add(NameComboBoxOtchet);
            OtchetPage.Controls.Add(TextBox8);
            OtchetPage.Controls.Add(textBox7);
            OtchetPage.Controls.Add(textBox5);
            OtchetPage.Controls.Add(textBox4);
            OtchetPage.Controls.Add(textBox3);
            OtchetPage.Controls.Add(textBox2);
            OtchetPage.Controls.Add(label8);
            OtchetPage.Controls.Add(label7);
            OtchetPage.Controls.Add(label5);
            OtchetPage.Controls.Add(label4);
            OtchetPage.Controls.Add(label3);
            OtchetPage.Controls.Add(label2);
            OtchetPage.Controls.Add(label12);
            OtchetPage.Name = "OtchetPage";
            OtchetPage.TabIndex = 0;
            OtchetPage.Text = "Отчет по смене";
            // 
            // listBox6
            // 
            listBox6.BackColor = Color.FromArgb(25, 0, 64);
            listBox6.BorderStyle = BorderStyle.None;
            listBox6.Font = new Font("Segoe UI", 17.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox6.ForeColor = Color.YellowGreen;
            listBox6.FormattingEnabled = true;
            listBox6.HorizontalScrollbar = true;
            listBox6.ItemHeight = 31;
            listBox6.Location = new Point(61, 587);
            listBox6.Name = "listBox6";
            listBox6.Size = new Size(518, 186);
            listBox6.TabIndex = 66;
            // 
            // label22
            // 
            label22.Font = new Font("Segoe UI", 10F);
            label22.Location = new Point(63, 424);
            label22.Name = "label22";
            label22.TabIndex = 65;
            label22.Text = "Минус третьего";
            // 
            // Minus3
            //
            Minus3.Location = new Point(61, 442);
            Minus3.Name = "Minus3";
            Minus3.Size = new Size(123, 48);
            Minus3.TabIndex = 64;
            Minus3.KeyPress += TextBox_KeyPress;
            Minus3.TextChanged += Button1_Click;
            // 
            // ThertyComboBox
            //
            ThertyComboBox.Location = new Point(61, 201);
            ThertyComboBox.Name = "ThertyComboBox";
            ThertyComboBox.Size = new Size(176, 49);
            ThertyComboBox.TabIndex = 63;
            ThertyComboBox.SelectedIndexChanged += MethodSekectedIndex;
            // 
            // HaursBox3
            //
            HaursBox3.Location = new Point(248, 200);
            HaursBox3.Name = "HaursBox3";
            HaursBox3.Size = new Size(73, 48);
            HaursBox3.TabIndex = 62;
            HaursBox3.Text = "0";
            HaursBox3.KeyPress += TextBox_KeyPress;
            HaursBox3.TextChanged += ChengedHaurs;
            // 
            // Расчитать
            //
            Расчитать.Location = new Point(659, 500);
            Расчитать.Name = "Расчитать";
            Расчитать.Size = new Size(873, 36);
            Расчитать.Text = "Расчитать";
            Расчитать.Click += Button1_Click;
            // 
            // Отправить
            // 
            Отправить.Location = new Point(660, 743);
            Отправить.Name = "Отправить";
            Отправить.Size = new Size(873, 36);
            Отправить.Text = "отправить";
            Отправить.Click += Button2_Click;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.BackColor = Color.Transparent;
            label20.Font = new Font("Segoe UI", 10F);
            label20.ForeColor = Color.LimeGreen;
            label20.ImeMode = ImeMode.NoControl;
            label20.Location = new Point(217, 330);
            label20.Name = "label20";
            label20.Size = new Size(105, 19);
            label20.TabIndex = 59;
            label20.Text = "Минус второго";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = Color.Transparent;
            label19.Font = new Font("Segoe UI", 10F);
            label19.ForeColor = Color.LimeGreen;
            label19.ImeMode = ImeMode.NoControl;
            label19.Location = new Point(58, 330);
            label19.Name = "label19";
            label19.Size = new Size(150, 19);
            label19.TabIndex = 58;
            label19.Text = "Минус закрывающего";
            // 
            // Minus2
            //
            Minus2.Location = new Point(220, 346);
            Minus2.Name = "Minus2";
            Minus2.Size = new Size(123, 48);
            Minus2.TabIndex = 57;
            Minus2.KeyPress += TextBox_KeyPress;
            Minus2.TextChanged += Button1_Click;
            // 
            // Minus1
            //
            Minus1.Location = new Point(61, 346);
            Minus1.Name = "Minus1";
            Minus1.Size = new Size(127, 48);
            Minus1.TabIndex = 56;
            Minus1.KeyPress += TextBox_KeyPress;
            Minus1.TextChanged += Button1_Click;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = Color.Transparent;
            label18.Font = new Font("Segoe UI", 17F);
            label18.ForeColor = Color.LimeGreen;
            label18.ImeMode = ImeMode.NoControl;
            label18.Location = new Point(243, 60);
            label18.Name = "label18";
            label18.Size = new Size(77, 31);
            label18.TabIndex = 55;
            label18.Text = "Часов";
            // 
            // HaursBox1
            //
            HaursBox1.Location = new Point(248, 92);
            HaursBox1.Name = "HaursBox1";
            HaursBox1.Size = new Size(72, 48);
            HaursBox1.TabIndex = 54;
            HaursBox1.Text = "0";
            HaursBox1.KeyPress += TextBox_KeyPress;
            HaursBox1.TextChanged += ChengedHaurs;
            // 
            // SecondComboBoxNameOtchet
            //
            SecondComboBoxNameOtchet.Location = new Point(61, 146);
            SecondComboBoxNameOtchet.Name = "SecondComboBoxNameOtchet";
            SecondComboBoxNameOtchet.Size = new Size(176, 49);
            SecondComboBoxNameOtchet.TabIndex = 53;
            SecondComboBoxNameOtchet.SelectedIndexChanged += MethodSekectedIndex;
            // 
            // HaursBox2
            //
            HaursBox2.Location = new Point(248, 146);
            HaursBox2.Name = "HaursBox2";
            HaursBox2.Size = new Size(73, 48);
            HaursBox2.TabIndex = 52;
            HaursBox2.Text = "0";
            HaursBox2.KeyPress += TextBox_KeyPress;
            HaursBox2.TextChanged += ChengedHaurs;
            // 
            // listBox2
            // 
            listBox2.BackColor = Color.FromArgb(25, 0, 64);
            listBox2.BorderStyle = BorderStyle.None;
            listBox2.Font = new Font("Segoe UI", 17.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox2.ForeColor = Color.YellowGreen;
            listBox2.FormattingEnabled = true;
            listBox2.HorizontalScrollbar = true;
            listBox2.ItemHeight = 31;
            listBox2.Location = new Point(660, 560);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(874, 155);
            listBox2.TabIndex = 48;
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.FromArgb(25, 0, 64);
            listBox1.BorderStyle = BorderStyle.None;
            listBox1.Font = new Font("Segoe UI", 17.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox1.ForeColor = Color.YellowGreen;
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.ItemHeight = 31;
            listBox1.Location = new Point(659, 56);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(873, 403);
            listBox1.TabIndex = 45;
            // 
            // NameComboBoxOtchet
            //
            NameComboBoxOtchet.Location = new Point(61, 90);
            NameComboBoxOtchet.Name = "NameComboBoxOtchet";
            NameComboBoxOtchet.Size = new Size(176, 49);
            NameComboBoxOtchet.TabIndex = 1;
            NameComboBoxOtchet.SelectedIndexChanged += MethodSekectedIndex;
            // 
            // TextBox8
            //
            TextBox8.Location = new Point(354, 514);
            TextBox8.Name = "TextBox8";
            TextBox8.Size = new Size(225, 48);
            TextBox8.TabIndex = 8;
            TextBox8.TextChanged += Button1_Click;
            // 
            // textBox7
            //
            textBox7.Location = new Point(354, 431);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(225, 48);
            textBox7.KeyPress += TextBox_KeyPress;
            textBox7.TextChanged += Button1_Click;
            // 
            // textBox5
            //
            textBox5.Location = new Point(354, 346);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(225, 48);
            textBox5.TabIndex = 5;
            textBox5.KeyPress += TextBox_KeyPress;
            textBox5.TextChanged += Button1_Click;
            // 
            // textBox4
            //
            textBox4.Location = new Point(354, 261);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(225, 48);
            textBox4.TabIndex = 4;
            textBox4.KeyPress += TextBox_KeyPress;
            textBox4.TextChanged += Button1_Click;
            // 
            // textBox3
            //
            textBox3.Location = new Point(354, 176);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(225, 48);
            textBox3.TabIndex = 3;
            textBox3.KeyPress += TextBox_KeyPress;
            textBox3.TextChanged += Button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(354, 91);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(225, 48);
            textBox2.TabIndex = 2;
            textBox2.KeyPress += TextBox_KeyPress;
            textBox2.TextChanged += Button1_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 17F);
            label8.ForeColor = Color.LimeGreen;
            label8.ImeMode = ImeMode.NoControl;
            label8.Location = new Point(349, 482);
            label8.Name = "label8";
            label8.Size = new Size(165, 31);
            label8.TabIndex = 49;
            label8.Text = "Почему минус";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 17F);
            label7.ForeColor = Color.LimeGreen;
            label7.ImeMode = ImeMode.NoControl;
            label7.Location = new Point(348, 397);
            label7.Name = "label7";
            label7.Size = new Size(97, 31);
            label7.TabIndex = 44;
            label7.Text = "В сейфе";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 17F);
            label5.ForeColor = Color.LimeGreen;
            label5.ImeMode = ImeMode.NoControl;
            label5.Location = new Point(349, 312);
            label5.Name = "label5";
            label5.Size = new Size(195, 31);
            label5.TabIndex = 42;
            label5.Text = "Б/Н в программе";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 17F);
            label4.ForeColor = Color.LimeGreen;
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(348, 227);
            label4.Name = "label4";
            label4.Size = new Size(209, 31);
            label4.TabIndex = 41;
            label4.Text = "Нала в программе";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 17F);
            label3.ForeColor = Color.LimeGreen;
            label3.ImeMode = ImeMode.NoControl;
            label3.Location = new Point(348, 142);
            label3.Name = "label3";
            label3.Size = new Size(198, 31);
            label3.TabIndex = 40;
            label3.Text = "Сколько факт Б/Н";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 17F);
            label2.ForeColor = Color.LimeGreen;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(348, 56);
            label2.Name = "label2";
            label2.Size = new Size(209, 31);
            label2.TabIndex = 39;
            label2.Text = "Сколько факт нала";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Segoe UI", 17F);
            label12.ForeColor = Color.LimeGreen;
            label12.ImeMode = ImeMode.NoControl;
            label12.Location = new Point(55, 56);
            label12.Name = "label12";
            label12.Size = new Size(59, 31);
            label12.TabIndex = 38;
            label12.Text = "Имя";
            // 
            // AvansPage
            // 
            AvansPage.Controls.Add(Otpusknie);
            AvansPage.Controls.Add(BnAvansCheck);
            AvansPage.Controls.Add(ZPcheak);
            AvansPage.Controls.Add(Premia);
            AvansPage.Controls.Add(AvansCheack);
            AvansPage.Controls.Add(MinusPoSeyf);
            AvansPage.Controls.Add(Аванс);
            AvansPage.Controls.Add(label17);
            AvansPage.Controls.Add(label16);
            AvansPage.Controls.Add(materialTextBox23);
            AvansPage.Controls.Add(materialComboBox2);
            AvansPage.Controls.Add(TextBoxType);
            AvansPage.Controls.Add(labelType);
            AvansPage.Name = "AvansPage";
            AvansPage.TabIndex = 3;
            AvansPage.Text = "Аванc/ЗП";
            // 
            // Otpusknie
            // 
            Otpusknie.AutoSize = true;
            Otpusknie.Depth = 0;
            Otpusknie.ImeMode = ImeMode.NoControl;
            Otpusknie.Location = new Point(924, 157);
            Otpusknie.Margin = new Padding(0);
            Otpusknie.MouseLocation = new Point(-1, -1);
            Otpusknie.MouseState = MouseState.HOVER;
            Otpusknie.Name = "Otpusknie";
            Otpusknie.ReadOnly = false;
            Otpusknie.Ripple = true;
            Otpusknie.Size = new Size(117, 37);
            Otpusknie.TabIndex = 10;
            Otpusknie.Text = "Отпускные";
            Otpusknie.UseVisualStyleBackColor = true;
            Otpusknie.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // BnAvansCheck
            // 
            BnAvansCheck.AutoSize = true;
            BnAvansCheck.Depth = 0;
            BnAvansCheck.ImeMode = ImeMode.NoControl;
            BnAvansCheck.Location = new Point(75, 152);
            BnAvansCheck.Margin = new Padding(0);
            BnAvansCheck.MouseLocation = new Point(-1, -1);
            BnAvansCheck.MouseState = MouseState.HOVER;
            BnAvansCheck.Name = "BnAvansCheck";
            BnAvansCheck.ReadOnly = false;
            BnAvansCheck.Ripple = true;
            BnAvansCheck.Size = new Size(67, 37);
            BnAvansCheck.TabIndex = 5;
            BnAvansCheck.Text = " Б/Н";
            BnAvansCheck.UseVisualStyleBackColor = true;
            // 
            // ZPcheak
            // 
            ZPcheak.AutoSize = true;
            ZPcheak.Depth = 0;
            ZPcheak.ImeMode = ImeMode.NoControl;
            ZPcheak.Location = new Point(511, 157);
            ZPcheak.Margin = new Padding(0);
            ZPcheak.MouseLocation = new Point(-1, -1);
            ZPcheak.MouseState = MouseState.HOVER;
            ZPcheak.Name = "ZPcheak";
            ZPcheak.ReadOnly = false;
            ZPcheak.Ripple = true;
            ZPcheak.Size = new Size(63, 37);
            ZPcheak.TabIndex = 7;
            ZPcheak.Text = "З/П";
            ZPcheak.UseVisualStyleBackColor = true;
            ZPcheak.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // Premia
            // 
            Premia.AutoSize = true;
            Premia.Depth = 0;
            Premia.ImeMode = ImeMode.NoControl;
            Premia.Location = new Point(815, 157);
            Premia.Margin = new Padding(0);
            Premia.MouseLocation = new Point(-1, -1);
            Premia.MouseState = MouseState.HOVER;
            Premia.Name = "Premia";
            Premia.ReadOnly = false;
            Premia.Ripple = true;
            Premia.Size = new Size(93, 37);
            Premia.TabIndex = 9;
            Premia.Text = "Премия";
            Premia.UseVisualStyleBackColor = true;
            Premia.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // AvansCheack
            // 
            AvansCheack.AutoSize = true;
            AvansCheack.Depth = 0;
            AvansCheack.ImeMode = ImeMode.NoControl;
            AvansCheack.Location = new Point(365, 157);
            AvansCheack.Margin = new Padding(0);
            AvansCheack.MouseLocation = new Point(-1, -1);
            AvansCheack.MouseState = MouseState.HOVER;
            AvansCheack.Name = "AvansCheack";
            AvansCheack.ReadOnly = false;
            AvansCheack.Ripple = true;
            AvansCheack.Size = new Size(80, 37);
            AvansCheack.TabIndex = 6;
            AvansCheack.Text = "Аванс";
            AvansCheack.UseVisualStyleBackColor = true;
            AvansCheack.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // MinusPoSeyf
            // 
            MinusPoSeyf.AutoSize = true;
            MinusPoSeyf.Depth = 0;
            MinusPoSeyf.ImeMode = ImeMode.NoControl;
            MinusPoSeyf.Location = new Point(639, 157);
            MinusPoSeyf.Margin = new Padding(0);
            MinusPoSeyf.MouseLocation = new Point(-1, -1);
            MinusPoSeyf.MouseState = MouseState.HOVER;
            MinusPoSeyf.Name = "MinusPoSeyf";
            MinusPoSeyf.ReadOnly = false;
            MinusPoSeyf.Ripple = true;
            MinusPoSeyf.Size = new Size(154, 37);
            MinusPoSeyf.TabIndex = 8;
            MinusPoSeyf.Text = "Минус по сейфу";
            MinusPoSeyf.UseVisualStyleBackColor = true;
            MinusPoSeyf.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // Аванс
            //
            Аванс.Location = new Point(75, 681);
            Аванс.Name = "Аванс";
            Аванс.Size = new Size(108, 36);
            Аванс.TabIndex = 4;
            Аванс.Click += Аванс_Click;
            //
            //labelType
            //
            labelType.AutoSize = true;
            labelType.Text = "Тип выписывания";
            labelType.TabIndex = 3;
            labelType.Location = new Point(746, 16);
            //
            //Type
            //
            TextBoxType.Location = new Point(746, 47);
            TextBoxType.Name = "Type";
            TextBoxType.RightToLeft = RightToLeft.No;
            TextBoxType.Size = new Size(465, 48);
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.ImeMode = ImeMode.NoControl;
            label17.Location = new Point(70, 16);
            label17.Name = "label17";
            label17.Size = new Size(59, 31);
            label17.TabIndex = 3;
            label17.Text = "Имя";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.ForeColor = Color.LimeGreen;
            label16.ImeMode = ImeMode.NoControl;
            label16.Location = new Point(360, 16);
            label16.Name = "label16";
            label16.Size = new Size(83, 31);
            label16.TabIndex = 2;
            label16.Text = "Сумма";
            // 
            // materialTextBox23
            //
            materialTextBox23.Location = new Point(365, 47);
            materialTextBox23.Name = "materialTextBox23";
            materialTextBox23.Size = new Size(341, 48);
            materialTextBox23.TabIndex = 1;
            materialTextBox23.KeyPress += TextBox_KeyPress;
            // 
            // materialComboBox2
            //
            materialComboBox2.Location = new Point(75, 47);
            materialComboBox2.Name = "materialComboBox2";
            materialComboBox2.Size = new Size(235, 49);
            // 
            // SeyfPlusPage
            // 
            SeyfPlusPage.Controls.Add(materialCheckbox1);
            SeyfPlusPage.Controls.Add(listBox3);
            SeyfPlusPage.Controls.Add(PlusSeyf);
            SeyfPlusPage.Controls.Add(label11);
            SeyfPlusPage.Controls.Add(label10);
            SeyfPlusPage.Controls.Add(materialTextBox22);
            SeyfPlusPage.Controls.Add(materialTextBox21);
            SeyfPlusPage.Name = "SeyfPlusPage";
            SeyfPlusPage.Padding = new Padding(3);
            SeyfPlusPage.TabIndex = 1;
            SeyfPlusPage.Text = "Плюс к сейфу";
            // 
            // materialCheckbox1
            // 
            materialCheckbox1.AutoSize = true;
            materialCheckbox1.Depth = 0;
            materialCheckbox1.ImeMode = ImeMode.NoControl;
            materialCheckbox1.Location = new Point(1096, 216);
            materialCheckbox1.Margin = new Padding(0);
            materialCheckbox1.MouseLocation = new Point(-1, -1);
            materialCheckbox1.MouseState = MouseState.HOVER;
            materialCheckbox1.Name = "materialCheckbox1";
            materialCheckbox1.ReadOnly = false;
            materialCheckbox1.Ripple = true;
            materialCheckbox1.Size = new Size(209, 37);
            materialCheckbox1.TabIndex = 4;
            materialCheckbox1.Text = "Подтвердить отправку";
            materialCheckbox1.UseVisualStyleBackColor = true;
            materialCheckbox1.CheckedChanged += UpdateInPagesSeyfPlus;
            // 
            // listBox3
            // 
            listBox3.BackColor = Color.FromArgb(25, 0, 64);
            listBox3.BorderStyle = BorderStyle.None;
            listBox3.Font = new Font("Segoe UI", 17.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox3.ForeColor = Color.YellowGreen;
            listBox3.FormattingEnabled = true;
            listBox3.HorizontalScrollbar = true;
            listBox3.ItemHeight = 31;
            listBox3.Location = new Point(886, 256);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(419, 93);
            listBox3.TabIndex = 12;
            // 
            // PlusSeyf
            // 
            PlusSeyf.Location = new Point(1197, 356);
            PlusSeyf.Name = "PlusSeyf";
            PlusSeyf.Size = new Size(108, 36);
            PlusSeyf.TabIndex = 5;
            PlusSeyf.Text = "отправить";
            PlusSeyf.Click += PlusSeyf_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Microsoft Sans Serif", 17.25F);
            label11.ForeColor = Color.LimeGreen;
            label11.ImeMode = ImeMode.NoControl;
            label11.Location = new Point(466, 78);
            label11.Name = "label11";
            label11.Size = new Size(177, 29);
            label11.TabIndex = 3;
            label11.Text = "Комментарий";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Microsoft Sans Serif", 17.25F);
            label10.ForeColor = Color.LimeGreen;
            label10.ImeMode = ImeMode.NoControl;
            label10.Location = new Point(114, 78);
            label10.Name = "label10";
            label10.Size = new Size(315, 29);
            label10.TabIndex = 2;
            label10.Text = "Сколько положили в сейф";
            // 
            // materialTextBox22
            //
            materialTextBox22.Location = new Point(119, 27);
            materialTextBox22.Name = "materialTextBox22";
            materialTextBox22.Size = new Size(234, 48);
            materialTextBox22.TabIndex = 1;
            materialTextBox22.KeyPress += TextBox_KeyPress;
            materialTextBox22.TextChanged += UpdateInPagesSeyfPlus;
            // 
            // materialTextBox21
            //
            materialTextBox21.Location = new Point(471, 27);
            materialTextBox21.Name = "materialTextBox21";
            materialTextBox21.Size = new Size(884, 48);
            materialTextBox21.TabIndex = 2;
            materialTextBox21.TextChanged += UpdateInPagesSeyfPlus;
            // 
            // RashodPage
            // 
            RashodPage.Controls.Add(PhotoMessageRashod);
            RashodPage.Controls.Add(SeyfRasHod);
            RashodPage.Controls.Add(PostavkaRashod);
            RashodPage.Controls.Add(listBoxRas);
            RashodPage.Controls.Add(comboBoxNameRas);
            RashodPage.Controls.Add(Расход);
            RashodPage.Controls.Add(label21);
            RashodPage.Controls.Add(label9);
            RashodPage.Controls.Add(materialTextBox26);
            RashodPage.Controls.Add(materialTextBox25);
            RashodPage.Name = "RashodPage";
            RashodPage.TabIndex = 4;
            RashodPage.Text = "Расход";
            // 
            // PhotoMessageRashod
            // 
            PhotoMessageRashod.AutoSize = true;
            PhotoMessageRashod.Depth = 0;
            PhotoMessageRashod.ImeMode = ImeMode.NoControl;
            PhotoMessageRashod.Location = new Point(66, 153);
            PhotoMessageRashod.Margin = new Padding(0);
            PhotoMessageRashod.MouseLocation = new Point(-1, -1);
            PhotoMessageRashod.MouseState = MouseState.HOVER;
            PhotoMessageRashod.Name = "PhotoMessageRashod";
            PhotoMessageRashod.ReadOnly = false;
            PhotoMessageRashod.Ripple = true;
            PhotoMessageRashod.Size = new Size(167, 37);
            PhotoMessageRashod.TabIndex = 5;
            PhotoMessageRashod.Text = "Прикрепить фото";
            PhotoMessageRashod.UseVisualStyleBackColor = true;
            // 
            // SeyfRasHod
            // 
            SeyfRasHod.AutoSize = true;
            SeyfRasHod.Depth = 0;
            SeyfRasHod.ImeMode = ImeMode.NoControl;
            SeyfRasHod.Location = new Point(66, 305);
            SeyfRasHod.Margin = new Padding(0);
            SeyfRasHod.MouseLocation = new Point(-1, -1);
            SeyfRasHod.MouseState = MouseState.HOVER;
            SeyfRasHod.Name = "SeyfRasHod";
            SeyfRasHod.ReadOnly = false;
            SeyfRasHod.Ripple = true;
            SeyfRasHod.Size = new Size(151, 37);
            SeyfRasHod.TabIndex = 51;
            SeyfRasHod.Text = "Деньги с сейфа";
            SeyfRasHod.UseVisualStyleBackColor = true;
            // 
            // PostavkaRashod
            // 
            PostavkaRashod.AutoSize = true;
            PostavkaRashod.Depth = 0;
            PostavkaRashod.ImeMode = ImeMode.NoControl;
            PostavkaRashod.Location = new Point(65, 436);
            PostavkaRashod.Margin = new Padding(0);
            PostavkaRashod.MouseLocation = new Point(-1, -1);
            PostavkaRashod.MouseState = MouseState.HOVER;
            PostavkaRashod.Name = "PostavkaRashod";
            PostavkaRashod.ReadOnly = false;
            PostavkaRashod.Ripple = true;
            PostavkaRashod.Size = new Size(107, 37);
            PostavkaRashod.TabIndex = 53;
            PostavkaRashod.Text = "Поставка";
            PostavkaRashod.UseVisualStyleBackColor = true;
            // 
            // listBoxRas
            // 
            listBoxRas.Anchor = AnchorStyles.Right;
            listBoxRas.BackColor = Color.FromArgb(25, 0, 64);
            listBoxRas.BorderStyle = BorderStyle.None;
            listBoxRas.Font = new Font("Segoe UI", 17.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxRas.ForeColor = Color.YellowGreen;
            listBoxRas.FormattingEnabled = true;
            listBoxRas.HorizontalScrollbar = true;
            listBoxRas.ItemHeight = 31;
            listBoxRas.Location = new Point(1886, 591);
            listBoxRas.Name = "listBoxRas";
            listBoxRas.Size = new Size(941, 279);
            listBoxRas.TabIndex = 49;
            // 
            // comboBoxNameRas
            //
            comboBoxNameRas.Location = new Point(66, 234);
            comboBoxNameRas.Name = "comboBoxNameRas";
            comboBoxNameRas.Size = new Size(217, 49);
            comboBoxNameRas.TabIndex = 6;
            // 
            // Расход
            //
            Расход.Location = new Point(66, 685);
            Расход.Name = "Расход";
            Расход.Size = new Size(108, 36);
            Расход.TabIndex = 4;
            Расход.Text = "Отправить";
            Расход.Click += Расход_Click;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = Color.Transparent;
            label21.Font = new Font("Segoe UI", 17F);
            label21.ForeColor = Color.LimeGreen;
            label21.ImeMode = ImeMode.NoControl;
            label21.Location = new Point(61, 33);
            label21.Name = "label21";
            label21.Size = new Size(83, 31);
            label21.TabIndex = 3;
            label21.Text = "Сумма";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Microsoft Sans Serif", 17F);
            label9.ForeColor = Color.LimeGreen;
            label9.ImeMode = ImeMode.NoControl;
            label9.Location = new Point(340, 33);
            label9.Name = "label9";
            label9.Size = new Size(177, 29);
            label9.TabIndex = 2;
            label9.Text = "Комментарий";
            // 
            // materialTextBox26
            //
            materialTextBox26.Location = new Point(345, 65);
            materialTextBox26.Name = "materialTextBox26";
            materialTextBox26.Size = new Size(1030, 48);
            // 
            // materialTextBox25
            // 
            materialTextBox25.Location = new Point(66, 65);
            materialTextBox25.Name = "materialTextBox25";
            materialTextBox25.Size = new Size(217, 48);
            materialTextBox25.KeyPress += TextBox_KeyPress;
            // 
            // ShtraphPage
            // 
            ShtraphPage.Controls.Add(label6);
            ShtraphPage.Controls.Add(WhoVipisl);
            ShtraphPage.Controls.Add(listBox4);
            ShtraphPage.Controls.Add(label15);
            ShtraphPage.Controls.Add(label14);
            ShtraphPage.Controls.Add(materialTextBox2);
            ShtraphPage.Controls.Add(Штраф);
            ShtraphPage.Controls.Add(listBox5);
            ShtraphPage.Controls.Add(KomuVipisal);
            ShtraphPage.Name = "ShtraphPage";
            ShtraphPage.TabIndex = 2;
            ShtraphPage.Text = "Штрафы";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(64, 0, 64);
            label6.Font = new Font("Microsoft Sans Serif", 17F);
            label6.ForeColor = Color.LimeGreen;
            label6.ImeMode = ImeMode.NoControl;
            label6.Location = new Point(41, 635);
            label6.Name = "label6";
            label6.Size = new Size(208, 29);
            label6.TabIndex = 10;
            label6.Text = "Имя кто выписал";
            // 
            // WhoVipisl
            // 
            WhoVipisl.Location = new Point(44, 669);
            WhoVipisl.Name = "WhoVipisl";
            WhoVipisl.Size = new Size(262, 49);
            // 
            // listBox4
            // 
            listBox4.BackColor = Color.FromArgb(25, 0, 64);
            listBox4.BorderStyle = BorderStyle.None;
            listBox4.Font = new Font("Segoe UI", 17.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox4.ForeColor = Color.YellowGreen;
            listBox4.FormattingEnabled = true;
            listBox4.HorizontalScrollbar = true;
            listBox4.ItemHeight = 31;
            listBox4.Location = new Point(526, 18);
            listBox4.Name = "listBox4";
            listBox4.SelectionMode = SelectionMode.MultiExtended;
            listBox4.Size = new Size(911, 186);
            listBox4.TabIndex = 8;
            listBox4.TabStop = false;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Segoe UI", 17F);
            label15.ForeColor = Color.LimeGreen;
            label15.ImeMode = ImeMode.NoControl;
            label15.Location = new Point(343, 17);
            label15.Name = "label15";
            label15.Size = new Size(83, 31);
            label15.TabIndex = 7;
            label15.Text = "Сумма";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Segoe UI", 17F);
            label14.ForeColor = Color.LimeGreen;
            label14.ImeMode = ImeMode.NoControl;
            label14.Location = new Point(50, 18);
            label14.Name = "label14";
            label14.Size = new Size(59, 31);
            label14.TabIndex = 6;
            label14.Text = "Имя";
            // 
            // materialTextBox2
            //
            materialTextBox2.Location = new Point(348, 49);
            materialTextBox2.Name = "materialTextBox2";
            materialTextBox2.Size = new Size(161, 48);
            materialTextBox2.TabIndex = 5;
            materialTextBox2.KeyPress += TextBox_KeyPress;
            // 
            // Штраф
            // 
            Штраф.ImeMode = ImeMode.NoControl;
            Штраф.Location = new Point(668, 682);
            Штраф.Name = "Штраф";
            Штраф.Size = new Size(108, 36);
            Штраф.TabIndex = 2;
            Штраф.Text = "Отправить";
            Штраф.Click += Штраф_Click;
            // 
            // listBox5
            // 
            listBox5.BackColor = Color.FromArgb(25, 0, 64);
            listBox5.BorderStyle = BorderStyle.None;
            listBox5.Font = new Font("Segoe UI", 17.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox5.ForeColor = Color.YellowGreen;
            listBox5.FormattingEnabled = true;
            listBox5.HorizontalScrollbar = true;
            listBox5.ItemHeight = 31;
            listBox5.Location = new Point(55, 257);
            listBox5.Name = "listBox5";
            listBox5.SelectionMode = SelectionMode.MultiExtended;
            listBox5.Size = new Size(1382, 341);
            listBox5.TabIndex = 3;
            listBox5.TabStop = false;
            listBox5.SelectedIndexChanged += ListBox5_SelectedIndexChanged;
            // 
            // KomuVipisal
            //
            KomuVipisal.Location = new Point(55, 50);
            KomuVipisal.Name = "KomuVipisal";
            KomuVipisal.Size = new Size(220, 49);
            // 
            // InventPage
            // 
            InventPage.Controls.Add(listBoxNameInv);
            InventPage.Controls.Add(InventBTN);
            InventPage.Controls.Add(InventSum);
            InventPage.Controls.Add(thisButton1);
            InventPage.Name = "InventPage";
            InventPage.TabIndex = 6;
            InventPage.Text = "Инвентаризация";
            // 
            // listBoxNameInv
            // 
            listBoxNameInv.BackColor = Color.FromArgb(25, 0, 64);
            listBoxNameInv.BorderStyle = BorderStyle.None;
            listBoxNameInv.Font = new Font("Segoe UI", 17.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxNameInv.ForeColor = Color.YellowGreen;
            listBoxNameInv.FormattingEnabled = true;
            listBoxNameInv.HorizontalScrollbar = true;
            listBoxNameInv.ItemHeight = 31;
            listBoxNameInv.Location = new Point(105, 145);
            listBoxNameInv.Name = "listBoxNameInv";
            listBoxNameInv.Size = new Size(405, 434);
            listBoxNameInv.TabIndex = 2;
            // 
            // InventBTN
            //
            InventBTN.Location = new Point(105, 609);
            InventBTN.Name = "InventBTN";
            InventBTN.Size = new Size(170, 36);
            InventBTN.TabIndex = 1;
            InventBTN.Text = "Выписать Инвент";
            InventBTN.Click += InventBTN_Click;
            // 
            // InventSum
            // 
            InventSum.Location = new Point(105, 75);
            InventSum.MaxLength = 32767;
            InventSum.Size = new Size(170, 48);
            InventSum.KeyPress += TextBox_KeyPress;
            //
            //thisButton1
            //
            thisButton1.AutoSize = true;
            thisButton1.Location = new Point(1295, 672);
            thisButton1.Margin = new Padding(4, 6, 4, 6);
            thisButton1.MouseState = MouseState.HOVER;
            thisButton1.Name = "thisButton1";
            thisButton1.TabIndex = 4;
            thisButton1.Text = "Выписать итоги зарплат";
            thisButton1.Type = MaterialButton.MaterialButtonType.Contained;
            thisButton1.Click += ThisButton1_click;
            // 
            // materialTabSelector1
            // 
            materialTabSelector1.BackColor = SystemColors.ControlDarkDark;
            materialTabSelector1.BaseTabControl = materialTabControl1;
            materialTabSelector1.CharacterCasing = MaterialTabSelector.CustomCharacterCasing.Normal;
            materialTabSelector1.Depth = 0;
            materialTabSelector1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTabSelector1.Location = new Point(-25, 847);
            materialTabSelector1.MaximumSize = new Size(1737, 51);
            materialTabSelector1.MinimumSize = new Size(1737, 51);
            materialTabSelector1.MouseState = MouseState.HOVER;
            materialTabSelector1.Name = "materialTabSelector1";
            materialTabSelector1.Size = new Size(1737, 51);
            materialTabSelector1.TabIndex = 1;
            materialTabSelector1.Visible = false;
            // 
            // MainForm
            // 
            AcceptButton = AuthBtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 0, 64);
            ClientSize = new Size(1713, 899);
            Controls.Add(ExitBtn);
            Controls.Add(materialTabSelector1);
            Controls.Add(materialTabControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            FormStyle = FormStyles.ActionBar_None;
            Location = new Point(150, 150);
            MaximizeBox = false;
            MaximumSize = new Size(1713, 899);
            MinimizeBox = false;
            MinimumSize = new Size(1713, 899);
            Name = "MainForm";
            Padding = new Padding(3, 24, 3, 3);
            Text = "MainForm";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            materialTabControl1.ResumeLayout(false);
            AutherPage.ResumeLayout(false);
            AutherPage.PerformLayout();
            OtchetPage.ResumeLayout(false);
            OtchetPage.PerformLayout();
            AvansPage.ResumeLayout(false);
            AvansPage.PerformLayout();
            SeyfPlusPage.ResumeLayout(false);
            SeyfPlusPage.PerformLayout();
            RashodPage.ResumeLayout(false);
            RashodPage.PerformLayout();
            ShtraphPage.ResumeLayout(false);
            ShtraphPage.PerformLayout();
            InventPage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialButton ExitBtn;
        private MaterialButton AuthBtn;
        private MaterialButton Расчитать;
        private MaterialButton Отправить;
        private MaterialButton Аванс;
        private MaterialButton PlusSeyf;
        private MaterialButton Расход;
        private MaterialButton Штраф;
        private MaterialButton InventBTN;
        private MaterialButton thisButton1;

        private MaterialTabControl materialTabControl1;
        private MaterialTabSelector materialTabSelector1;

        private TabPage AutherPage;
        private TabPage OtchetPage;
        private TabPage AvansPage;
        private TabPage SeyfPlusPage;
        private TabPage RashodPage;
        private TabPage ShtraphPage;
        private TabPage InventPage;

        private MaterialTextBox2 PasswordTextBox;
        private MaterialTextBox2 Minus3;
        private MaterialTextBox2 HaursBox3;
        private MaterialTextBox2 Minus2;
        private MaterialTextBox2 Minus1;
        private MaterialTextBox2 HaursBox1;
        private MaterialTextBox2 HaursBox2;
        private MaterialTextBox2 TextBox8;
        private MaterialTextBox2 textBox7;
        private MaterialTextBox2 textBox5;
        private MaterialTextBox2 textBox4;
        private MaterialTextBox2 textBox3;
        private MaterialTextBox2 textBox2;
        private MaterialTextBox2 materialTextBox23;
        private MaterialTextBox2 materialTextBox22;
        private MaterialTextBox2 materialTextBox21;
        private MaterialTextBox2 materialTextBox26;
        private MaterialTextBox2 materialTextBox25;
        private MaterialTextBox2 InventSum;
        private MaterialTextBox2 materialTextBox2;
        private MaterialTextBox2 TextBoxType;

        private MaterialComboBox LoginBox;
        private MaterialComboBox ThertyComboBox;
        private MaterialComboBox SecondComboBoxNameOtchet;
        private MaterialComboBox NameComboBoxOtchet;
        private MaterialComboBox materialComboBox2;
        private MaterialComboBox comboBoxNameRas;
        private MaterialComboBox WhoVipisl;
        private MaterialComboBox KomuVipisal;

        private MaterialCheckbox Otpusknie;
        private MaterialCheckbox BnAvansCheck;
        private MaterialCheckbox ZPcheak;
        private MaterialCheckbox Premia;
        private MaterialCheckbox AvansCheack;
        private MaterialCheckbox MinusPoSeyf;
        private MaterialCheckbox materialCheckbox1;
        private MaterialCheckbox PhotoMessageRashod;
        private MaterialCheckbox SeyfRasHod;
        private MaterialCheckbox PostavkaRashod;

        private Label label22;
        private Label label21;
        private Label label20;
        private Label label19;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label labelType;

        private ThisListBox listBox2;
        private ThisListBox listBox1;
        private ThisListBox listBox3;
        private ThisListBox listBoxRas;
        private ThisListBox listBox4;
        private ThisListBox listBox5;
        private ThisListBox listBoxNameInv;
        private ThisListBox listBox6;
    }
}