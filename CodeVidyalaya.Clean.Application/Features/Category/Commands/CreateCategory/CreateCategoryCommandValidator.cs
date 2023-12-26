using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using FluentValidation;

namespace CodeVidyalaya.Clean.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(p => p.CategoryName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(60).WithMessage("{PropertyName} maximum length is 20 character");

            RuleFor(p => p)
                .MustAsync(CategoryUnique)
                .WithMessage("Category name already exists");
            this._unitOfWork = unitOfWork;
        }

        private Task<bool> CategoryUnique(CreateCategoryCommand command, CancellationToken token)
        {
            return _unitOfWork.Category.IsCategoryUnique(command.CategoryName);
        }
    }
    
}
