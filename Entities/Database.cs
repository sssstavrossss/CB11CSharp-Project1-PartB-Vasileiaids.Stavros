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
            List<Students> studentsList = Students.ToList();
            if (studentsList.Any())
                studentsList.ForEach(x => Console.WriteLine($"{x.SID}, First Name: {x.firstName}, Last Name: {x.lastName}, Birth Date: " +
                        $"{x.dateOfBirth}, Tuition Fees: {x.tuitionFees}"));
            else
                Console.WriteLine("There are no students yet!");
            Console.WriteLine();
        }

        public void ShowTrainers()
        {
            List<Trainers> trainersList = Trainers.ToList();
            if (trainersList.Any())
                trainersList.ForEach(x => Console.WriteLine($"{x.TID}, First Name: {x.firstName}, " +
                    $"Last Name: {x.lastName}, Subject: {x.subject}"));
            else
                Console.WriteLine("There are no trainers yet!");
            Console.WriteLine();
        }

        public void ShowAssignments()
        {
            List<Assignments> assignmentsList = Assignments.ToList();
            if (assignmentsList.Any())
                assignmentsList.ForEach(x => Console.WriteLine($"{x.AID}, First Name: {x.title}, " +
                    $"Last Name: {x.description}, Subject: {x.subDateTime}"));
            else
                Console.WriteLine("There are no assignments yet!");
            Console.WriteLine();
        }

        public void ShowStudentsPerCourse()
        {
            List<Courses> coursesList = Courses.ToList();
            if (coursesList.Any())
                foreach (Courses item in coursesList)
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
            List<Courses> coursesList = Courses.ToList();
            if (coursesList.Any())
                foreach (Courses item in coursesList)
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
            List<Courses> coursesList = Courses.ToList();
            if (coursesList.Any())
                foreach (Courses item in coursesList)
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
            List<Students> studentsList = Students.ToList();
            if (studentsList.Any())
                foreach (Students item in studentsList)
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
            List<Courses> coursessList = Courses.ToList();
            if (coursessList.Any())
                foreach (Courses item in coursessList)
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
            //foreach (Courses item in Courses)
            //List<Courses> coursessList = Courses.ToList();
            //if (coursessList.Any())
            //    foreach (Courses item in coursessList)
            //        if (item.Students.Any())
            //            foreach (Students st in item.Students)
            //                if (st.Assignments.Any())
            //                    foreach (Assignments asn in st.Assignments)
            //                        Console.WriteLine($"Course: {item.title} Student: {st.firstName} {st.lastName}, Assignment Name: {asn.title}");
            //                else
            //                    Console.WriteLine($"There are no Assignments yet for the student {st.firstName} {st.lastName}");
            //        else
            //            Console.WriteLine($"There are no Students yet for course {item.title}!");
            //else
            //    Console.WriteLine("There are no courses yet!");
            //Console.WriteLine();
        }
    }
}
