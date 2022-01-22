using QuertyKey_DAW.DataModels;

namespace QuertyKey_DAW.Repositories
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(QuertyKey_DAWContext context) : base(context)
        {
        }
    }
}
