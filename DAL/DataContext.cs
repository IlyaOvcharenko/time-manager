using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Data;

namespace DAL
{
    public class  DataContext : DbContext
    {
        public DataContext() : base("DbConnection")
        {
            Database.SetInitializer<DataContext>(new DbInitializer());
        }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<MeasureUnit> MeasureUnits { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().Property(t => t.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Task>().Property(t => t.Priority).IsRequired();

            modelBuilder.Entity<Task>().HasMany(t => t.ChildTasks);

            modelBuilder.Entity<Activity>().Property(t => t.Date).IsRequired();
            modelBuilder.Entity<Activity>().Property(t => t.SpentTime).IsRequired();

            modelBuilder.Entity<MeasureUnit>().Property(t => t.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<MeasureUnit>().Property(t => t.ShortName).IsRequired().HasMaxLength(5);

            modelBuilder.Entity<User>().Property(t => t.Login).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(t => t.Email).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(t => t.Password).IsRequired().HasMaxLength(50);



            base.OnModelCreating(modelBuilder);
        }


    }
}
