using AutoMapper;
using NLPI.Core.Abstractions;
using NLPI.Core.Abstractions.IServices;
using NLPI.Core.DTO.AchievementsDTOs.SpecializedDTOs;
using NLPI.Core.DTO.AchievementsDTOs.StandartDTOs;
using NLPI.Core.Models;
using NLPI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPI.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(SignUpDTO entity)
        {
            var value = new User();
            _mapper.Map(entity, value);
            await _unitOfWork.UserRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
            _mapper.Map(value, entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.UserRepo.GetByIdAsync(id);
            await _unitOfWork.UserRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<UserDTO>> GetAll()
        {
            var users = await _unitOfWork.UserRepo.GetAllAsync();
            List<UserDTO> userDTOs = users.Select(user => _mapper.Map(user, new UserDTO())).ToList();
            return userDTOs;
        }

        public virtual async Task<UserDTO> GetIdAsync(int id)
        {
            var user = await _unitOfWork.UserRepo.GetByIdAsync(id);
            if (user == null)
                throw new Exception("Such user not found");
            var dto = new UserDTO();
            _mapper.Map(user, dto);
            return dto;
        }

        public virtual async Task<UserDTO> UpdateAsync(UserDTO entity)
        {
            var value = new User();
            _mapper.Map(entity, value);
            await _unitOfWork.UserRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> LoginAsync(SignInDTO entity)
        {
            var value = (await _unitOfWork.UserRepo.GetAllAsync()).FirstOrDefault(u => u.Email == entity.Email);
            if (value != null)
            {
                if(value.Password == entity.Password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public virtual async Task<bool> SearchAsync(string email)
        {
            var value = (await _unitOfWork.UserRepo.GetAllAsync()).FirstOrDefault(u => u.Email == email);
            if(value != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual async Task<UserDTO> GetProfileInfo(string email)
        {
            var user = (await _unitOfWork.UserRepo.GetAllAsync()).FirstOrDefault(u => u.Email == email);
            if (user == null)
                throw new Exception("Such user not found");
            var dto = new UserDTO();
            _mapper.Map(user, dto);
            return dto;
        }    
    }
}
