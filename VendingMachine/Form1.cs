using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Windows.Forms;
using VendingMachine.Data;
using VendingMachine.Models;
using System.IO;

namespace VendingMachine
{
    public partial class Form1 : Form
    {
        private List<Product> _products = new List<Product>();
        private decimal _insertedAmount = 0;
        private Product _selectedProduct = null; // Выбранный товар
        private FileDataService _dataService;
        private string _inputBuffer = "";

        public Form1()
        {
            InitializeComponent();
            _dataService = new FileDataService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProductsFromStorage();
            UpdateUI();
            btnNum0.Click += btnNum_Click;
            btnNum1.Click += btnNum_Click;
            btnNum2.Click += btnNum_Click;
            btnNum3.Click += btnNum_Click;
            btnNum4.Click += btnNum_Click;
            btnNum5.Click += btnNum_Click;
            btnNum6.Click += btnNum_Click;
            btnNum7.Click += btnNum_Click;
            btnNum8.Click += btnNum_Click;
            btnNum9.Click += btnNum_Click;

            btnSelect.Click += btnSelect_Click;
            btnClear.Click += btnClear_Click;

            btnPayCash.Click += PayCash_Click;
            btnPayCard.Click += PayCard_Click;

            ShowMessage("Выберите товар (1–5)");
        }

        private void LoadProductsFromStorage()
        {
            _products = _dataService.LoadProducts();
            Debug.WriteLine("Товары загружены:");
            foreach (var p in _products)
                Debug.WriteLine($"  Лоток {p.Slot}: {p.Name}, {p.Price} руб., осталось {p.Stock}");
        }

        private void UpdateUI()
        {
            for (int slot = 1; slot <= 5; slot++)
            {
                var product = _products.Find(p => p.Slot == slot);
                if (product == null) continue;

                var button = GetButtonBySlot(slot);
                if (button == null) continue;

                button.Text = $"{slot}. {product.Name} \n {product.Price} руб.";

                if (product.IsAvailable)
                {
                    button.Enabled = true;
                    button.BackColor = Color.White;
                    button.ForeColor = Color.Black;
                }
                else
                {
                    button.Enabled = false;
                    button.BackColor = Color.FromArgb(255, 210, 210);
                    button.ForeColor = Color.Gray;
                }
            }
        }

        private Button GetButtonBySlot(int slot)
        {
            return slot switch
            {
                1 => btnSlot1,
                2 => btnSlot2,
                3 => btnSlot3,
                4 => btnSlot4,
                5 => btnSlot5,
                _ => null
            };
        }

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

        private void OpenStaffPanel()
        {
            var staffForm = new StaffPanelForm();
            staffForm.ShowDialog();
        }

        private void btnOpenStaff_Click(object sender, EventArgs e)
        {
            var pin = Microsoft.VisualBasic.Interaction.InputBox("Введите ПИН-код:", "Доступ персонала", "");
            if (pin == "12345")
            {
                OpenStaffPanel();
            }
            else
            {
                MessageBox.Show("Неверный ПИН!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowMessage(string message, bool autoReset = false)
        {
            lblDisplay.Text = message;

            if (autoReset)
            {
                var timer = new System.Windows.Forms.Timer();
                timer.Interval = 2000;
                timer.Tick += (s, e) =>
                {
                    lblDisplay.Text = "Выберите товар (1–5)";
                    ((System.Windows.Forms.Timer)s).Stop();
                };
                timer.Start();
            }
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            if (_selectedProduct != null) return; // если уже выбран — игнорируем

            var digit = ((Button)sender).Text;
            if (_inputBuffer.Length == 0 && digit != "0") // только одна цифра (1–5)
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
                _inputBuffer = ""; // сброс ввода
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