using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Level_up.Models
{
    public partial class database : DbContext
    {
        public database()
            : base("name=database")
        {
        }

        public virtual DbSet<cat_E_u> cat_E_u { get; set; }
        public virtual DbSet<Cat_Level_Quction> Cat_Level_Quction { get; set; }
        public virtual DbSet<Cat_Level_User> Cat_Level_User { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Exam_choice> Exam_choice { get; set; }
        public virtual DbSet<has_R> has_R { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Q_choice> Q_choice { get; set; }
        public virtual DbSet<Quction> Quctions { get; set; }
        public virtual DbSet<R_book> R_book { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<user_degree> user_degree { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.cat_E_u)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Cat_Level_Quction)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Cat_Level_User)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.has_R)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.user_degree)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Levels)
                .WithMany(e => e.Categories)
                .Map(m => m.ToTable("cat_level").MapLeftKey("ID").MapRightKey("L_ID"));

            modelBuilder.Entity<Degree>()
                .HasMany(e => e.user_degree)
                .WithRequired(e => e.Degree)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Exam>()
                .HasMany(e => e.Exam_choice)
                .WithRequired(e => e.Exam)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Level>()
                .HasMany(e => e.Cat_Level_Quction)
                .WithRequired(e => e.Level)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Level>()
                .HasMany(e => e.Cat_Level_User)
                .WithRequired(e => e.Level)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Level>()
                .HasMany(e => e.has_R)
                .WithRequired(e => e.Level)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Level>()
                .HasMany(e => e.user_degree)
                .WithRequired(e => e.Level)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quction>()
                .HasMany(e => e.Cat_Level_Quction)
                .WithRequired(e => e.Quction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quction>()
                .HasMany(e => e.Q_choice)
                .WithRequired(e => e.Quction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Resource>()
                .HasMany(e => e.has_R)
                .WithRequired(e => e.Resource)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Resource>()
                .HasMany(e => e.R_book)
                .WithRequired(e => e.Resource)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.cat_E_u)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Cat_Level_User)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.user_degree)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
