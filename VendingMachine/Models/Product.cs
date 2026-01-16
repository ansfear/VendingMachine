using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Models
{
    public class Product
    {
        public int Slot { get; set; }         // Номер лотка 
        public string Name { get; set; }      // Название товара
        public decimal Price { get; set; }    // Цена в рублях
        public int Stock { get; set; }        // Количество в лотке

        public bool IsAvailable => Stock > 0; // Доступен ли товар
    }
}
