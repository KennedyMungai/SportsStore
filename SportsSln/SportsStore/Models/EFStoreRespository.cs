namespace SportsStore.Models;

public class EFStoreRepository : IStoreRepository
{
    private StoreDbContext context;

    public EFStoreRespository(StoreDbContext ctx)
    {
        context = ctx;
    }

    public IQueryable<Product> Products => context.Products;
}