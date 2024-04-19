using KsiazarniaModels;

namespace KsiazarniaDataAccess.Repository.IRepository
{
    public interface ICoverTypeRepository :  IRepository<CoverType>
    {
        void Update(CoverType coverType);
    }
}
