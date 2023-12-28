using CodeVidyalaya.Clean.WebApp.Contracts;
using CodeVidyalaya.Clean.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeVidyalaya.Clean.WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _category;

        public CategoryController(ICategoryServices category)
        {
            this._category = category;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var categoryList = _category.GetCategory();            
            return View(categoryList.Result);
        }

        [HttpGet("{id}")]
        public IActionResult CategoryDetails(int id)
        {
            var categoryDetails = _category.GetCategoryDetails(id);
            return View(categoryDetails.Result);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(CreateCategoryRequest createCategoryRequest)
        {
           // var categoryDetails = _category.GetCategoryDetails(id);

            return View(createCategoryRequest);
        }

    }
}
