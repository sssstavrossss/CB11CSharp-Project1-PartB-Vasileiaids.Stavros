namespace CB11_ProjectA_PartB.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Reflection;

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
            List<Courses> coursesList;
            coursesList = Courses.ToList();
            if (coursesList != null)
                if (coursesList.Count > 0)
                    coursesList.ForEach(x => Console.WriteLine($"{x.CID}, Title: {x.title}, Type: {x.type}, Stream: {x.stream}, " +
                           $"Start Date: {x.startDate}, End Date: {x.endDate}"));
                else
                    Console.WriteLine("There are no courses yet!");
            else
                Console.WriteLine("There are no courses yet!");
            Console.WriteLine();
        }

        public void ShowStudents()
        {
            List<Students> studentsList;
            studentsList = Students.ToList();
            if (studentsList != null)
                if (studentsList.Count > 0)
                    studentsList.ForEach(x => Console.WriteLine($"{x.SID}, First Name: {x.firstName}, Last Name: {x.lastName}, Birth Date: " +
                           $"{x.dateOfBirth}, Tuition Fees: {x.tuitionFees}"));
                else
                    Console.WriteLine("There are no students yet!");
            else
                Console.WriteLine("There are no students yet!");
            Console.WriteLine();
        }

        public void ShowTrainers()
        {
            List<Trainers> trainersList;
            trainersList = Trainers.ToList();
            if (trainersList != null)
                if (trainersList.Count > 0)
                    trainersList.ForEach(x => Console.WriteLine($"{x.TID}, First Name: {x.firstName}, " +
                        $"Last Name: {x.lastName}, Subject: {x.subject}"));
                else
                    Console.WriteLine("There are no trainers yet!");
            else
                Console.WriteLine("There are no trainers yet!");
            Console.WriteLine();
        }

        public void ShowAssignments()
        {
            List<Assignments> assignmentsList;
            assignmentsList = Assignments.ToList();
            if (assignmentsList != null)
                if (assignmentsList.Count > 0)
                    assignmentsList.ForEach(x => Console.WriteLine($"{x.TID}, First Name: {x.firstName}, " +
                        $"Last Name: {x.lastName}, Subject: {x.subject}"));
                else
                    Console.WriteLine("There are no assignments yet!");
            else
                Console.WriteLine("There are no assignments yet!");
            Console.WriteLine();
        }
    }
}
