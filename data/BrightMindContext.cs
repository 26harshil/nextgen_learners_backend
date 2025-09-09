// using Microsoft.EntityFrameworkCore;
// using BrightMindQuizApi.Models;

// //harshil
// namespace BrightMindQuizApi.Data;

// public class BrightMindContext : DbContext
// {
//     public BrightMindContext(DbContextOptions<BrightMindContext> options) : base(options)
//     {
//     }

//     public DbSet<Category> Categories { get; set; }
//     public DbSet<Quiz> Quizzes { get; set; }
//     public DbSet<Question> Questions { get; set; }
//     public DbSet<OptionPool> OptionPools { get; set; }
//     public DbSet<QuestionOption> QuestionOptions { get; set; }


//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         // Map to exact table names
//         modelBuilder.Entity<Category>().ToTable("category");
//         modelBuilder.Entity<Quiz>().ToTable("quiz");
//         modelBuilder.Entity<Question>().ToTable("question");
//         modelBuilder.Entity<OptionPool>().ToTable("optionpool");
//         modelBuilder.Entity<QuestionOption>().ToTable("question_option");
    

//         // Map column names for Category
//         modelBuilder.Entity<Category>()
//             .Property(c => c.CategoryId).HasColumnName("category_id");
//         modelBuilder.Entity<Category>()
//             .Property(c => c.Name).HasColumnName("name");
//         modelBuilder.Entity<Category>()
//             .Property(c => c.Description).HasColumnName("description");
//         modelBuilder.Entity<Category>()
//             .Property(c => c.CreatedAt).HasColumnName("created_at")
//             .HasDefaultValueSql("GETDATE()");
//         modelBuilder.Entity<Category>()
//             .Property(c => c.UpdatedAt).HasColumnName("updated_at")
//             .HasDefaultValueSql("GETDATE()");

//         // Map column names for Quiz
//         modelBuilder.Entity<Quiz>()
//             .Property(q => q.QuizId).HasColumnName("quiz_id");
//         modelBuilder.Entity<Quiz>()
//             .Property(q => q.QuizTitle).HasColumnName("quiz_title");
//         modelBuilder.Entity<Quiz>()
//             .Property(q => q.CategoryId).HasColumnName("category_id");
//         modelBuilder.Entity<Quiz>()
//             .Property(q => q.CreatedAt).HasColumnName("created_at")
//             .HasDefaultValueSql("GETDATE()");
//         modelBuilder.Entity<Quiz>()
//             .Property(q => q.UpdatedAt).HasColumnName("updated_at")
//             .HasDefaultValueSql("GETDATE()");

//         // Map column names for Question
//         modelBuilder.Entity<Question>()
//             .Property(q => q.QuestionId).HasColumnName("question_id");
//         modelBuilder.Entity<Question>()
//             .Property(q => q.QuizId).HasColumnName("quiz_id");
//         modelBuilder.Entity<Question>()
//             .Property(q => q.QuestionText).HasColumnName("question_text");
//         modelBuilder.Entity<Question>()
//             .Property(q => q.ImageUrl).HasColumnName("image_url");
//         modelBuilder.Entity<Question>()
//             .Property(q => q.SoundData).HasColumnName("sound_data")
//         modelBuilder.Entity<Question>()
//             .Property(q => q.Hint).HasColumnName("hint");
//         modelBuilder.Entity<Question>()
//             .Property(q => q.FunFact).HasColumnName("fun_fact");
//         modelBuilder.Entity<Question>()
//             .Property(q => q.CreatedAt).HasColumnName("created_at")
//             .HasDefaultValueSql("GETDATE()");
//         modelBuilder.Entity<Question>()
//             .Property(q => q.UpdatedAt).HasColumnName("updated_at")
//             .HasDefaultValueSql("GETDATE()");

//         // Map column names for OptionPool
//         modelBuilder.Entity<OptionPool>()
//             .Property(o => o.OptionId).HasColumnName("option_id");
//         modelBuilder.Entity<OptionPool>()
//             .Property(o => o.OptionText).HasColumnName("option_text");
//         modelBuilder.Entity<OptionPool>()
//             .Property(o => o.CreatedAt).HasColumnName("created_at")
//             .HasDefaultValueSql("GETDATE()");
//         modelBuilder.Entity<OptionPool>()
//             .Property(o => o.UpdatedAt).HasColumnName("updated_at")
//             .HasDefaultValueSql("GETDATE()");

//         // Map column names for QuestionOption
//         modelBuilder.Entity<QuestionOption>()
//             .Property(qo => qo.QuestionOptionId).HasColumnName("question_option_id");
//         modelBuilder.Entity<QuestionOption>()
//             .Property(qo => qo.QuestionId).HasColumnName("question_id");
//         modelBuilder.Entity<QuestionOption>()
//             .Property(qo => qo.OptionId).HasColumnName("option_id");
//         modelBuilder.Entity<QuestionOption>()
//             .Property(qo => qo.IsCorrect).HasColumnName("is_correct");
//         modelBuilder.Entity<QuestionOption>()
//             .Property(qo => qo.CreatedAt).HasColumnName("created_at")
//             .HasDefaultValueSql("GETDATE()");
//         modelBuilder.Entity<QuestionOption>()
//             .Property(qo => qo.UpdatedAt).HasColumnName("updated_at")
//             .HasDefaultValueSql("GETDATE()");

     

//         // Configure relationships and constraints
//         modelBuilder.Entity<QuestionOption>()
//             .HasKey(qo => qo.QuestionOptionId);
//         modelBuilder.Entity<QuestionOption>()
//             .HasOne(qo => qo.Question)
//             .WithMany(q => q.QuestionOptions)
//             .HasForeignKey(qo => qo.QuestionId)
//             .OnDelete(DeleteBehavior.Cascade);
//         modelBuilder.Entity<QuestionOption>()
//             .HasOne(qo => qo.Option)
//             .WithMany(o => o.QuestionOptions)
//             .HasForeignKey(qo => qo.OptionId)
//             .OnDelete(DeleteBehavior.Cascade);
//         modelBuilder.Entity<QuestionOption>()
//             .HasIndex(qo => new { qo.QuestionId, qo.OptionId })
//             .IsUnique();
//     }
// }
using Microsoft.EntityFrameworkCore;
using BrightMindQuizApi.Models;

namespace BrightMindQuizApi.Data
{
    public class BrightMindContext : DbContext
    {
        public BrightMindContext(DbContextOptions<BrightMindContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<OptionPool> OptionPools { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map to exact table names
            modelBuilder.Entity<Category>().ToTable("category");
            modelBuilder.Entity<Quiz>().ToTable("quiz");
            modelBuilder.Entity<Question>().ToTable("question");
            modelBuilder.Entity<OptionPool>().ToTable("optionpool");
            modelBuilder.Entity<QuestionOption>().ToTable("question_option");

            // Map column names for Category
            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryId).HasColumnName("category_id");
            modelBuilder.Entity<Category>()
                .Property(c => c.Name).HasColumnName("name");
            modelBuilder.Entity<Category>()
                .Property(c => c.Description).HasColumnName("description");
            modelBuilder.Entity<Category>()
                .Property(c => c.CreatedAt).HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Category>()
                .Property(c => c.UpdatedAt).HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Map column names for Quiz
            modelBuilder.Entity<Quiz>()
                .Property(q => q.QuizId).HasColumnName("quiz_id");
            modelBuilder.Entity<Quiz>()
                .Property(q => q.QuizTitle).HasColumnName("quiz_title");
            modelBuilder.Entity<Quiz>()
                .Property(q => q.CategoryId).HasColumnName("category_id");
            modelBuilder.Entity<Quiz>()
                .Property(q => q.CreatedAt).HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Quiz>()
                .Property(q => q.UpdatedAt).HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Map column names for Question
            modelBuilder.Entity<Question>()
                .Property(q => q.QuestionId).HasColumnName("question_id");
            modelBuilder.Entity<Question>()
                .Property(q => q.QuizId).HasColumnName("quiz_id");
            modelBuilder.Entity<Question>()
                .Property(q => q.QuestionText).HasColumnName("question_text");
            modelBuilder.Entity<Question>()
                .Property(q => q.ImageUrl).HasColumnName("image_url");
            modelBuilder.Entity<Question>()
                .Property(q => q.SoundUrl).HasColumnName("sound_data");
            modelBuilder.Entity<Question>()
                .Property(q => q.Hint).HasColumnName("hint");
            modelBuilder.Entity<Question>()
                .Property(q => q.FunFact).HasColumnName("fun_fact");
            modelBuilder.Entity<Question>()
                .Property(q => q.CreatedAt).HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Question>()
                .Property(q => q.UpdatedAt).HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Map column names for OptionPool
            modelBuilder.Entity<OptionPool>()
                .Property(o => o.OptionId).HasColumnName("option_id");
            modelBuilder.Entity<OptionPool>()
                .Property(o => o.OptionText).HasColumnName("option_text");
            modelBuilder.Entity<OptionPool>()
                .Property(o => o.CreatedAt).HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<OptionPool>()
                .Property(o => o.UpdatedAt).HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Map column names for QuestionOption
            modelBuilder.Entity<QuestionOption>()
                .Property(qo => qo.QuestionOptionId).HasColumnName("question_option_id");
            modelBuilder.Entity<QuestionOption>()
                .Property(qo => qo.QuestionId).HasColumnName("question_id");
            modelBuilder.Entity<QuestionOption>()
                .Property(qo => qo.OptionId).HasColumnName("option_id");
            modelBuilder.Entity<QuestionOption>()
                .Property(qo => qo.IsCorrect).HasColumnName("is_correct");
            modelBuilder.Entity<QuestionOption>()
                .Property(qo => qo.CreatedAt).HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<QuestionOption>()
                .Property(qo => qo.UpdatedAt).HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Configure relationships and constraints
            modelBuilder.Entity<QuestionOption>()
                .HasKey(qo => qo.QuestionOptionId);
            modelBuilder.Entity<QuestionOption>()
                .HasOne(qo => qo.Question)
                .WithMany(q => q.QuestionOptions)
                .HasForeignKey(qo => qo.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<QuestionOption>()
                .HasOne(qo => qo.Option)
                .WithMany(o => o.QuestionOptions)
                .HasForeignKey(qo => qo.OptionId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<QuestionOption>()
                .HasIndex(qo => new { qo.QuestionId, qo.OptionId })
                .IsUnique();
        }
    }
}