using KnowledgeSystem.BLL.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace KnowledgeSystem.BLL
{
    public static class BllDependencies
    {
        public static void RegisterBllDependencies(this IServiceCollection service)
        {
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<ISubjectService, SubjectService>();
        }
    }
}
