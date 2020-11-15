using ProductManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Controllers
{
    public class BrandController : BaseCrudController<Brand>
    {
        public void Create(string name, string street, string zip, string locality, string country)
        {
            Create(new Brand(0, name, street, zip, locality, country));
        }

        public new List<Brand> GetAll()
        {
            return base.GetAll();
        }
        
        public void Update(int id, string name, string street, string zip, string locality, string country)
        {
            Update(new Brand(id, name, street, zip, locality, country));
        }

        public new void Delete(int id)
        {
            base.Delete(id);
        }
    }
}
