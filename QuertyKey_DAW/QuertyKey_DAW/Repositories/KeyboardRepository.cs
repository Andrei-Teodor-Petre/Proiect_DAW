using QuertyKey_DAW.DataModels;

namespace QuertyKey_DAW.Repositories
{
    public class KeyboardRepository : GenericRepository<Keyboard>
    {
        public KeyboardRepository(QuertyKey_DAWContext context) : base(context)
        {
        }
    }
}
