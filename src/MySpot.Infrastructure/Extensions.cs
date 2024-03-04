﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MySpot.Application.Abstractions;
using MySpot.Core.Abstractions;
using MySpot.Infrastructure.Auth;
using MySpot.Infrastructure.DAL;
using MySpot.Infrastructure.Exceptions;
using MySpot.Infrastructure.Logging;
using MySpot.Infrastructure.Security;
using MySpot.Infrastructure.Time;

namespace MySpot.Infrastructure;
public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection("app");
        services.Configure<AppOptions>(section);
        services.AddSingleton<ExceptionMiddleware>();
        services.AddSecurity();
        services.AddAuth(configuration);
        services.AddHttpContextAccessor();
        
        services
            .AddPostgres(configuration)
            .AddSingleton<IClock, Clock>();
        
        var infrastructureAssembly = typeof(AppOptions).Assembly;
        services.Scan(s => s.FromAssemblies(infrastructureAssembly)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        
        services.AddCustomLogging();
        services.AddEndpointsApiExplorer(); //integruj dokumentację z podejściem minimal api 
        services.AddSwaggerGen(swagger =>
        {
            swagger.EnableAnnotations();
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "MySpot API",
                Version = "v1"
            });
        });

        return services;
    }
    
    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseSwagger();
        app.UseReDoc(reDoc =>
        {
            reDoc.RoutePrefix = "docs";
            reDoc.DocumentTitle = "My Spot API";
            reDoc.SpecUrl("/swagger/v1/swagger.json");
        });
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        
        return app;
    }
    
    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetSection(sectionName);
        section.Bind(options);

        return options;
    }
}
