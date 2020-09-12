namespace CB11_ProjectA_PartB.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Assignments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Assignments()
        {
            Courses = new HashSet<Courses>();
            Students = new HashSet<Students>();
        }

        [Key]
        public int AID { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        [StringLength(500)]
        public string description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? subDateTime { get; set; }

        public int? oralMark { get; set; }

        public int? totalMark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Courses> Courses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Students> Students { get; set; }
    }
}
