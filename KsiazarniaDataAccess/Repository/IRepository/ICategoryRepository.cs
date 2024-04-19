using KsiazarniaModels;

namespace KsiazarniaDataAccess.Repository.IRepository
{
    public interface ICategoryRepository: IRepository<Category>
    {
        void Update(Category category);
    }
}
