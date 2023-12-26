using AutoMapper;
using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using CodeVidyalaya.Clean.Application.Exceptions;
using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.SubCategory.Commands.CreateSubCategory
{
    public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSubCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSubCategoryCommandValidator(_unitOfWork);
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
            {
                throw new BadRequestException("Invalid SubCategory", validatorResult);
            }

            var subCategoryToCreate = _mapper.Map<Domain.SubCategory>(request);
            await _unitOfWork.SubCategory.Add(subCategoryToCreate);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
