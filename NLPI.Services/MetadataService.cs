using AutoMapper;
using NLPI.Core.Abstractions;
using NLPI.Core.Abstractions.IServices;
using NLPI.Core.DTO.AnotherDTOs.StandartDTOs;
using NLPI.Core.Models;
using NLPI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPI.Services
{
    public class MetadataService : BaseService, IMetadataService
    {
        public MetadataService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(MetadataDTO entity)
        {
            var value = new Metadata();
            _mapper.Map(entity, value);
            await _unitOfWork.MetadataRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
            _mapper.Map(value, entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.MetadataRepo.GetByIdAsync(id);
            await _unitOfWork.MetadataRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<MetadataDTO>> GetAll()
        {
            var metadatas = await _unitOfWork.MetadataRepo.GetAllAsync();
            List<MetadataDTO> metadataDTOs = metadatas.Select(metadata => _mapper.Map(metadata, new MetadataDTO())).ToList();
            return metadataDTOs;
        }

        public virtual async Task<MetadataDTO> GetIdAsync(int id)
        {
            var metadata = await _unitOfWork.MetadataRepo.GetByIdAsync(id);
            if (metadata == null)
                throw new Exception("Such order not found");
            var dto = new MetadataDTO();
            _mapper.Map(metadata, dto);
            return dto;
        }

        public virtual async Task<MetadataDTO> UpdateAsync(MetadataDTO entity)
        {
            var value = new Metadata();
            _mapper.Map(entity, value);
            await _unitOfWork.MetadataRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
