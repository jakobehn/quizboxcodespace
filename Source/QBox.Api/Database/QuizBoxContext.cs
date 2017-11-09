using QBox.Api.Migrations;

namespace QBox.Api.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuizBoxContext : DbContext
    {
        public QuizBoxContext()
            : base("name=QuizBoxContext")
        {
            System.Data.Entity.Database.SetInitializer<QuizBoxContext>(new MigrateDatabaseToLatestVersion<QuizBoxContext, Configuration>());
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GameQuestion> GameQuestion { get; set; }
        public virtual DbSet<Highscore> Highscore { get; set; }
        public virtual DbSet<Question> Question { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Game)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Highscore)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Question)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Game>()
                .HasMany(e => e.GameQuestion)
                .WithRequired(e => e.Game)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Answer)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.GameQuestion)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);
        }
    }
}
