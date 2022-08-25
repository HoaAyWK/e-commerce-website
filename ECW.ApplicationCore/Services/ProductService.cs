using AutoMapper;
using ECW.ApplicationCore.DTOs.Product;
using ECW.ApplicationCore.Entities;
using ECW.ApplicationCore.Interfaces;

namespace ECW.ApplicationCore.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAsync()
    {
        var products = await _unitOfWork.Products.AllAsync();
        var productDtos = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);

        return productDtos;
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        var produtDto = _mapper.Map<ProductDto>(product);

        return produtDto;
    }

    public async Task<CreateProductResponse?> CreateAsync(CreateProductRequest request)
    {
        var product = new Product(
            request.CategoryId,
            request.BrandId,
            request.Description,
            request.Name,
            request.Price,
            request.Image);

        var result = await _unitOfWork.Products.AddAsync(product);

        if (result is null)
            return null;
        
        await _unitOfWork.CompleteAsync();
        var response = _mapper.Map<CreateProductResponse>(result);

        return response;
    }

    public async Task<DeleteProductResponse?> DeleteAsync(DeleteProductRequest request)
    {
        var response = new DeleteProductResponse();
        var productToDelete = await _unitOfWork.Products.GetByIdAsync(request.Id);

        if (productToDelete is null)
            return null;

        _unitOfWork.Products.Delete(productToDelete);
        await _unitOfWork.CompleteAsync();

        return response;
    }

    public async Task<UpdateProductResposne?> UpdateAsync(UpdateProductRequest request)
    {
        var response = new UpdateProductResposne();
        var existingProduct = await _unitOfWork.Products.GetByIdAsync(request.Id);

        if (existingProduct is null)
            return null;

        existingProduct.UpdateBrand(request.BrandId);
        existingProduct.UpdateCategory(request.CategoryId);
        existingProduct.UpdateDetails(request.Name, request.Description, request.Price);
        existingProduct.UpdateImage(request.Image);

        _unitOfWork.Products.Update(existingProduct);
        await _unitOfWork.CompleteAsync();

        var mappedProduct = _mapper.Map<ProductDto>(existingProduct);

        response.Product = mappedProduct;
        return response;
    }

    public async Task<int?> CheckIfNotExistAsync(int[] ids)
    {
        foreach (int id in ids)
        {
            var existingProduct = await _unitOfWork.Products.GetByIdAsync(id);
            
            if (existingProduct == null)
                return id;
        }

        return null;
    }
}