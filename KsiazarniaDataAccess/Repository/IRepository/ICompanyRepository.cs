using KsiazarniaModels;

namespace KsiazarniaDataAccess.Repository.IRepository
{
    public interface ICompanyRepository: IRepository<Company>
    {
        void Update(Company company);
    }
}
