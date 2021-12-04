using AutoMapper;
using NLPI.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Services.Base
{
    public class BaseService
    {
        protected IUnitOfWork _unitOfWork;
        protected IMapper _mapper;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
