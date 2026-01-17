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

        private void LoadData()
        {
            var box = _dataService.LoadCashBox();
            lblCash.Text = $"Наличные: {box.Cash:F0} руб.";
            lblElectronic.Text = $"Электронные: {box.Electronic:F0} руб.";
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



        private void StaffPanelForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}