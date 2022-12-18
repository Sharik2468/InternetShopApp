using System;
using System.Collections.Generic;
using System.Text;

namespace PL.Model
{
    class StatusOrderModel
    {
        public StatusOrderModel()
        {

        }

        public StatusOrderModel(DBAccess.Status_Table c)
        {
            Delivery_Code = c.Delivery_Code;
            Order_Status = c.Order_Status;
        }
        public int Delivery_Code { get; set; }
        public string Order_Status { get; set; }
    }
}
