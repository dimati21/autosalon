//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace autosalon.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        public int CarID { get; set; }
        public int CreatoreID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Image_var { get; set; }
    
        public virtual Creatore Creatore { get; set; }
    }
}
