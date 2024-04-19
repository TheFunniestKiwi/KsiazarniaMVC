using KsiazarniaDataAccess.Repository.IRepository;

namespace KsiazarniaDataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Category { get;}
        public ICoverTypeRepository CoverType { get; }
        public IProductRepository Product { get; }
        public ICompanyRepository Company { get; }
        public IShoppingCartRepository ShoppingCart { get; }
        public IAppUserRepository AppUser { get; }
        public IOrderHeaderRepository OrderHeader { get; }
        public IOrderDetailRepository OrderDetail { get; }

        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Category = new CategoryRepository(_db);
            CoverType = new CoverTypeRepository(_db);
            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            AppUser = new AppUserRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
            OrderDetail = new OrderDetailRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
