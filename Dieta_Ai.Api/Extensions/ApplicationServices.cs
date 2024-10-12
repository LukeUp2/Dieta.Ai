using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dieta_Ai.Api.Services;
using DotnetGeminiSDK;

namespace Dieta_Ai.Api.Extensions
{
    public static class ApplicationServices
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddGeminiClient(config =>
            {
                config.ApiKey = Environment.GetEnvironmentVariable("API_KEY") ?? throw new Exception("Algo deu errado");
            });
            services.AddTransient<NutritionServices>();
        }
    }
}