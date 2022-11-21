using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DBAccess;
using PL.Model;

namespace PL
{
    class ProductService
    {
        InternetShopEntities db;
        public ProductService()
        {
            db = new InternetShopEntities();//3lab
        }

        public List<Product> GetProducts()
        {
            return db.Product_Table.AsEnumerable().Select(o => new Product(o)).ToList();
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
                Purchase_Price_Product = product.Price,
                Best_Before_Date_Product = (int)product.BestBeforeDate,
                Number_in_Stock = product.NumberInStock.ToString(),
                Description = product.Desctription
            };

            try
            {
                dbProduct.Image = File.ReadAllBytes(photoUri);
            }
            catch { }


            db.Product_Table.Add(dbProduct);
            db.SaveChanges();

        }

        public void Update(Model.Product product)
        {

            var dbProduct = db.Product_Table.FirstOrDefault(u => u.Product_Code == product.Product_Code);
            dbProduct.Name_Product = product.Name;
            dbProduct.Purchase_Price_Product = product.Price;
            dbProduct.Best_Before_Date_Product = (int?)product.BestBeforeDate;
            dbProduct.Number_in_Stock = product.NumberInStock.ToString();
            dbProduct.Description = product.Desctription;
            db.SaveChanges();

        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
