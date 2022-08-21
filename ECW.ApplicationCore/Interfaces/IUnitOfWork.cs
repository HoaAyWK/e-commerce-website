namespace ECW.ApplicationCore.Interfaces;

public interface IUnitOfWork
{
    IProductsRepository Products { get; }

    IBrandsRepository Brands { get; }

    ICategoriesRepository Categories { get; }

    IBasketsRepository Baskets { get; }

    IOrdersRepository Orders { get; }

    Task CompleteAsync();
}