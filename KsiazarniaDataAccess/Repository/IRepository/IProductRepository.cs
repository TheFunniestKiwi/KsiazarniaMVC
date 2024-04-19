using KsiazarniaModels;

namespace KsiazarniaDataAccess.Repository.IRepository
{
    public interface IProductRepository :  IRepository<Product>
    {
        void Update(Product product);
    }
}
