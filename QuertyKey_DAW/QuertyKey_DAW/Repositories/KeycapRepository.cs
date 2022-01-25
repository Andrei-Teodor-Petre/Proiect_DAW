using QuertyKey_DAW.DataModels;

namespace QuertyKey_DAW.Repositories
{
    public class KeycapRepository : GenericRepository<Keycap>
    {
        public KeycapRepository(QuertyKey_DAWContext context) : base(context)
        {
        }
    }
}
