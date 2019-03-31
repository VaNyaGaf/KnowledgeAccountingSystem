using KnowledgeSystem.DAL.Abstractions;
using KnowledgeSystem.DAL.Abstractions.Entities;
using KnowledgeSystem.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KnowledgeSystem.DAL
{
    public static class DalDependencies
    {
        public static void RegisterDalDependencies(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<KnowledgeContext>(options => options.UseSqlServer(connectionString));
            service.AddDefaultIdentity<User>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
            })
                .AddEntityFrameworkStores<KnowledgeContext>();
            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<ISubjectRepository, SubjectRepository>();
            service.AddTransient<IUnitOfWork, KnowledgeUnitOfWork>();
        }
    }
}
