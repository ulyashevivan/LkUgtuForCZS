//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LkUgtu.orm
{
    using System;
    using System.Collections.Generic;
    
    public partial class Resume
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Resume()
        {
            this.Trudoustr = new HashSet<Trudoustr>();
        }
    
        public int idResume { get; set; }
        public int idStatus { get; set; }
        public Nullable<int> idVakans { get; set; }
        public decimal idStud { get; set; }
        public string DopInfo { get; set; }
        public string Otmetki { get; set; }
        public Nullable<bool> UstroenCZS { get; set; }
        public System.DateTime DataPrinytiya { get; set; }
        public Nullable<System.DateTime> DataZakritiya { get; set; }
        public Nullable<int> idFile { get; set; }
    
        public virtual Vakans Vakans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trudoustr> Trudoustr { get; set; }
    }
}