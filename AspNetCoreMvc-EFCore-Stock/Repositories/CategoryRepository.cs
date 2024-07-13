using AspNetCoreMvc_EFCore_Stock.Data;
using AspNetCoreMvc_EFCore_Stock.Models;

namespace AspNetCoreMvc_EFCore_Stock.Repositories
{
    public class CategoryRepository
    {
        StockDbContext _context = new StockDbContext();  //veritabanı

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
        public Category GetById(int id)
        {
            //return _context.Categories.FirstOrDefault(c => c.Id == id);
            return _context.Categories.Find(id);
        }
        public void Add(Category category)
        {
            _context.Categories.Add(category);  //Ara katmana ekler.
            _context.SaveChanges();         //veritabanıyla eşleştirir.
        }
        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
