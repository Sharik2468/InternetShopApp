using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBAccess;
using PL.Model;

namespace PL
{
    class CategoryService
    {
        InternetShopEntities db;

        public CategoryService()
        {
            db = new InternetShopEntities();
        }

        public List<CategoryModel> GetCategory()
        {
            var c = db.Category_Table.AsEnumerable().Select(o => new CategoryModel(o));
            var p = c.Where(s => s.Category_ID > 4).ToList();
            // return db.Category_Table.AsEnumerable().Select(o => new CategoryModel(o)).ToList();
            return p;
        }

        public List<String> GetCategoryName()
        {
            List<String> Result = new List<String>();
            var c = GetCategory();
            foreach (CategoryModel CategoryItem in c)
                Result.Add(CategoryItem.Category_Name);

            return Result;
        }
        public List<CategoryModel> GetCategoryByParentID(int ParentID)
        {
            var c = db.Category_Table.AsEnumerable().Select(o => new CategoryModel(o));
            var p = c.Where(s => s.Parent_ID == ParentID && s.Category_ID!=ParentID).ToList();
            // return db.Category_Table.AsEnumerable().Select(o => new CategoryModel(o)).ToList();
            return p;
        }

        public CategoryModel GetCategoryIDByName(string CategoryName)
        {
            var c = GetCategory();
            var p = c.Where(s => s.Category_Name == CategoryName).First();
            return p;
        }
    }
}
