using AutoMapper;
using NLPI.Core.Abstractions;
using NLPI.Core.Abstractions.IServices;
using NLPI.Core.Mapping;
using NLPI.DAL;
using NLPI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            services.AddScoped<ILevelService, LevelService>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<ICSSTaskService, CSSTaskService>();
            services.AddScoped<IHintService, HintService>();
            services.AddScoped<IMetadataService, MetadataService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<ITagDistributionService, TagDistributionService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ITaskDistributionService, TaskDistributionService>();
            services.AddScoped<ITaskResultService, TaskResultService>();
            services.AddScoped<IUnitService, UnitService>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => {
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
