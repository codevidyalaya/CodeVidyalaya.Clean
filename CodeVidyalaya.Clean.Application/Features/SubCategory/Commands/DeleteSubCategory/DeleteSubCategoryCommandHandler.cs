using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using CodeVidyalaya.Clean.Application.Exceptions;
using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.SubCategory.Commands.DeleteSubCategory
{
    public class DeleteSubCategoryCommandHandler : IRequestHandler<DeleteSubCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSubCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var subCategoryToDelete = await _unitOfWork.SubCategory.GetFirstOrDefaultAsync(u => u.Id == request.Id);

            if (subCategoryToDelete == null)
            {
                throw new NotFoundException(nameof(SubCategory), request.Id);
            }

            await _unitOfWork.SubCategory.Remove(subCategoryToDelete);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
