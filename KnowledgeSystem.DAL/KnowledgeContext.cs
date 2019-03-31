using KnowledgeSystem.DAL.Abstractions.Entities;
using KnowledgeSystem.DAL.EntitiesFluentApi;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeSystem.DAL
{
    class KnowledgeContext : IdentityDbContext
    {
        public DbSet<User> ApplicationUsers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<UserSubject> UserSubjects { get; set; }

        public KnowledgeContext()
        {
            Database.EnsureCreated();
        }
        public KnowledgeContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Applying fluent api
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new UserSubjectConfiguration());
        }
    }
}
