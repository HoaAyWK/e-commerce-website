using ECW.ApplicationCore.Entities;
using ECW.ApplicationCore.Interfaces;
using ECW.Infrastructure.Data;

namespace ECW.Infrastructure.Repositories;

public class BrandsRepository : GenericRepository<Brand>, IBrandsRepository
{
    public BrandsRepository(ProductContext context) : base(context)
    {
    }
}