using NLPI.Core.Abstractions.IServices.Base;
using NLPI.Core.DTO.AchievementsDTOs.SpecializedDTOs;
using NLPI.Core.DTO.AchievementsDTOs.StandartDTOs;
using NLPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLPI.Core.Abstractions.IServices
{
    public interface IUserService : IBaseService<UserDTO, SignUpDTO>
    {
        Task<bool> LoginAsync(SignInDTO entity);
        Task<bool> SearchAsync(string email);
        Task<UserDTO> GetProfileInfo(string email);
    }
}
