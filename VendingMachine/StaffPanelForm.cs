using System;
using System.Windows.Forms;
using VendingMachine.Data;
using VendingMachine.Models;

namespace VendingMachine
{
    public partial class StaffPanelForm : Form
    {
        private FileDataService _dataService = new FileDataService();

        public StaffPanelForm()
        {
            InitializeComponent();
            LoadData();
        }


        private void StaffPanelForm_Load(object sender, EventArgs e)
        {
            btnRestock1.Click += btnRestock_Click;
            btnRestock2.Click += btnRestock_Click;
            btnRestock3.Click += btnRestock_Click;
            btnRestock4.Click += btnRestock_Click;
            btnRestock5.Click += btnRestock_Click;
            LoadData();
        }

        private void LoadData()
        {
            var box = _dataService.LoadCashBox();
            lblCash.Text = $"Наличные: {box.Cash:F0} руб.";
            lblElectronic.Text = $"Электронные: {box.Electronic:F0} руб.";
            var products = _dataService.LoadProducts();
            lblStock1.Text = $"Лоток 1: {products.FirstOrDefault(p => p.Slot == 1)?.Stock ?? 0} шт.";
            lblStock2.Text = $"Лоток 2: {products.FirstOrDefault(p => p.Slot == 2)?.Stock ?? 0} шт.";
            lblStock3.Text = $"Лоток 3: {products.FirstOrDefault(p => p.Slot == 3)?.Stock ?? 0} шт.";
            lblStock4.Text = $"Лоток 4: {products.FirstOrDefault(p => p.Slot == 4)?.Stock ?? 0} шт.";
            lblStock5.Text = $"Лоток 5: {products.FirstOrDefault(p => p.Slot == 5)?.Stock ?? 0} шт.";
        }

        private void btnWithdrawCash_Click(object sender, EventArgs e)
        {
            Withdraw("Наличные", isCash: true);
        }

        private void btnWithdrawElectronic_Click(object sender, EventArgs e)
        {
            Withdraw("Электронные", isCash: false);
        }

        private void Withdraw(string type, bool isCash)
        {
            var amountStr = Microsoft.VisualBasic.Interaction.InputBox($"Сколько {type.ToLower()} забрать?", "Вывод средств", "0");
            if (!decimal.TryParse(amountStr, out decimal amount) || amount <= 0)
                return;

            var box = _dataService.LoadCashBox();
            decimal current = isCash ? box.Cash : box.Electronic;

            if (amount > current)
            {
                MessageBox.Show($"Недостаточно средств. Доступно: {current:F0} руб.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isCash)
                box.Cash -= amount;
            else
                box.Electronic -= amount;

            _dataService.SaveCashBox(box);
            LoadData(); // Обновляем отображение

            MessageBox.Show($"{amount:F0} руб. ({type.ToLower()}) успешно изъяты.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRestock_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (int.TryParse(button.Name.Replace("btnRestock", ""), out int slot))
            {
                var amountStr = Microsoft.VisualBasic.Interaction.InputBox($"Сколько добавить в лоток {slot}?", "Пополнение", "0");
                if (!decimal.TryParse(amountStr, out decimal amount) || amount <= 0)
                    return;

                var products = _dataService.LoadProducts();
                var product = products.Find(p => p.Slot == slot);
                if (product != null)
                {
                    product.Stock += (int)amount;
                    _dataService.SaveProducts(products);

                    // Обновляем отображение
                    LoadData();
                }
            }
        }


    }
}