using TaskAPI.Data_Access;
using TaskAPI.Models;
using TaskAPI.Repositories;
using TaskAPI.Repositories.IRepository;

namespace TaskAPI.Unit_of_Work
{
    public class UnitOfWork : IUnitOfWork
    {
      private readonly ApplicationDbContext _context;

       
        public IRepository<Category> Categories { get; private set; }

        public IRepository<Product> Products { get; private set; }

        public IRepository<ContactUs> ContactUs { get; private set; }

        public IRepository<ProductImages> ProductImgs { get; private set; }

        public UnitOfWork(ApplicationDbContext _context)
        {
            this._context = _context;
            Categories = new Repository<Category>(_context);
            Products = new Repository<Product>(_context);
            ContactUs = new Repository<ContactUs>(_context);
            ProductImgs = new Repository<ProductImages>(_context);
 
        }

       
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose(); 
        }
    }
}
