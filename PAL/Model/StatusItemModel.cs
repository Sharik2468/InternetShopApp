using System;
using System.Collections.Generic;
using System.Text;

namespace PL.Model
{
    class StatusItemModel
    {
        public StatusItemModel()
        {

        }

        public StatusItemModel(DBAccess.Status_Order_Item_Table c)
        {
            Status_Order_Item_ID = c.Status_Order_Item_ID;
            Status_Order_Item_Table1 = c.Status_Order_Item_Table1;
        }
        public int Status_Order_Item_ID { get; set; }
        public string Status_Order_Item_Table1 { get; set; }
    }
}
