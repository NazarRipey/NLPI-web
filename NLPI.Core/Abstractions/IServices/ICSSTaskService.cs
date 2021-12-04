using NLPI.Core.Abstractions.IServices.Base;
using NLPI.Core.DTO.AnotherDTOs.SpecializedDTOs;
using NLPI.Core.DTO.AnotherDTOs.StandartDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLPI.Core.Abstractions.IServices
{
    public interface ICSSTaskService : IBaseService<CSSTaskDTO, CSSTaskDTO>
    {
        Task<CSSTaskExecDTO> GetExecAsync(int id);
    }
}
