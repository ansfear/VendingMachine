using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using VendingMachine.Models;

namespace VendingMachine.Data
{
    public class FileDataService
    {
        private const string ProductsFilePath = "products.json";
        private const string CardFilePath = "card.json";

        public List<Product> LoadProducts()
        {
            if (!File.Exists(ProductsFilePath))
            {
                // Если файла нет — создаём дефолтный набор товаров
                var defaultProducts = new List<Product>
                {
                    new Product { Slot = 1, Name = "Чипсы", Price = 60, Stock = 5 },
                    new Product { Slot = 2, Name = "Кола", Price = 80, Stock = 3 },
                    new Product { Slot = 3, Name = "Шоколад", Price = 70, Stock = 4 },
                    new Product { Slot = 4, Name = "Вода", Price = 40, Stock = 0 }, // Нет в наличии
                    new Product { Slot = 5, Name = "Батончик", Price = 50, Stock = 2 }
                };

                SaveProducts(defaultProducts);
                return defaultProducts;
            }

            var json = File.ReadAllText(ProductsFilePath);
            return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        public void SaveProducts(List<Product> products)
        {
            var json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ProductsFilePath, json);
        }

        public CardBalance LoadCardBalance()
        {
            if (!File.Exists(CardFilePath))
            {
                var defaultCard = new CardBalance { Balance = 500.0m };
                SaveCardBalance(defaultCard);
                return defaultCard;
            }

            var json = File.ReadAllText(CardFilePath);
            return JsonSerializer.Deserialize<CardBalance>(json) ?? new CardBalance();
        }

        public void SaveCardBalance(CardBalance card)
        {
            var json = JsonSerializer.Serialize(card, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(CardFilePath, json);
        }
    }
}