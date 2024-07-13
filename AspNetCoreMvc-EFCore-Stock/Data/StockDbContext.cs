using AspNetCoreMvc_EFCore_Stock.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvc_EFCore_Stock.Data
{
    public class StockDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-P3IF0B0\\MSSQL2019;Initial Catalog=Stock;User ID=sa;Password=54321;Trust Server Certificate=True");
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q99D8J1\\MSSQL2019;Initial Catalog=Stock;Integrated Security=True;Trust Server Certificate=True"); /*Sql Server'a Windows Authentication ile bağlanıyorsak.*/
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}