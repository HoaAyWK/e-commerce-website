using ECW.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECW.API.Controllers;

public class CategoriesController : BaseController
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _categoryService.GetAsync());
    }
}