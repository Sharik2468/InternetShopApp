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
    
    public partial class Client_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client_Table()
        {
            this.Order_Table = new HashSet<Order_Table>();
        }
    
        public int Client_Code { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Nullable<long> Telephone_Number { get; set; }
        public string Password { get; set; }
        public Nullable<int> Location_Code { get; set; }
    
        public virtual Location_Table Location_Table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Table> Order_Table { get; set; }
    }
}
