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

        public UserModel GetClientByID(int ID)
        {
            return db.Client_Table.AsEnumerable().Select(o => new UserModel(o)).Where(s => s.Client_Code == ID).First();
        }
        public UserModel GetClientFull(UserModel User)
        {
            var c = db.Client_Table.AsEnumerable().Select(o => new UserModel(o)).
                Where(s => s.Name == User.Name &&
                s.Password == User.Password &&
                s.Surname == User.Surname).FirstOrDefault();

            if (c == null) return c;

            c.UserTable = ClientVariety.Покупатель;
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

        public int GetLocationCodeByName(string Name)
        {
            return db.Location_Table.AsEnumerable().Select(o => new LocationModel(o))
                .Where(s => s.Name == Name).FirstOrDefault().Location_Code;
        }

        public bool FindRepeatUser(UserModel NewUser)
        {
            switch (NewUser.UserTable)
            {
                case ClientVariety.Покупатель:
                    return db.Client_Table.AsEnumerable().Select(o => new UserModel(o))
                        .Where(s => s.Name == NewUser.Name
                        && s.Surname == NewUser.Surname
                        && s.Password == NewUser.Password).FirstOrDefault() != null ? true : false;

                case ClientVariety.Продавец:
                    return db.Salesman_Table.AsEnumerable().Select(o => new UserModel(o))
                        .Where(s => s.Name == NewUser.Name
                        && s.Surname == NewUser.Surname
                        && s.Password == NewUser.Password).FirstOrDefault() != null ? true : false;
            }
            return false;
        }

        public void AddClient(Model.UserModel Client, string TableChoose)
        {
            int max = GetMaxClientCode(TableChoose);

            if (TableChoose == "Покупатель")
            {
                var dbClient = new Client_Table()
                {
                    Client_Code = max + 1,
                    Name = Client.Name,
                    Surname = Client.Surname,
                    Telephone_Number = Client.Telephone_Number,
                    Password = Client.Password,
                    Location_Code = Client.Location_Code,

                };
                db.Client_Table.Add(dbClient);
                db.SaveChanges();
            }
            else
            {
                var dbSalesMan = new Salesman_Table()
                {
                    Salesman_Code = max + 1,
                    Saleman_Name = Client.Name,
                    Salesman_Surname = Client.Surname,
                    Telephone_Number = Client.Telephone_Number,
                    Password = Client.Password,
                    Location_Code = Client.Location_Code,
                };
                db.Salesman_Table.Add(dbSalesMan);
                db.SaveChanges();
            }
        }

        private int GetMaxClientCode(string TableChoose)
        {
            if (TableChoose == "Покупатель")
            {
                var max = new Client_Table();
                foreach (var entry in db.Client_Table)
                {
                    if (entry.Client_Code > max.Client_Code)
                    {
                        max = entry;
                    }
                }
                return (int)max.Client_Code;
            }
            else
            {
                var max = new Salesman_Table();
                foreach (var entry in db.Salesman_Table)
                {
                    if (entry.Salesman_Code > max.Salesman_Code)
                    {
                        max = entry;
                    }
                }
                return (int)max.Salesman_Code;
            }
        }
    }
}
