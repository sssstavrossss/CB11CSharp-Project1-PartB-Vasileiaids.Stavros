namespace CB11_ProjectA_PartB.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Courses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Courses()
        {
            Assignments = new HashSet<Assignments>();
            Students = new HashSet<Students>();
            Trainers = new HashSet<Trainers>();
        }

        [Key]
        public int CID { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        [StringLength(50)]
        public string stream { get; set; }

        [StringLength(50)]
        public string type { get; set; }

        [Column(TypeName = "date")]
        public DateTime? startDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? endDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignments> Assignments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Students> Students { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainers> Trainers { get; set; }

        public void GetTitle()
        {
            title = Helper.GetString("Course title:");
        }

        public void GetTypec()
        {
            type = Helper.GetString("Course type:");
        }

        private void GetStream()
        {
            stream = Helper.GetString("Course strem:");
        }

        private void GetStartDate()
        {
            startDate = Helper.GetDate("Course start date: ");
        }

        private void GetEndDate()
        {
            endDate = Helper.GetDate("Course end date: ");
        }

        public void CreateCourse()
        {
            GetTitle();
            GetTypec();
            GetStream();
            GetStartDate();
            GetEndDate();
            Console.WriteLine();
        }
    }
}
