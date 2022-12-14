using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DBAccess;
using PL.Model;

namespace PL
{
    class ProductService
    {
        InternetShopEntities db;
        public ProductService()
        {
            db = new InternetShopEntities();
        }

        public List<Product> GetProducts(ClientVariety Table = ClientVariety.Покупатель)
        {
            switch (Table)
            {
                case ClientVariety.Покупатель: return db.Product_Table.AsEnumerable().Select(o => new Product(o)).Where(s => s.NumberInStock > 0).ToList();
                case ClientVariety.Продавец: return db.Product_Table.AsEnumerable().Select(o => new Product(o)).ToList();
            }
            return null;
        }

        public void DeleteProduct(Model.Product product)
        {
            var db = new InternetShopEntities();

            Product_Table p = db.Product_Table.Where(s => s.Product_Code == product.Product_Code).First();
            db.Product_Table.Remove(p);
            db.SaveChanges();
        }

        public void AddProduct(Model.Product product, string photoUri)
        {
            var db = new InternetShopEntities();

            var max = new Product_Table();
            foreach (var entry in db.Product_Table)
            {
                if (entry.Product_Code > max.Product_Code)
                {
                    max = entry;
                }
            }

            var dbProduct = new DBAccess.Product_Table()
            {
                Product_Code = max.Product_Code + 1,
                Name_Product = product.Name,
                Purchase_Price_Product = product.PurchasePrice,
                Best_Before_Date_Product = (int)product.BestBeforeDate,
                Number_in_Stock = 1,
                Description = product.Desctription,
                Category_ID = product.CategoryID,
                Market_Price_Product = product.MarketPrice,
                Date_of_Manufacture_Product = product.DateOfManufacture
            };

            try
            {
                dbProduct.Image = File.ReadAllBytes(photoUri);
            }
            catch { }


            db.Product_Table.Add(dbProduct);
            db.SaveChanges();

            System.Windows.MessageBox.Show("Товар успешно добавлен");

        }

        public void Update(Model.Product product)
        {

            var dbProduct = db.Product_Table.FirstOrDefault(u => u.Product_Code == product.Product_Code);
            dbProduct.Name_Product = product.Name;
            dbProduct.Purchase_Price_Product = product.PurchasePrice;
            dbProduct.Best_Before_Date_Product = (int?)product.BestBeforeDate;
            dbProduct.Number_in_Stock = product.NumberInStock;
            dbProduct.Description = product.Desctription;
            db.SaveChanges();

        }

        public List<Product> GetProductByID(int ID)
        {
            return db.Product_Table.AsEnumerable().Select(o => new Product(o)).Where(s => s.Product_Code == ID).ToList();
        }

        public List<Product> GetProductByCategoryID(int CategoryID, ClientVariety variant)
        {
            switch (variant)
            {
                case ClientVariety.Покупатель:
                    return db.Product_Table.AsEnumerable().Select(o => new Product(o)).Where(s => s.CategoryID == CategoryID
                                                                                               && s.NumberInStock > 0).ToList();
                case ClientVariety.Продавец:
                    return db.Product_Table.AsEnumerable().Select(o => new Product(o)).Where(s => s.CategoryID == CategoryID).ToList();
            }
            return null;
        }

        public List<Product> GetProductByText(string Text, ClientVariety variant)
        {
            List<Product> ResultProducts = new List<Product>();
            var products = GetProducts(variant);

            foreach (var prod in products)
            {
                switch (variant)
                {
                    case ClientVariety.Покупатель:
                        if ((Regex.IsMatch(prod.Name, "\\b" + Text + "\\b") ||
                            Regex.IsMatch(prod.Desctription, "\\b" + Text + "\\b")) &&
                            prod.NumberInStock > 0) ResultProducts.Add(prod); break;

                    case ClientVariety.Продавец:
                        if (Regex.IsMatch(prod.Name, "\\b" + Text + "\\b") ||
                            Regex.IsMatch(prod.Desctription, "\\b" + Text + "\\b")) ResultProducts.Add(prod); break;

                }
            }

            return ResultProducts;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
