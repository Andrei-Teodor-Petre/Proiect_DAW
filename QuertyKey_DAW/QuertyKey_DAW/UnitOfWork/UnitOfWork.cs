using QuertyKey_DAW.DataModels;
using QuertyKey_DAW.Repositories;

namespace QuertyKey_DAW.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuertyKey_DAWContext _context;

        public UnitOfWork(QuertyKey_DAWContext context)
        {
            this._context = context;
            this.Accesories = new AccessoryRepository(_context);
            this.Deskmats = new DeskmatRepository(_context);
            this.Keyboards = new KeyboardRepository(_context);
            this.Keycaps = new KeycapRepository(_context);
            this.Merch = new MerchRepository(_context);
            this.Orders = new OrderRepository(_context);
            this.Specialty = new SpecialtyRepository(_context);
            this.Switches = new SwitchRepository(_context);
            this.Users = new UserRepository(_context);

        }

        public AccessoryRepository Accesories{ get; private set; }
        public DeskmatRepository Deskmats{ get; private set; }
        public KeyboardRepository Keyboards{ get; private set; }
        public KeycapRepository Keycaps{ get; private set; }
        public MerchRepository Merch{ get; private set; }
        public OrderRepository Orders{ get; private set; }
        public SpecialtyRepository Specialty{ get; private set; }
        public SwitchRepository Switches{ get; private set; }
        public UserRepository Users{ get; private set; }

        public int Complete()
        {
            return this._context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

    }
}
