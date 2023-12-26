using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVidyalaya.Clean.Application.Features.Category.Queries.GetCategoryDetails
{
    public record GetCategoryDetailsQuery(int Id) : IRequest<CategoryDetailsDto>;
}