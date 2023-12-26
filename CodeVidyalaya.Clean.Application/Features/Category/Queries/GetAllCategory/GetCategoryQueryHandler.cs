using AutoMapper;
using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVidyalaya.Clean.Application.Features.Category.Queries.GetAllCategory
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<CategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetCategoryQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            //Database
            var categoryList = await _unitOfWork.Category.GetAllAsync();

            // Convert
            var data = _mapper.Map<List<CategoryDto>>(categoryList);
            // return

            return data;
        }
    }
}
