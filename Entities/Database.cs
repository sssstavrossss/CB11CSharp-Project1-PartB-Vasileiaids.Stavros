namespace CB11_ProjectA_PartB.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;

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
                    foreach (var item in coursesList)
                        Console.WriteLine($"{item.CID}, Title: {item.title}, Type: {item.type}, Stream: {item.stream}, " +
                            $"Start Date: {item.startDate}, End Date: {item.endDate}");
                else
                    Console.WriteLine("There are no courses yet!");
            else
                Console.WriteLine("There are no courses yet!");
            Console.WriteLine();
        }
    }
}
