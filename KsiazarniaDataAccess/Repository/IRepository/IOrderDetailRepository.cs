using KsiazarniaModels;

namespace KsiazarniaDataAccess.Repository.IRepository
{
    public interface IOrderDetailRepository: IRepository<OrderDetail>
    {
        void Update(OrderDetail orderDetail);
    }
}
