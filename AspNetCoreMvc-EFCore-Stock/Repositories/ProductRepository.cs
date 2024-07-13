using AspNetCoreMvc_EFCore_Stock.Data;
using AspNetCoreMvc_EFCore_Stock.Models;

namespace AspNetCoreMvc_EFCore_Stock.Repositories
{
    public class ProductRepository
    {
        StockDbContext _context = new StockDbContext();  //veritabanı

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }
        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);  //Ara katmana ekler.
            _context.SaveChanges();         //veritabanıyla eşleştirir.
        }
        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
