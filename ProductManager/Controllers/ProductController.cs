using ProductManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ProductManager.Controllers
{
    public class ProductController : BaseCrudController<Product>
    {
        public void Create(string name, Brand brand, Category category, decimal weight, decimal price)
        {
            Create(new Product(0, name, brand, category, weight, price));
        }

        public new List<Product> GetAll()
        {
            return base.GetAll();
        }

        public void Update(int id, string name, Brand brand, Category category, decimal weight, decimal price)
        {
            Update(new Product(id, name, brand, category, weight, price));
        }

        public new void Delete(int id)
        {
            base.Delete(id);
        }

        public List<Product> GetAllByBrand(int brandId)
        {
            return base.GetAll().Where(p => p.Brand.Id == brandId).ToList();
        }

        public decimal GetSumByBrand(int brandId)
        {
            return GetAllByBrand(brandId).Sum(p => p.Price);
        }

        public List<Product> GetAllByCategory(Category category)
        {
            return base.GetAll().Where(p => p.Category == category).ToList();
        }

        public Dictionary<Brand, List<Product>> GroupAllByBrand()
        {
            return base.GetAll().GroupBy(p => p.Brand).ToDictionary(group => group.Key, group => group.ToList());
        }

        public Dictionary<Brand, List<Product>> GroupAllByBrandAndOrderByPrice()
        {
            return GroupAllByBrand().ToDictionary(d => d.Key, d => d.Value.OrderBy(p => p.Price).ToList());
        }

        public List<Product> GetAllProductByCategoyUnderPrice(Category category, decimal price)
        {
            return GetAllByCategory(category).Where(p => p.Price < price).ToList();
        }
    }
}
