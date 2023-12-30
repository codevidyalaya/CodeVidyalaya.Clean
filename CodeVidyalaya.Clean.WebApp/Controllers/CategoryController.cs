using CodeVidyalaya.Clean.WebApp.Contracts;
using CodeVidyalaya.Clean.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CodeVidyalaya.Clean.WebApp.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest createCategoryRequest)
        {
            if (ModelState.IsValid)
            {
                var response = await _category.CreateCategory(createCategoryRequest);

                if (response.Success)
                {
                    return RedirectToAction("CategoryList");
                }
                else
                {
                    foreach (var kvp in response.ValidationErrors)
                    {
                        foreach (var error in kvp.Value)
                        {
                            ModelState.AddModelError(kvp.Key, error);
                        }
                    }
                    return View(createCategoryRequest);
                }
            }
            else
            {
                return View(createCategoryRequest);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if(id > 0)
            {
              await _category.DeleteCategory(id);
            }
            return RedirectToAction("CategoryList");
        }
    }
}
