using QuertyKey_DAW.DataModels;

namespace QuertyKey_DAW.Repositories
{
    public class SpecialtyRepository : GenericRepository<Specialty>
    {
        public SpecialtyRepository(QuertyKey_DAWContext context) : base(context)
        {
        }
    }
}
