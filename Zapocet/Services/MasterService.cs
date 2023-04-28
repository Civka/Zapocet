using Zapocet.Data;

namespace Zapocet.Services
{
    public class MasterService
    {
        internal ApplicationDbContext _context;
        public MasterService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
