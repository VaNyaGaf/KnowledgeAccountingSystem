using KnowledgeSystem.DAL.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeSystem.DAL.EntitiesFluentApi
{
    class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.Property(student => student.Name).IsRequired().HasMaxLength(50);
            builder.Property(student => student.Description).HasMaxLength(120);
        }
    }
}
