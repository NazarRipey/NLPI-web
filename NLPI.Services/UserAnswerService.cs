using AutoMapper;
using NLPI.Core.Abstractions;
using NLPI.Core.Abstractions.IServices;
using NLPI.Core.Models;
using NLPI.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLPI.Services
{
    public class UserAnswerService : BaseService, IUserAnswerService
    {
        public UserAnswerService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(UserAnswer entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task<List<UserAnswer>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task<UserAnswer> GetIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task<UserAnswer> UpdateAsync(UserAnswer entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
