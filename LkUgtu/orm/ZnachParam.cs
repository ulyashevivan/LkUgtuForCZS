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
    
    public partial class ZnachParam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ZnachParam()
        {
            this.Param_Vakans = new HashSet<Param_Vakans>();
        }
    
        public int idZnachParam { get; set; }
        public string ZnachParamName { get; set; }
        public int idParam { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Param_Vakans> Param_Vakans { get; set; }
        public virtual Parametr Parametr { get; set; }
    }
}