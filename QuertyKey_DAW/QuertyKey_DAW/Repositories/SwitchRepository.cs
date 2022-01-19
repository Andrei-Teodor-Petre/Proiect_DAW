using QuertyKey_DAW.DataModels;
using QuertyKey_DAW.EF;

namespace QuertyKey_DAW.Repositories
{
    public class SwitchRepository : GenericRepository<Switch>
    {
        public SwitchRepository(DataContext context) : base(context)
        {
        }
    }
}
