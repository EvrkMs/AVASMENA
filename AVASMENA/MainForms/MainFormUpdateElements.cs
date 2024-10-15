using MaterialSkin.Controls;

namespace AVASMENA.MainForms
{
    partial class MainForm
    {
        //запуск логирования при нажатие на Энтр
        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Logining();
        }

        //один чекбокс среди своих
        private void CheckBoxUpdateInPagesAvans(object? sender, List<MaterialCheckbox> list)
        {
            if (sender is not CheckBox changedCheckBox)
                throw new Exception("Ошибка инициализации в CheckBoxUpdateInPagesAvans");
            if (changedCheckBox.Checked)
            {
                foreach (var checkBox in list)
                {
                    if (checkBox != changedCheckBox)
                    {
                        checkBox.Checked = false;
                    }
                }
            }
            else
            {
                // Проверка, если все CheckBox установлены в false, то AvansCheack устанавливается в true
                if (list.All(cb => !cb.Checked))
                {
                    AvansCheack.Checked = true;
                }
            }
        }
        //ввод только цыфр
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender != TextBox8)
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

    }
}
