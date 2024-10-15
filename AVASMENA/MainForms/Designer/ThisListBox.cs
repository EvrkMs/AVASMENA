using MaterialSkin;
using MaterialSkin.Controls;
using System.ComponentModel;

namespace AVASMENA.MainForms.Designer
{
    public class ThisListBox : ListBox
    {
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Font Font
        {
            get => base.Font;
            set => base.Font = value;
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public new Color ForeColor
        {
            get => base.ForeColor;
            set => base.ForeColor = value;
        }
        public ThisListBox()
        {
            Font = new Font("Segoe UI", 17.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BorderStyle = BorderStyle.None;
            BackColor = Color.FromArgb(25, 0, 64);
            ForeColor = Color.YellowGreen;
            FormattingEnabled = true;
            HorizontalScrollbar = true;
            ItemHeight = 31;
        }
    }
    public class ThisLabel : System.Windows.Forms.Label
    {
        public ThisLabel()
        {
            ImeMode = ImeMode.NoControl;
            Font = new Font("Segoe UI", 17F);
            ForeColor = Color.LimeGreen;
            BackColor = Color.Transparent;
            AutoSize = true;
        }
    }
    public class ThisCheackBox : MaterialCheckbox
    {
        public ThisCheackBox()
        {
            ImeMode = ImeMode.NoControl;
            MouseLocation = new Point(-1, -1);
            UseVisualStyleBackColor = true;
            MouseState = MouseState.HOVER;
            ReadOnly = false;
            Ripple = true;
            Margin = new Padding(0);
            AutoSize = true;
            Depth = 0;
        }
    }
    public class ThisComboBox : MaterialComboBox
    {
        public ThisComboBox()
        {
            AutoResize = false;
            BackColor = Color.FromArgb(255, 255, 255);
            Depth = 0;
            DrawMode = DrawMode.OwnerDrawVariable;
            DropDownHeight = 174;
            DropDownStyle = ComboBoxStyle.DropDownList;
            DropDownWidth = 121;
            Font = new Font("Segoe UI", 17F, FontStyle.Bold, GraphicsUnit.Pixel);
            ForeColor = Color.FromArgb(222, 0, 0, 0);
            FormattingEnabled = true;
            IntegralHeight = false;
            ItemHeight = 43;
            MouseState = MouseState.OUT;
            StartIndex = 0;
            TabIndex = 0;
        }
    }

    public class ThisTextBox : MaterialTextBox2
    {
        public ThisTextBox()
        {
            Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            PasswordChar = '\0';
            PrefixSuffixText = null;
            ReadOnly = false;
            RightToLeft = RightToLeft.No;
            MouseState = MouseState.OUT;
            AnimateReadOnly = false;
            BackgroundImageLayout = ImageLayout.None;
            CharacterCasing = CharacterCasing.Normal;
            Depth = 0;
            TabStop = false;
            TextAlign = HorizontalAlignment.Left;
            TrailingIcon = null;
            SelectionLength = 0;
            SelectionStart = 0;
            ShortcutsEnabled = true;
            SelectedText = "";
            HideSelection = true;
            LeadingIcon = null;
            MaxLength = 32767;
        }
    }
    public class ThisTabPage : TabPage
    {
        public ThisTabPage()
        {
            BackColor = Color.FromArgb(64, 0, 64);
            Size = new Size(1713, 852);
            Location = new Point(4, 24);
            Padding = new Padding(3);
        }
    }

    public class ThisButton : MaterialButton
    {
        public ThisButton()
        {
            AutoSize = false;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Density = MaterialButtonDensity.Default;
            Depth = 0;
            HighEmphasis = true;
            Icon = null;
            ImeMode = ImeMode.NoControl;
            Margin = new Padding(4, 6, 4, 6);
            MouseState = MouseState.HOVER;
            NoAccentTextColor = Color.Empty;
            Type = MaterialButtonType.Contained;
            UseAccentColor = false;
            UseVisualStyleBackColor = true;

        }
    }
}