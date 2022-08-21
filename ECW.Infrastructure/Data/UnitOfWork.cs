using ECW.ApplicationCore.Interfaces;
using ECW.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace ECW.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ProductContext _context;
    private readonly ILogger _logger;

    public IProductsRepository Products { get; private set; } = null!;

    public IBrandsRepository Brands { get; private set; } = null!;

    public ICategoriesRepository Categories { get; private set; } = null!;

    public IBasketsRepository Baskets { get; private set; }

    public IOrdersRepository Orders { get; private set; }

    public UnitOfWork(ProductContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        _logger = loggerFactory.CreateLogger("db_logs");

        Products = new ProductsRepository(_context);
        Brands = new BrandsRepository(_context);
        Categories = new CategoriesRepository(_context);
        Baskets = new BasketsRepository(_context);
        Orders = new OrdersRepository(_context);
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            this._disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}