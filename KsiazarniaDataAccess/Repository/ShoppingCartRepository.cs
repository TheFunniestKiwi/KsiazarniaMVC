﻿using KsiazarniaDataAccess.Repository.IRepository;
using KsiazarniaModels;

namespace KsiazarniaDataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;
        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public int IncrementCount(ShoppingCart cart, int count)
        {
            cart.Count += count;
            return cart.Count;
        }

        public int DecrementCount(ShoppingCart cart, int count)
        {
            cart.Count -= count;
            return cart.Count;
        }
    }
}
