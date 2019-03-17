using KnowledgeSystem.DAL.Abstractions;
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
            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<ISubjectRepository, SubjectRepository>();
            service.AddTransient<IUnitOfWork, KnowledgeUnitOfWork>();
        }
    }
}
