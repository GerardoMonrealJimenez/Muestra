//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AssistanceOnlineDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class AssistanceCourses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AssistanceCourses()
        {
            this.AssistanceUsers = new HashSet<AssistanceUsers>();
        }
    
        public int Id_course { get; set; }
        public System.DateTime Assistance_date { get; set; }
        public System.DateTime Creation_date { get; set; }
        public int Assistans { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssistanceUsers> AssistanceUsers { get; set; }
        public virtual Courses Courses { get; set; }
    }
}
