using TaskAPI.Data_Access;
using TaskAPI.Models;

namespace TaskAPI.Repositories
{
    public class CategoryRepositoy : Repository<Category>
    {
        public CategoryRepositoy(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
