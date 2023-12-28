using AutoMapper;
using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using CodeVidyalaya.Clean.Application.Exceptions;
using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCategoryCommandValidator(_unitOfWork);
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
            {
                throw new BadRequestException("Invalid Category", validatorResult);

            }


            var categoryToCreate = _mapper.Map<Domain.Category>(request);
            await _unitOfWork.Category.Add(categoryToCreate);
            await _unitOfWork.Save();

            return categoryToCreate.Id;
        }
    }
}
