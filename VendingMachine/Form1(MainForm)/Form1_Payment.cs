using System;
using System.Windows.Forms;
using VendingMachine.Data;

namespace VendingMachine
{
    public partial class Form1
    {
        private void PayCash_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null)
            {
                ShowMessage("❗ Выберите товар");
                return;
            }

            var cashForm = new CashPaymentForm(_selectedProduct);
            cashForm.ShowDialog();

            if (cashForm.ShouldDispense)
            {
                // Выдача товара
                string productName = _selectedProduct.Name;
                decimal productPrice = _selectedProduct.Price;
                decimal change = cashForm.InsertedAmount - productPrice;

                DispenseProduct();

                // Обновляем кассу
                var cashBox = _dataService.LoadCashBox();
                cashBox.Cash += productPrice;
                _dataService.SaveCashBox(cashBox);

                // Показываем результат
                ShowMessage($"✅ Товар выдан!\nСдача: {change:F0} руб.", autoReset: true);

                _insertedAmount = 0;
                _selectedProduct = null;
                _inputBuffer = "";
            }
            else if (cashForm.ShouldRefund)
            {
                // Возврат
                _insertedAmount = cashForm.InsertedAmount;
                ShowMessage($"↩ Возвращено: {_insertedAmount:F0} руб.");
                _insertedAmount = 0;
                _selectedProduct = null;
            }
        }

        private void PayCard_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null)
            {
                ShowMessage("❗ Выберите товар");
                return;
            }

            var card = _dataService.LoadCardBalance();

            if (card.Balance < _selectedProduct.Price)
            {
                ShowMessage("💳 Недостаточно средств на карте");
                return;
            }

            string productName = _selectedProduct.Name;

            card.Balance -= _selectedProduct.Price;
            _dataService.SaveCardBalance(card);

            var cashBox = _dataService.LoadCashBox();
            cashBox.Electronic += _selectedProduct.Price;
            _dataService.SaveCashBox(cashBox);

            DispenseProduct();

            ShowMessage("✅ Товар выдан!", autoReset: true);
            _selectedProduct = null;
            _inputBuffer = "";

            UpdateUI();
        }

        private void DispenseProduct()
        {
            if (_selectedProduct == null) return;

            _selectedProduct.Stock--;
            _dataService.SaveProducts(_products);

            UpdateUI();
        }
    }
}