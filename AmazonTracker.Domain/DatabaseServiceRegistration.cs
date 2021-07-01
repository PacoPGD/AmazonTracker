using AmazonTracker.Domain.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AmazonTracker.Domain
{
    public static class DatabaseServiceRegistration
    {
        public static void AddInfrastructure(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IReviewResultRepository, ReviewResultRepository>();
        }
    }
}
