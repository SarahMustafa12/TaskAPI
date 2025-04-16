using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Models;

namespace TaskAPI.Data_Access
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<ContactUs> contactUs { get; set; }
        public DbSet<ProductImages> productImages { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

    }
}
