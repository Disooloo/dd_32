//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cifrovizaciya.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class gyri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public gyri()
        {
            this.Activity = new HashSet<Activity>();
        }
    
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<int> IDCountry { get; set; }
        public string Phone { get; set; }
        public Nullable<int> IDNapravleniay { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoPath { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity { get; set; }
        public virtual Country Country { get; set; }
        public virtual Napravlenie Napravlenie { get; set; }
    }
}
