using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;

namespace QuizMeister.Core.Extensions
{
    public static class AppSwaggerExtensions
    {

        public static void AddAppSwagger(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(configuration["ApiVersion"], new OpenApiInfo { Title = configuration["ApiTitle"], Version = configuration["ApiVersion"] });
            });


        }
        public static void UseAppSwagger(
            this IApplicationBuilder app,
            IConfiguration configuration
        ) {
            
            app.UseSwagger();
            app.UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint($"/swagger/{configuration["ApiVersion"]}/swagger.json", configuration["ApiVersion"]);
            });
        }
    }
}
