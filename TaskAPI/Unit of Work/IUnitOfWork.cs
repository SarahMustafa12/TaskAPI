using TaskAPI.Models;
using TaskAPI.Repositories.IRepository;

namespace TaskAPI.Unit_of_Work
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> Categories { get; }
        IRepository<Product> Products { get; }
        IRepository<ContactUs> ContactUs { get; }
        IRepository<ProductImages> ProductImgs { get; }

        void Commit();
    }
}
