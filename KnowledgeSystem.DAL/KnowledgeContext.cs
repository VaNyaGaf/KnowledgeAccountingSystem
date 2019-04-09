﻿using KnowledgeSystem.DAL.Abstractions.Entities;
using KnowledgeSystem.DAL.EntitiesFluentApi;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeSystem.DAL
{
    class KnowledgeContext : DbContext
    {
        public DbSet<User> AppUsers{ get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<UserSubject> UserSubjects { get; set; }

        public KnowledgeContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
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
