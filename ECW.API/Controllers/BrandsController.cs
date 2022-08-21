using AutoMapper;
using ECW.ApplicationCore.DTOs.Brand;
using ECW.ApplicationCore.Entities;
using ECW.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECW.API.Controllers;

public class BrandsController : BaseController
{
    private readonly IBrandService _brandService;
    private readonly IMapper _mapper;

    public BrandsController(IBrandService brandService, IMapper mapper)
    {
        _brandService = brandService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _brandService.GetAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _brandService.GetByIdAsync(id);

        if (result == null)
            return NotFound("Brand not found");
        
        return Ok(result);
    }

    [HttpPost]
    [Route("create")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Create([FromBody] CreateBrandRequest request)
    {
        var result = await _brandService.CreateAsync(request);
        
        return Ok(result);
    }

    [HttpPut]
    [Route("update")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Update([FromBody] UpdateBrandRequest request)
    {
        var mappedBrand = _mapper.Map<Brand>(request);
        var result = await _brandService.UpdateAsync(mappedBrand);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete]
    [Route("delete")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Delete(DeleteBrandRequest request)
    {
        var existingBasket = await _brandService.GetByIdAsync(request.BrandId);
        
        if (existingBasket is null)
            return NotFound();

        var result = await _brandService.DeleteAsync(request);
        
        return Ok(result);
    }
}