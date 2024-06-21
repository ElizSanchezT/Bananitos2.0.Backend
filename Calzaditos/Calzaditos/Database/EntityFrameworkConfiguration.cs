using Microsoft.EntityFrameworkCore;

namespace Calzaditos.Database
{
    public static class EntityFrameworkConfiguration
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddDbContextPool<CalzaditosDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("CalzaditosDB")
                    ?? throw new ArgumentException("ConnectionString not configured");

                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    if (!environment.IsDevelopment())
                    {
                        sqlOptions.EnableRetryOnFailure();
                    }
                    sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
                });

                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            return services;
        }
    }
}
