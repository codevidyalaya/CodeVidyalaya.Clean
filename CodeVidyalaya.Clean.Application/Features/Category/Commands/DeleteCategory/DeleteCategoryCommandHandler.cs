using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using CodeVidyalaya.Clean.Application.Exceptions;
using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToDelete = await _unitOfWork.Category.GetFirstOrDefaultAsync(u => u.Id == request.Id);
            
            if (categoryToDelete == null) {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            await _unitOfWork.Category.Remove(categoryToDelete);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
