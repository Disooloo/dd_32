//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace demosed_465734
{
    using System;
    using System.Collections.Generic;
    
    public partial class Organizatory
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public int IDCountry { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoPath { get; set; }
        public string Gender { get; set; }
    
        public virtual Country Country { get; set; }
    }
}