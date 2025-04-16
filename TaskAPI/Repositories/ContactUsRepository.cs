using TaskAPI.Data_Access;
using TaskAPI.Models;

namespace TaskAPI.Repositories
{
    public class ContactUsRepository : Repository<ContactUs>
    {
        public ContactUsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
