using TaskAPI.Data_Access;
using TaskAPI.Models;

namespace TaskAPI.Repositories
{
    public class ProductImgRepository : Repository<ProductImages>
    {
        public ProductImgRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
