using ECW.ApplicationCore.DTOs.Category;

namespace ECW.ApplicationCore.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAsync();
}