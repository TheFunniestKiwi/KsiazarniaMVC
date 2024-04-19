using KsiazarniaDataAccess.Repository.IRepository;
using KsiazarniaModels;

namespace KsiazarniaDataAccess.Repository
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        private readonly ApplicationDbContext _db;
        public AppUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
