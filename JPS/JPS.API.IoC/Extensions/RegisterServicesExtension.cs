using JPS.API.IoC.Constants;
using JPS.API.IoC.Filters;
using JPS.API.IoC.SettingsModels;
using JPS.Services.Interfaces.Interfaces;
using JPS.Services.Interfaces.ModelInterfaces;
using JPS.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JPS.API.IoC.Extensions
{
    public static class RegisterServicesExtension
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IPollService, PollService>();
            services.AddTransient<IPollStyleService, PollStyleService>();
            services.AddTransient<IAnswerService, AnswerService>();
            services.AddTransient<IQuestionSectionService, QuestionSectionService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IOptionService, OptionService>();
            services.AddTransient<IOptionRowService, OptionRowService>();
            services.AddTransient<IUtilsService, UtilsService>();
            services.AddTransient<IUsersClaimsAccessorService, UserClaimsAccessorService>();
            services.AddSingleton<IAzureAdOptions, AzureAdOptions>();
            services.AddTransient<IGraphService, FakeGraphService>();
            services.AddScoped<ExceptionFilter>();
            services.AddScoped<ValidateModelAttribute>();
            services.AddTransient<IEmailSenderService, EmailSenderService>();
            services.AddTransient<IAnalyticsService, AnalyticsService>();

            services.AddSingleton<IAzureBlobStorageOptions, AzureBlobStorageOptions>((srvcProvider) => {
                var options = new AzureBlobStorageOptions();
                configuration.Bind(StringConstants.AzureBlobStorageSection, options);
                return options;
            });
        }
    }
}