using QuertyKey_DAW.DataModels;

namespace QuertyKey_DAW.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(QuertyKey_DAWContext context) : base(context)
        {
        }
    }
}
