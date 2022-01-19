using QuertyKey_DAW.DataModels;
using QuertyKey_DAW.EF;

namespace QuertyKey_DAW.Repositories
{
    public class KeycapRepository : GenericRepository<Keycap>
    {
        public KeycapRepository(DataContext context) : base(context)
        {
        }
    }
}
