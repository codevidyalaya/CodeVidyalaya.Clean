﻿using AutoMapper;
using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using CodeVidyalaya.Clean.Application.Exceptions;
using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToUpdate = await _unitOfWork.Category.GetFirstOrDefaultAsync(u => u.Id == request.Id);
            if (categoryToUpdate == null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }
            _unitOfWork.Category.Update(categoryToUpdate);
            await _unitOfWork.Save();
            return categoryToUpdate.Id;
        }
    }
}
