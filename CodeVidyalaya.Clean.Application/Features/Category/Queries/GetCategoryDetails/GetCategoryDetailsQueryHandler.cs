using AutoMapper;
using CodeVidyalaya.Clean.Application.Contracts.Logging;
using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using CodeVidyalaya.Clean.Application.Exceptions;
using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.Category.Queries.GetCategoryDetails
{
    public class GetCategoryDetailsQueryHandler : IRequestHandler<GetCategoryDetailsQuery, CategoryDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetCategoryDetailsQueryHandler> _logger;

        public GetCategoryDetailsQueryHandler(IMapper mapper,IUnitOfWork unitOfWork,IAppLogger<GetCategoryDetailsQueryHandler> logger)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._logger = logger;
        }

        public async Task<CategoryDetailsDto> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
        {
            var categoryDetails =await _unitOfWork.Category.GetFirstOrDefaultAsync(u => u.Id == request.Id, "Subcategories");

            if (categoryDetails == null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            var data = _mapper.Map<CategoryDetailsDto>(categoryDetails);

            _logger.LogInformation("Category List retrieved successfully");

            //return
            return data;                
        }
    }
}
