using KnowledgeSystem.DAL.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeSystem.DAL.EntitiesFluentApi
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.FirstName).IsRequired().HasMaxLength(15);
            builder.Property(user => user.LastName).IsRequired().HasMaxLength(15);
            builder.Property(user => user.Password).IsRequired().HasMaxLength(20);
        }
    }
}
