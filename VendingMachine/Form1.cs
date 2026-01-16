using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Windows.Forms;
using VendingMachine.Data;
using VendingMachine.Models;

namespace VendingMachine
{
    public partial class Form1 : Form
    {
        private List<Product> _products;
        private decimal _insertedAmount = 0;
        private int? _selectedSlot = null; // Выбранный лоток (пока не выбран)
        private Product _selectedProduct = null; // Выбранный товар
        private FileDataService _dataService;

        public Form1()
        {
            InitializeComponent();
            _dataService = new FileDataService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProductsFromStorage();
            UpdateUI();
            btnSlot1.Click += (s, e) => SelectProduct(1);
            btnSlot2.Click += (s, e) => SelectProduct(2);
            btnSlot3.Click += (s, e) => SelectProduct(3);
            btnSlot4.Click += (s, e) => SelectProduct(4);
            btnSlot5.Click += (s, e) => SelectProduct(5);

            btnPayCash.Click += PayCash_Click;
            btnPayCard.Click += PayCard_Click;
            btnRefund.Click += Refund_Click;
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

                button.Text = $"{slot}. {product.Name} — {product.Price} руб.";

                if (product.IsAvailable)
                {
                    button.Enabled = true;
                    button.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    button.Enabled = false;
                    button.BackColor = System.Drawing.Color.LightCoral;
                }
            }

            lblInserted.Text = $"Внесено: {_insertedAmount:F0} руб.";
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

        private void SelectProduct(int slot)
        {
            var product = _products.Find(p => p.Slot == slot);
            if (product == null)
            {
                MessageBox.Show("Товар не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!product.IsAvailable)
            {
                MessageBox.Show($"Товар '{product.Name}' закончился. Пожалуйста, выберите другой.", "Нет в наличии", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _selectedProduct = product;
            MessageBox.Show($"Выбран товар: {product.Name} — {product.Price} руб.", "Товар выбран", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void PayCash_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null)
            {
                MessageBox.Show("Сначала выберите товар!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var amount = PromptInput("Введите сумму (руб.):");
            if (amount <= 0) return;

            _insertedAmount += amount;
            UpdateUI();

            if (_insertedAmount >= _selectedProduct.Price)
            {
                // Выдаём товар
                string productName = _selectedProduct.Name;
                decimal change = _insertedAmount - _selectedProduct.Price;

                DispenseProduct(); // ← теперь без MessageBox

                MessageBox.Show($"✅ Товар '{productName}' выдан!\nСдача: {change:F0} руб.",
                                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _insertedAmount = 0;
                _selectedProduct = null;
                UpdateUI();
            }
            else
            {
                MessageBox.Show($"Недостаточно средств. Нужно ещё {_selectedProduct.Price - _insertedAmount:F0} руб.",
                                "Недостаточно", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PayCard_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null)
            {
                MessageBox.Show("Сначала выберите товар!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var card = _dataService.LoadCardBalance();

            if (card.Balance < _selectedProduct.Price)
            {
                MessageBox.Show($"Недостаточно средств на карте.\nНужно: {_selectedProduct.Price:F0} руб.\nНа карте: {card.Balance:F0} руб.",
                                "Ошибка оплаты", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Сохраняем имя товара, чтобы показать в сообщении
            string productName = _selectedProduct.Name;

            // Списываем деньги
            card.Balance -= _selectedProduct.Price;
            _dataService.SaveCardBalance(card);

            // Выдаём товар (внутри DispenseProduct() будет обновлён UI и сброшен _selectedProduct)
            DispenseProduct();

            // Уведомление — используем сохранённое имя
            MessageBox.Show($"✅ Товар '{productName}' выдан!\nОплачено картой.",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // _selectedProduct уже null — не нужно снова сбрасывать
            UpdateUI();
        }

        private void Refund_Click(object sender, EventArgs e)
        {
            if (_insertedAmount > 0)
            {
                MessageBox.Show($"Возвращено {_insertedAmount:F0} руб.", "Возврат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _insertedAmount = 0;
                _selectedProduct = null; // Сбрасываем выбор
                UpdateUI();
            }
            else
            {
                MessageBox.Show("Нет внесённых средств для возврата.", "Возврат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DispenseProduct()
        {
            if (_selectedProduct == null) return;

            // Уменьшаем количество
            _selectedProduct.Stock--;
            _dataService.SaveProducts(_products); // Сохраняем изменения в файл

            // Обновляем UI
            UpdateUI();
        }

        // Вспомогательный метод для ввода суммы
        private decimal PromptInput(string message)
        {
            var input = Microsoft.VisualBasic.Interaction.InputBox(message, "Ввод", "0");
            if (decimal.TryParse(input, out decimal value))
                return value;
            else
                return 0;
        }


        private decimal GetCardBalance()
        {
            string json = File.ReadAllText("card.json");
            var data = JsonSerializer.Deserialize<CardData>(json);
            return data.Balance;
        }

        private void UpdateCardBalance(decimal newBalance)
        {
            var data = new CardData { Balance = newBalance };
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("card.json", json);
        }

        // Вспомогательный класс для десериализации JSON
        public class CardData
        {
            public decimal Balance { get; set; }
        }
    }
}