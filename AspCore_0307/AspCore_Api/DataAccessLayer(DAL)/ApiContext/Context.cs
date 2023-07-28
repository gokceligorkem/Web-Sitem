using AspCore_Api.DataAccessLayer_DAL_.Entity;
using Microsoft.EntityFrameworkCore;

namespace AspCore_Api.DataAccessLayer_DAL_.ApiContext
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-CULE9C8; database=PortfolioProjeDBApi; integrated security=true");
        }
        public DbSet<Category> Categories { get; set; }
    }
}
