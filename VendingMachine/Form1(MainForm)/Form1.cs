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
    }
}