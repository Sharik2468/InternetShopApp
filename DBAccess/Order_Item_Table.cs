//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_Item_Table
    {
        public int Order_Item_Code { get; set; }
        public Nullable<int> Order_Sum { get; set; }
        public Nullable<int> Amount_Order_Item { get; set; }
        public Nullable<int> Product_Code { get; set; }
        public Nullable<int> Order_Code { get; set; }
        public int Status_Order_Item_Table_ID { get; set; }
    
        public virtual Order_Table Order_Table { get; set; }
        public virtual Product_Table Product_Table { get; set; }
        public virtual Status_Order_Item_Table Status_Order_Item_Table { get; set; }
    }
}
