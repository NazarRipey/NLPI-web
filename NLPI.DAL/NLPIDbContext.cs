using Microsoft.EntityFrameworkCore;
using NLPI.Core.Models;

namespace NLPI.DAL
{
    public class NLPIDbContext : DbContext
    {
        public NLPIDbContext()
        {
        }

        public NLPIDbContext(DbContextOptions<NLPIDbContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<TaskType> TaskTypes { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Hint> Hints { get; set; }
        public virtual DbSet<TestTask> Tasks { get; set; }
        public virtual DbSet<UserAnswer> UserAnswers { get; set; }
        public virtual DbSet<UserTaskResult> UserTaskResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source=nlpi.db");

            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKUser");

                entity.Property(e => e.Id)
                .HasColumnName("Id_User");

                entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);

                entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false);

                entity.HasData(
                    new User
                    {
                        Id = 1,
                        FirstName = "Admin",
                        LastName = "Admin",
                        Email = "admin@gmail.com",
                        Password = "12345",
                        Phone = "0123456789",
                        Role = "Admin"
                    },
                    new User
                    {
                        Id = 2,
                        FirstName = "Student",
                        LastName = "Student",
                        Email = "student@gmail.com",
                        Password = "12345",
                        Phone = "1234567890",
                        Role = "User"
                    },
                    new User
                    {
                        Id = 3,
                        FirstName = "Nazar",
                        LastName = "Ripey",
                        Email = "nripey@gmail.com",
                        Password = "12345",
                        Phone = "2345678901",
                        Role = "User"
                    });
            });

            modelBuilder.Entity<TaskType>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKTaskType");

                entity.Property(e => e.Id)
                .HasColumnName("Id_TaskType");

                entity.Property(e => e.Type)
                .HasMaxLength(30)
                .IsUnicode(false);

                entity.HasData(
                    new TaskType
                    {
                        Id = 1,
                        Type = "Testing type clasification"
                    },
                    new TaskType
                    {
                        Id = 2,
                        Type = "Test case creation"
                    });
            });

            modelBuilder.Entity<TestTask>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKTask");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Task");

                entity.HasOne(t => t.TaskType)
                    .WithMany(tt => tt.TestTasks)
                .HasForeignKey(t => t.TaskTypeId);

                entity.HasMany(t => t.Answers)
                    .WithOne(a => a.Task)
                .HasForeignKey(a => a.TaskId);

                entity.HasMany(t => t.Answers)
                    .WithOne(a => a.Task)
                .HasForeignKey(a => a.TaskId);

                entity.HasData(
                    new TestTask
                    {
                        Id = 1,
                        Name = "Crossplatform test classification",
                        Description = "Owner wants to make his web-app compatible with other actual browsers and OS.",
                        TaskTypeId = 1
                    },
                    new TestTask
                    {
                        Id = 2,
                        Name = "Password recovery test case",
                        Description = "Check if link with password recovery in auto email is working correctly.",
                        TaskTypeId = 2
                    });
            });


            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKAnswer");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Answer");

                entity.Property(e => e.TextAnswer)
                .IsUnicode(false);

                entity.HasData(
                    new Answer
                    {
                        Id = 1,
                        TaskId = 1,
                        IsCorrect = true,
                        CorrectPosition = 4,
                        TextAnswer = "Compatibility Testing"
                    },
                    new Answer
                    {
                        Id = 2,
                        TaskId = 1,
                        IsCorrect = false,
                        TextAnswer = "Volume testing"
                    },
                    new Answer
                    {
                        Id = 3,
                        TaskId = 1,
                        IsCorrect = true,
                        CorrectPosition = 2,
                        TextAnswer = "Defect Validation"
                    },
                    new Answer
                    {
                        Id = 4,
                        TaskId = 1,
                        IsCorrect = false,
                        TextAnswer = "Installability testing"
                    },
                    new Answer
                    {
                        Id = 5,
                        TaskId = 1,
                        IsCorrect = false,
                        TextAnswer = "GUI testing"
                    },
                    new Answer
                    {
                        Id = 6,
                        TaskId = 1,
                        IsCorrect = true,
                        CorrectPosition = 1,
                        TextAnswer = "Smoke testing"
                    },
                    new Answer
                    {
                        Id = 7,
                        TaskId = 1,
                        IsCorrect = false,
                        TextAnswer = "Accessibility testing"
                    },
                    new Answer
                    {
                        Id = 8,
                        TaskId = 1,
                        IsCorrect = false,
                        TextAnswer = "New feature testing"
                    },
                    new Answer
                    {
                        Id = 9,
                        TaskId = 1,
                        IsCorrect = true,
                        CorrectPosition = 3,
                        TextAnswer = "Regression Testing"
                    },
                    new Answer
                    {
                        Id = 10,
                        TaskId = 1,
                        IsCorrect = false,
                        TextAnswer = "Safety testing"
                    },

                   new Answer
                   {
                       Id = 11,
                       TaskId = 2,
                       IsCorrect = false,
                       TextAnswer = "Type in field incorrect email"
                   },
                    new Answer
                    {
                        Id = 12,
                        TaskId = 2,
                        IsCorrect = true,
                        CorrectPosition = 5,
                        TextAnswer = "Validate that link is working correctly"
                    },
                    new Answer
                    {
                        Id = 13,
                        TaskId = 2,
                        IsCorrect = true,
                        CorrectPosition = 3,
                        TextAnswer = "Type in field valid account’s email"
                    },
                    new Answer
                    {
                        Id = 14,
                        TaskId = 2,
                        IsCorrect = true,
                        CorrectPosition = 4,
                        TextAnswer = "Check that email for a new letter with link"
                    }, new Answer
                    {
                        Id = 15,
                        TaskId = 2,
                        IsCorrect = false,
                        TextAnswer = "Return on main page"
                    }, new Answer
                    {
                        Id = 16,
                        TaskId = 2,
                        IsCorrect = true,
                        CorrectPosition = 2,
                        TextAnswer = "Click on link «Forgot your password ?»"
                    }, new Answer
                    {
                        Id = 17,
                        TaskId = 2,
                        IsCorrect = true,
                        CorrectPosition = 1,
                        TextAnswer = "Open Log In page(Log out if necessary)"
                    }, new Answer
                    {
                        Id = 18,
                        TaskId = 2,
                        IsCorrect = false,
                        TextAnswer = "Log In system / or check that you are in"
                    });
            });

            modelBuilder.Entity<Hint>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKHint");

                entity.Property(e => e.Id)
                       .HasColumnName("Id_Hint");

                entity.Property(e => e.HintType)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                entity.Property(e => e.HintText)
                       .HasMaxLength(200)
                       .IsUnicode(false);

                entity.HasData(
                    new Hint
                    {
                        Id = 1,
                        IdTask = 1,
                        HintType = "CSS",
                        HintText = "CSS"
                    });
            });
        }
    }
}
