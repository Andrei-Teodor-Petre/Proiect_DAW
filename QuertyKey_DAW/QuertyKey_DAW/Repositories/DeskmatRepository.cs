using QuertyKey_DAW.DataModels;

namespace QuertyKey_DAW.Repositories
{
    public class DeskmatRepository : GenericRepository<Deskmat>
    {
        public DeskmatRepository(QuertyKey_DAWContext context) : base(context)
        {
        }
    }
}
