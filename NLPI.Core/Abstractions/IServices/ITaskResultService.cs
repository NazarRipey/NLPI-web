using NLPI.Core.Abstractions.IServices.Base;
using NLPI.Core.DTO.AnotherDTOs.SpecializedDTOs;
using NLPI.Core.DTO.AnotherDTOs.StandartDTOs;
using System.Threading.Tasks;

namespace NLPI.Core.Abstractions.IServices
{
    public interface ITaskResultService : IBaseService<TaskResultDTO, TaskResultDTO>
    {
        Task<TaskResultDTO> CreateNewAsync(TaskResultCreateDTO dto);

        Task<TaskResultDTO> EditAsync(TaskResultUpdateDTO dto);
    }
}
