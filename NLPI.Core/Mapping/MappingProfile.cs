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

            CreateMap<Answer, AnswerDTO>().ReverseMap();

            CreateMap<Hint, HintDTO>().ReverseMap();
        }
    }
}
