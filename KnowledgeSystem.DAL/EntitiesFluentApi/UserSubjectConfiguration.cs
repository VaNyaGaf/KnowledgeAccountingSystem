using KnowledgeSystem.DAL.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeSystem.DAL.EntitiesFluentApi
{
    class UserSubjectConfiguration : IEntityTypeConfiguration<UserSubject>
    {
        public void Configure(EntityTypeBuilder<UserSubject> builder)
        {
            builder.HasKey(us => new { us.UserId, us.SubjectId });

            builder.HasOne(us => us.User)
                .WithMany(u => u.UserSubjects)
                .HasForeignKey(us => us.UserId);

            builder.HasOne(us => us.Subject)
                .WithMany(s => s.UserSubjects)
                .HasForeignKey(us => us.SubjectId);
        }
    }
}
