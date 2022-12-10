using DBAccess;
using PL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PL
{
    class UserService
    {
        InternetShopEntities db;

        public UserService()
        {
            db = new InternetShopEntities();
        }

        public List<UserModel> GetClients()
        {
            var c = db.Client_Table.AsEnumerable().Select(o => new UserModel(o));
            return c.ToList();
        }
        public UserModel GetClientFull(UserModel User)
        {
            var c = db.Client_Table.AsEnumerable().Select(o => new UserModel(o)).
                Where(s => s.Name == User.Name &&
                s.Password == User.Password &&
                s.Location_Code == User.Location_Code &&
                s.Surname == User.Surname &&
                s.Telephone_Number == User.Telephone_Number).FirstOrDefault();
            return c;
        }

        public SalesmanModel GetSalesmanFull(SalesmanModel User)
        {
            var c = db.Salesman_Table.AsEnumerable().Select(o => new SalesmanModel(o))
                .Where(s => s.Saleman_Name == User.Saleman_Name &&
                s.Password == User.Password &&
                s.Salesman_Surname == User.Salesman_Surname).FirstOrDefault();
            return c;
        }
        public List<SalesmanModel> GetSalesmans()
        {
            var c = db.Salesman_Table.AsEnumerable().Select(o => new SalesmanModel(o));
            return c.ToList();
        }
    }
}
