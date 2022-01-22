using QuertyKey_DAW.DataModels;

namespace QuertyKey_DAW.Repositories
{
    public class MerchRepository : GenericRepository<Merch>
    {
        public MerchRepository(QuertyKey_DAWContext context) : base(context)
        {
        }
    }
}
