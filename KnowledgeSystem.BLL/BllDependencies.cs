using AutoMapper;
using KnowledgeSystem.BLL.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace KnowledgeSystem.BLL
{
    public static class BllDependencies
    {
        public static void RegisterBllDependencies(this IServiceCollection service)
        {
            service.AddAutoMapper();
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<ISubjectService, SubjectService>();
        }
    }
}
