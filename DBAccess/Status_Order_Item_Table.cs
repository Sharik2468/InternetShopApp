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
    
    public partial class Status_Order_Item_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Status_Order_Item_Table()
        {
            this.Order_Item_Table = new HashSet<Order_Item_Table>();
        }
    
        public int Status_Order_Item_ID { get; set; }
        public string Status_Order_Item_Table1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Item_Table> Order_Item_Table { get; set; }
    }
}
