using QuertyKey_DAW.DataModels;

namespace QuertyKey_DAW.Repositories
{
    public class SwitchRepository : GenericRepository<Switch>
    {
        public SwitchRepository(QuertyKey_DAWContext context) : base(context)
        {
        }
    }
}
