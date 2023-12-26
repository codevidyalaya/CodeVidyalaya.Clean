using AutoMapper;
using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using CodeVidyalaya.Clean.Application.Exceptions;
using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.SubCategory.Queries.GetSubCategoryDetails
{
    public class GetSubCategoryDetailsQueryHandler : IRequestHandler<GetSubCategoryDetailsQuery, SubCategoryDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetSubCategoryDetailsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public async Task<SubCategoryDetailsDto> Handle(GetSubCategoryDetailsQuery request, CancellationToken cancellationToken)
        {
            var subCategoryDetails = await _unitOfWork.SubCategory.GetFirstOrDefaultAsync(u => u.Id == request.Id);

            if (subCategoryDetails == null)
            {
                throw new NotFoundException(nameof(SubCategory), request.Id);
            }

            var data = _mapper.Map<SubCategoryDetailsDto>(subCategoryDetails);

            //return
            return data;
        }
    }
}
