using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using FluentValidation;

namespace CodeVidyalaya.Clean.Application.Features.SubCategory.Commands.CreateSubCategory
{
    internal class CreateSubCategoryCommandValidator : AbstractValidator<CreateSubCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSubCategoryCommandValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(p => p.SubCategoryName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(60).WithMessage("{PropertyName} maximum length is 20 character");

            RuleFor(p => p.CategoryId)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull();

            RuleFor(p => p)
                .MustAsync(SubCategoryUnique)
                .WithMessage("Category name already exists");
            this._unitOfWork = unitOfWork;
        }

        private Task<bool> SubCategoryUnique(CreateSubCategoryCommand command, CancellationToken token)
        {
            return _unitOfWork.SubCategory.IsSubCategoryUnique(command.SubCategoryName);
        }
    }
}