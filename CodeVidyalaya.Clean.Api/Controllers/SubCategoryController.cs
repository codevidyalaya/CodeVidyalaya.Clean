using CodeVidyalaya.Clean.Application.Features.Category.Commands.CreateCategory;
using CodeVidyalaya.Clean.Application.Features.Category.Commands.DeleteCategory;
using CodeVidyalaya.Clean.Application.Features.Category.Commands.UpdateCategory;
using CodeVidyalaya.Clean.Application.Features.Category.Queries.GetAllCategory;
using CodeVidyalaya.Clean.Application.Features.Category.Queries.GetAllSubCategory;
using CodeVidyalaya.Clean.Application.Features.Category.Queries.GetCategoryDetails;
using CodeVidyalaya.Clean.Application.Features.SubCategory.Commands.CreateSubCategory;
using CodeVidyalaya.Clean.Application.Features.SubCategory.Commands.DeleteSubCategory;
using CodeVidyalaya.Clean.Application.Features.SubCategory.Commands.UpdateSubCategory;
using CodeVidyalaya.Clean.Application.Features.SubCategory.Queries.GetAllSubCategory;
using CodeVidyalaya.Clean.Application.Features.SubCategory.Queries.GetSubCategoryDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeVidyalaya.Clean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubCategoryController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<SubCategoryController>
        [HttpGet]
        public async Task<List<SubCategoryDto>> Get()
        {
            return await _mediator.Send(new GetSubCategoryQuery());
        }

        // GET api/<SubCategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoryDetailsDto>> Get(int id)
        {
            var subCategoryDetails = await _mediator.Send(new GetSubCategoryDetailsQuery(id));
            return Ok(subCategoryDetails);
        }

        // POST api/<SubCategoryController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateSubCategoryCommand createSubCategory)
        {

            var response = await _mediator.Send(createSubCategory);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<SubCategoryController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateSubCategoryCommand updateSubCategory)
        {
            await _mediator.Send(updateSubCategory);
            return NoContent();
        }

        // DELETE api/<SubCategoryController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteSubCategoryCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
