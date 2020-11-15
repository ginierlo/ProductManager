using ProductManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductManager.Controllers
{
    public class BaseCrudController<T> where T : IModel
    {
        private List<T> _objs = new List<T>();

        protected void Create(T obj)
        {
            if (!IsListContain(obj))
            {
                obj.Id = GetNewId();
                _objs.Add(obj);
            }
        }

        protected List<T> GetAll()
        {
            return _objs;
        }

        protected void Update(T obj)
        {
            if (_objs.Any(o => o.Id == obj.Id))
                _objs[GetIndexById(obj.Id)] = obj;
        }

        protected void Delete(int id)
        {
            if (_objs.Any(o => o.Id == id))
                _objs.RemoveAt(GetIndexById(id));
        }

        private int GetNewId()
        {
            return _objs.Any() ? _objs.OrderByDescending(o => o.Id).First().Id + 1 : 1;
        }

        private int GetIndexById(int id)
        {
            return _objs.IndexOf(_objs.First(o => o.Id == id));
        }

        private bool IsListContain(T obj)
        {
            return _objs.Any(o => o.Equals(obj));
        }
    }
}
