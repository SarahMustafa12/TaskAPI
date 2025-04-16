using TaskAPI.Data_Access;
using TaskAPI.Models;

namespace TaskAPI.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
