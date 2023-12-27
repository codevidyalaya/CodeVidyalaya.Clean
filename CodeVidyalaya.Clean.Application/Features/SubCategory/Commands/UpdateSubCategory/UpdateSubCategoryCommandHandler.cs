using AutoMapper;
using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using CodeVidyalaya.Clean.Application.Exceptions;
using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.SubCategory.Commands.UpdateSubCategory
{
    public class UpdateSubCategoryCommandHandler : IRequestHandler<UpdateSubCategoryCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSubCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var subCategoryToUpdate = await _unitOfWork.SubCategory.GetFirstOrDefaultAsync(u => u.Id == request.Id);
            if (subCategoryToUpdate == null)
            {
                throw new NotFoundException(nameof(SubCategory), request.Id);
            }

            _unitOfWork.SubCategory.Update(subCategoryToUpdate);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
