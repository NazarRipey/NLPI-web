using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using NLPI.Core.Abstractions;
using NLPI.Core.Abstractions.IServices;
using NLPI.Core.Mapping;
using NLPI.DAL;
using NLPI.Services;

namespace NLPI.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserAchievementService, UserAchievementService>();
            services.AddScoped<IAchievementDataService, AchievementDataService>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IHintService, HintService>();
            services.AddScoped<IMetadataService, MetadataService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<ITagDistributionService, TagDistributionService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ITaskResultService, TaskResultService>();
            services.AddScoped<IUnitService, UnitService>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NLPI API", Version = "v1" });
            });
        }

        public static void ConfigureMapping(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
