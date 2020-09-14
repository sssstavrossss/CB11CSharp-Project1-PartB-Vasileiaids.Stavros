namespace CB11_ProjectA_PartB.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Students
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Students()
        {
            Assignments = new HashSet<Assignments>();
            Courses = new HashSet<Courses>();
        }

        [Key]
        public int SID { get; set; }

        [StringLength(50)]
        public string firstName { get; set; }

        [StringLength(50)]
        public string lastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateOfBirth { get; set; }

        public int? tuitionFees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignments> Assignments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Courses> Courses { get; set; }

        public void GetFirstName()
        {
            firstName = Helper.GetString("Student first name:");
        }

        public void GetLastName()
        {
            lastName = Helper.GetString("Student last name:");
        }

        private void GetTuitionFees()
        {
            tuitionFees = Helper.GetNumber("Student tuition fees:");
        }
        private void GetDateOfBirth()
        {
            dateOfBirth = Helper.GetDate("Student date of birth: ");
        }

        public void CreateStudent()
        {
            GetFirstName();
            GetLastName();
            GetTuitionFees();
            GetDateOfBirth();
            Console.WriteLine();
        }
    }
}
