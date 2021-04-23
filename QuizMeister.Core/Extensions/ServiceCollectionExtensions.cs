using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizMeister.Core.Data;
using QuizMeister.Core.Repositories;

namespace QuizMeister.Core.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(
                (IServiceProvider serviceProvider, DbContextOptionsBuilder options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseSqlServer(configuration["ConnectionStrings:DatabaseConnection"]);
                }
            );
        }

        public static void AddAppRepositories(this IServiceCollection services)
        {
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuizSessionRepository, QuizSessionRepository>();
            services.AddScoped<IQuizAnswerRepository, QuizAnswerRepository>();
        }

    }
}
