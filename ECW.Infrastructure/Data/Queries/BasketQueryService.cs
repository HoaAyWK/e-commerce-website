using ECW.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECW.Infrastructure.Data.Queries;

public class BasketQueryService : IBasketQueryService
{
    private readonly ProductContext _context;

    public BasketQueryService(ProductContext context)
    {
        _context = context;
    }

    public async Task<int> CountTotalBasketItems(string username)
    {
        var totalItems = await _context.Baskets
            .Where(basket => basket.BuyerId == username)
            .SelectMany(item => item.Items)
            .SumAsync(sum => sum.Quantity);
        
        return totalItems;
    }
}