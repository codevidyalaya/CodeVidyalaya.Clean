using AutoMapper;
using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using CodeVidyalaya.Clean.Application.Features.Category.Queries.GetAllSubCategory;
using CodeVidyalaya.Clean.Application.Features.SubCategory.Queries.GetAllSubCategory;
using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.Category.Queries.GetAllCategory
{
    public class GetSubCategoryQueryHandler : IRequestHandler<GetSubCategoryQuery, List<SubCategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetSubCategoryQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<SubCategoryDto>> Handle(GetSubCategoryQuery request, CancellationToken cancellationToken)
        {
            //Database
            var subCategoryList = await _unitOfWork.SubCategory.GetAllAsync();

            // Convert
            var data = _mapper.Map<List<SubCategoryDto>>(subCategoryList);
            // return

            return data;
        }

    }
}
