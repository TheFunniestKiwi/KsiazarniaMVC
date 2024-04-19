using KsiazarniaDataAccess.Repository.IRepository;
using KsiazarniaModels;

namespace KsiazarniaDataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderHeader orderHeader)
        {
            _db.OrderHeaders.Update(orderHeader);
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var orderDb = _db.OrderHeaders.FirstOrDefault(u=>u.Id == id);
            if (orderDb is not null)
            {
                orderDb.OrderStatus = orderStatus;
                if (paymentStatus is not null)
                {
                    orderDb.PaymentStatus = paymentStatus;
                }
            }
        }

        public void UpdateStripePaymentId(int id, string sessionId, string? paymentIntentId)
        {
            var orderDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
           
            orderDb.PaymentDate = DateTime.Now;
            orderDb.SessionId = sessionId;
            orderDb.PaymentIntentId = paymentIntentId; 
        }
    }
}
