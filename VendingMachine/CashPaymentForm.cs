using System;
using System.Windows.Forms;
using VendingMachine.Models;

namespace VendingMachine
{
    public partial class CashPaymentForm : Form
    {
        public decimal InsertedAmount { get; private set; } = 0;
        public bool ShouldDispense { get; private set; } = false;
        public bool ShouldRefund { get; private set; } = false;

        private Product _selectedProduct;

        public CashPaymentForm(Product product)
        {
            InitializeComponent();
            _selectedProduct = product;
            lblAmount.Text = "Внесено: 0 руб.";
            Text = $"Оплата: {_selectedProduct.Name} ({_selectedProduct.Price} руб.)";
        }

        private void UpdateDisplay()
        {
            lblAmount.Text = $"Внесено: {InsertedAmount:F0} руб.";
        }

        private void AddBill(decimal value)
        {
            InsertedAmount += value;
            UpdateDisplay();
        }

        private void btn10_Click(object sender, EventArgs e) => AddBill(10);
        private void btn50_Click(object sender, EventArgs e) => AddBill(50);
        private void btn100_Click(object sender, EventArgs e) => AddBill(100);
        private void btn500_Click(object sender, EventArgs e) => AddBill(500);

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (InsertedAmount >= _selectedProduct.Price)
            {
                ShouldDispense = true;
                Close();
            }
            else
            {
                MessageBox.Show($"Недостаточно средств. Нужно ещё {_selectedProduct.Price - InsertedAmount:F0} руб.");
            }
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            ShouldRefund = true;
            Close();
        }

        private void CashPaymentForm_Load(object sender, EventArgs e)
        {

        }
    }
}