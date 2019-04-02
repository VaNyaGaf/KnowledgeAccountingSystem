using KnowledgeSystem.BLL;
using KnowledgeSystem.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace DependenciesInjection
{
    public static class DependeciesInjection
    {
        public static void RegisterDependencies(this IServiceCollection service, string connectionString)
        {
            service.RegisterDalDependencies(connectionString);
            service.RegisterBllDependencies();
        }
    }
}
