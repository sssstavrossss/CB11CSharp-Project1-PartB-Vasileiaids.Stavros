namespace CB11_ProjectA_PartB.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Reflection;
    using System.Data;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;

    public partial class Database : DbContext
    {
        public Database()
            : base("name=Database")
        {
        }

        public virtual DbSet<Assignments> Assignments { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Trainers> Trainers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignments>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Assignments>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Assignments>()
                .HasMany(e => e.Courses)
                .WithMany(e => e.Assignments)
                .Map(m => m.ToTable("AssignmentsPerCourse").MapLeftKey("AID").MapRightKey("CID"));

            modelBuilder.Entity<Assignments>()
                .HasMany(e => e.Students)
                .WithMany(e => e.Assignments)
                .Map(m => m.ToTable("AssignmentsPerStudent").MapLeftKey("AID").MapRightKey("SID"));

            modelBuilder.Entity<Courses>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Courses>()
                .Property(e => e.stream)
                .IsUnicode(false);

            modelBuilder.Entity<Courses>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<Courses>()
                .HasMany(e => e.Students)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("StudentsPerCourse").MapLeftKey("CID").MapRightKey("SID"));

            modelBuilder.Entity<Courses>()
                .HasMany(e => e.Trainers)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("TrainersPerCourse").MapLeftKey("CID").MapRightKey("TID"));

            modelBuilder.Entity<Students>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<Trainers>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<Trainers>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<Trainers>()
                .Property(e => e.subject)
                .IsUnicode(false);
        }

        public void ShowCourses()
        {
            if (Courses.Any())
                Courses.ToList().ForEach(x => Console.WriteLine($"{x.CID}, Title: {x.title}, Type: {x.type}, Stream: {x.stream}, " +
                            $"Start Date: {x.startDate}, End Date: {x.endDate}"));
            else
                Console.WriteLine("There are no courses yet!");
            Console.WriteLine();
        }

        public void ShowStudents()
        {
            if (Students.Any())
                Students.ToList().ForEach(x => Console.WriteLine($"{x.SID}, First Name: {x.firstName}, Last Name: {x.lastName}, Birth Date: " +
                        $"{x.dateOfBirth}, Tuition Fees: {x.tuitionFees}"));
            else
                Console.WriteLine("There are no students yet!");
            Console.WriteLine();
        }

        public void ShowTrainers()
        {
            if (Trainers.Any())
                Trainers.ToList().ForEach(x => Console.WriteLine($"{x.TID}, First Name: {x.firstName}, " +
                    $"Last Name: {x.lastName}, Subject: {x.subject}"));
            else
                Console.WriteLine("There are no trainers yet!");
            Console.WriteLine();
        }

        public void ShowAssignments()
        {
            if (Assignments.Any())
                Assignments.ToList().ForEach(x => Console.WriteLine($"{x.AID}, First Name: {x.title}, " +
                    $"Last Name: {x.description}, Subject: {x.subDateTime}"));
            else
                Console.WriteLine("There are no assignments yet!");
            Console.WriteLine();
        }

        public void ShowStudentsPerCourse()
        {
            if (Courses.Any())
                foreach (Courses item in Courses.ToList())
                    if (item.Students.Any())
                        foreach (Students st in item.Students)
                            Console.WriteLine($" Course: {item.title}, Student Name: {st.firstName} {st.lastName}");
                    else
                        Console.WriteLine($"There are no Students yet in course {item.title}!");
            else
                Console.WriteLine("There are no courses yet!");
            Console.WriteLine();
        }

        public void ShowTrainersPerCourse()
        {
            if (Courses.Any())
                foreach (Courses item in Courses.ToList())
                    if (item.Trainers.Any())
                        foreach (Trainers st in item.Trainers)
                            Console.WriteLine($" Course: {item.title}, Trainer Name: {st.firstName} {st.lastName}");
                    else
                        Console.WriteLine($"There are no Trainers yet in course {item.title}!");
            else
                Console.WriteLine("There are no courses yet!");
            Console.WriteLine();
        }

        public void ShowAssignmentsPerCourse()
        {
            if (Courses.Any())
                foreach (Courses item in Courses.ToList())
                    if (item.Assignments.Any())
                        foreach (Assignments st in item.Assignments)
                            Console.WriteLine($" Course: {item.title}, Assignment Name: {st.title}");
                    else
                        Console.WriteLine($"There are no Assignments yet in course {item.title}!");
            else
                Console.WriteLine("There are no courses yet!");
            Console.WriteLine();
        }

        public void ShowAssignmentsPerStudent()
        {
            if (Students.Any())
                foreach (Students item in Students.ToList())
                    if (item.Assignments.Any())
                        foreach (Assignments st in item.Assignments)
                            Console.WriteLine($" Student: {item.firstName} {item.lastName}, Assignment Name: {st.title}");
                    else
                        Console.WriteLine($"There are no Assignments yet for student {item.firstName} {item.lastName}!");
            else
                Console.WriteLine("There are no students yet!");
            Console.WriteLine();
        }
        public void ShowAssignmentsPerCoursePerStudent()
        {
            if (Courses.Any())
                foreach (Courses item in Courses.ToList())
                    if (item.Students.Any())
                        foreach (Students st in item.Students)
                            if (st.Assignments.Any())
                                foreach (Assignments asn in st.Assignments)
                                    Console.WriteLine($"Course: {item.title} Student: {st.firstName} {st.lastName}, Assignment Name: {asn.title}");
                            else
                                Console.WriteLine($"There are no Assignments yet for the student {st.firstName} {st.lastName}");
                    else
                        Console.WriteLine($"There are no Students yet for course {item.title}!");
            else
                Console.WriteLine("There are no courses yet!");
            Console.WriteLine();
        }
        public void ShowStudentPerManyCourses()
        {
            if (Students.Any())
                foreach (var item in Students.ToList())
                    if (item.Courses.Any())
                    {
                        if (item.Courses.Count() >= 2)
                            Console.WriteLine($"Student name: {item.firstName} {item.lastName}");
                    }
                    else
                        Console.WriteLine($"There are no courses for student {item.firstName} {item.lastName} yet!");
            else
                Console.WriteLine("There are no students yet!");
            Console.WriteLine();
        }

        public void ShowStudentSubmit(DateTime date)
        {

            while (!date.DayOfWeek.ToString().Equals("Monday"))
                date = date.AddDays(-1);

            if (Students.Any())
            {
                foreach (var item in Students.ToList())
                    if (item.Assignments.Any())
                        foreach (var item2 in item.Assignments.ToList())
                            if (item2.subDateTime >= date && item2.subDateTime <= date.AddDays(5))
                                Console.WriteLine($"Student: {item.firstName} {item.lastName}");
            }
            else
                Console.WriteLine("Therea re no Students yet!");

        }

        public List<int> GetStudentsID()
        {
            List<int> list = Students.ToList().Select(st => st.SID ).ToList();
            return list;
        }

        public List<int> GetTrainersID()
        {
            List<int> list = Trainers.ToList().Select(st => st.TID).ToList();
            return list;
        }
        public List<int> GetAssignmentsID()
        {
            List<int> list = Assignments.ToList().Select(st => st.AID).ToList();
            return list;
        }
        public List<int> GetCoursesID()
        {
            List<int> list = Courses.ToList().Select(st => st.CID).ToList();
            return list;
        }
        //public bool ValidateStudentsAssign(int st , int cr)
        //{

        //}
    }
}
