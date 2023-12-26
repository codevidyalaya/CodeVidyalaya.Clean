using AutoMapper;
using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using CodeVidyalaya.Clean.Application.Exceptions;
using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.Category.Queries.GetCategoryDetails
{
    public class GetCategoryDetailsQueryHandler : IRequestHandler<GetCategoryDetailsQuery, CategoryDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoryDetailsQueryHandler(IMapper mapper,IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public Task<CategoryDetailsDto> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
        {
            var categoryDetails = _unitOfWork.Category.GetFirstOrDefaultAsync(u => u.Id == request.Id,"SubCategory");

            if (categoryDetails == null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            var data = _mapper.Map<CategoryDetailsDto>(categoryDetails);

            //return
            return data;                
        }
    }
}
