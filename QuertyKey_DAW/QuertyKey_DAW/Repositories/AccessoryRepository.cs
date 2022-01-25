using QuertyKey_DAW.DataModels;

namespace QuertyKey_DAW.Repositories
{
    public class AccessoryRepository : GenericRepository<Accessory>
    {
        public AccessoryRepository(QuertyKey_DAWContext context) : base(context)
        {
        }
    }
}
