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
    
    public partial class Courses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Courses()
        {
            this.AssistanceCourses = new HashSet<AssistanceCourses>();
            this.UsersCourses = new HashSet<UsersCourses>();
        }
    
        public int Id_course { get; set; }
        public string Id_user { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime Creation_date { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssistanceCourses> AssistanceCourses { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersCourses> UsersCourses { get; set; }
    }
}
