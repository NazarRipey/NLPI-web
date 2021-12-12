using NLPI.Core.Abstractions.IServices.Base;
using NLPI.Core.DTO.AnotherDTOs.StandartDTOs;
using NLPI.Core.DTO.MainDTOs;
using System.Threading.Tasks;

namespace NLPI.Core.Abstractions.IServices
{
    public interface IUserTaskResultService : IBaseService<TaskResultDTO, TaskResultDTO>
    {
        Task<TaskResultDTO> CreateNewAsync(TaskResultCreateDTO dto);

        Task<TaskScoreDTO> PassTask(TaskPassingDTO taskPassing);
    }
}
