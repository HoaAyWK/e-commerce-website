using ECW.ApplicationCore.DTOs.Product;
using ECW.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECW.API.Controllers;

public class ProductsController : BaseController
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _productService.GetAsync();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);

        if (product is null)
            return NotFound();
        
        return Ok(product);
    }

    [HttpPost]
    [Route("create")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
    {
        var result = await _productService.CreateAsync(request);

        if (result is null)
            return BadRequest("Something went wrong.");
        
        return Ok(result);
    }

    [HttpPut]
    [Route("update")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Update([FromBody] UpdateProductRequest request)
    {
        var result = await _productService.UpdateAsync(request);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete]
    [Route("delete")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Delete([FromQuery] DeleteProductRequest request)
    {
        var result = await _productService.DeleteAsync(request);

        if (result is null)
            return NotFound();
        
        return Ok(result);
    }
}