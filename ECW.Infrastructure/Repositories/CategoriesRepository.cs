using ECW.ApplicationCore.Entities;
using ECW.ApplicationCore.Interfaces;
using ECW.Infrastructure.Data;

namespace ECW.Infrastructure.Repositories;

public class CategoriesRepository : GenericRepository<Category>, ICategoriesRepository
{
    public CategoriesRepository(ProductContext context) : base(context)
    {
    }
}