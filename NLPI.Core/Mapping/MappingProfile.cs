using AutoMapper;
using NLPI.Core.DTO.AchievementsDTOs.SpecializedDTOs;
using NLPI.Core.DTO.AchievementsDTOs.StandartDTOs;
using NLPI.Core.DTO.AnotherDTOs.StandartDTOs;
using NLPI.Core.Models;

namespace NLPI.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<SignUpDTO, User>()
                .ForMember(dest => dest.Role, opts => opts.MapFrom(item => "User"));

            CreateMap<SignInDTO, User>();

            CreateMap<UserAchievement, UserAchievementDTO>()
                .ForMember(dest => dest.UserEmail, opts => opts.MapFrom(item => item.IdUserNavigation.Email));
            //.ForMember(dest => dest.LevelTitle, opts => opts.MapFrom(item => item.IdLevelNavigation.Name));
            CreateMap<UserAchievementDTO, UserAchievement>();

            CreateMap<UserAchievement, GetUserAchievementDTO>()
                .ForMember(dest => dest.UserEmail, opts => opts.MapFrom(item => item.IdUserNavigation.Email));
            //.ForMember(dest => dest.LevelTitle, opts => opts.MapFrom(item => item.IdLevelNavigation.Name));

            CreateMap<SetUserAchievementDTO, AchievementData>();

            CreateMap<AchievementData, AchievementDataDTO>();
            CreateMap<AchievementDataDTO, AchievementData>();

            CreateMap<AchievementData, SimpleAchievDataDTO>()
                .ForMember(dest => dest.SaveDate, opts => opts.MapFrom(item => item.IdUserAchievementNavigation.SaveDate));
            //.ForMember(dest => dest.TrainingTestTitle, opts => opts.MapFrom(item => item.IdUserAchievementNavigation.IdLevelNavigation.Name));

            CreateMap<AchievementData, DetailAchievDataDTO>()
                .ForMember(dest => dest.SaveDate, opts => opts.MapFrom(item => item.IdUserAchievementNavigation.SaveDate))
                //.ForMember(dest => dest.TrainingTestTitle, opts => opts.MapFrom(item => item.IdUserAchievementNavigation.IdLevelNavigation.Name))
                .ForMember(dest => dest.AchievTitle, opts => opts.MapFrom(item => item.IdUserAchievementNavigation.Title))
                .ForMember(dest => dest.AchievNotes, opts => opts.MapFrom(item => item.IdUserAchievementNavigation.Notes));

            CreateMap<Answer, AnswerDTO>().ReverseMap();

            CreateMap<Hint, HintDTO>().ReverseMap();
            CreateMap<Metadata, MetadataDTO>().ReverseMap();
            CreateMap<Question, QuestionDTO>().ReverseMap();
            CreateMap<TagDistribution, TagDistributionDTO>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();

            //CreateMap<UnitDistribution, UnitDistributionDTO>().ReverseMap();
            CreateMap<Unit, UnitDTO>().ReverseMap();
        }
    }
}
