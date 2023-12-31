using CodeVidyalaya.Clean.Application.Features.Category.Commands.CreateCategory;
using CodeVidyalaya.Clean.Application.Features.Category.Commands.DeleteCategory;
using CodeVidyalaya.Clean.Application.Features.Category.Commands.UpdateCategory;
using CodeVidyalaya.Clean.Application.Features.Category.Queries.GetAllCategory;
using CodeVidyalaya.Clean.Application.Features.Category.Queries.GetCategoryDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeVidyalaya.Clean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<CategoryDto>> Get()
        {
            return await _mediator.Send(new GetCategoryQuery());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDetailsDto>> Get(int id)
        {
            var categoryDetails = await _mediator.Send(new GetCategoryDetailsQuery(id));
            return Ok(categoryDetails);
        }

        // POST api/<CategoryController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateCategoryCommand createCategory)
        {

            var response = await _mediator.Send(createCategory);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateCategoryCommand updateCategory)
        {           
            await _mediator.Send(updateCategory);
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
