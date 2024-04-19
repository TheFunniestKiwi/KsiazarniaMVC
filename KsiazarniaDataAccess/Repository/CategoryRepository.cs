using KsiazarniaDataAccess.Repository.IRepository;
using KsiazarniaModels;

namespace KsiazarniaDataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }

       
    }
}
