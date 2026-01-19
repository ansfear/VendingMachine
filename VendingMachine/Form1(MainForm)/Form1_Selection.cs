using System;
using System.Windows.Forms;

namespace VendingMachine
{
    public partial class Form1
    {
        private void btnNum_Click(object sender, EventArgs e)
        {
            if (_selectedProduct != null) return;

            var digit = ((Button)sender).Text;
            if (_inputBuffer.Length == 0 && digit != "0")
            {
                _inputBuffer = digit;
                ShowMessage($"Ввод: {_inputBuffer}");
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_inputBuffer))
            {
                ShowMessage("❗ Введите номер товара");
                return;
            }

            if (int.TryParse(_inputBuffer, out int slot) && slot >= 1 && slot <= 5)
            {
                var product = _products.Find(p => p.Slot == slot);
                if (product == null || !product.IsAvailable)
                {
                    ShowMessage($"❌ Товар {slot} недоступен");
                    _inputBuffer = "";
                    return;
                }

                _selectedProduct = product;
                ShowMessage($"{product.Name}\nЦена: {product.Price:F0} руб.\nОплатите!");
                _inputBuffer = "";
            }
            else
            {
                ShowMessage("❗ Неверный номер (1–5)");
                _inputBuffer = "";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _inputBuffer = "";
            _selectedProduct = null;
            ShowMessage("Выберите товар (1–5)");
        }
    }
}