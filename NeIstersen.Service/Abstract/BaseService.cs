using NeIstersen.Core.Entity;
using NeIstersen.Core.Service;
using NeIstersen.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Service.Abstract
{
    public class BaseService<T> : ICoreSercice<T> where T : CoreEntity
    {
        protected NeIstersenContext _context;
        public BaseService()
        {
            _context = new NeIstersenContext();
        }

        public bool Add(T item)
        {
            try
            {
                //_context.Products.Add(); bu islemin aynısıdır. gelen clasın ne oldugunu bilmediğimiz icin set<T> OLARAK YAZIYIRUZ.
                _context.Set<T>().Add(item);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Add(List<T> items)
        {
            try
            {
                _context.Set<T>().AddRange(items);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<T> GetActive()
        {
            //durumu aktif olanları getir
            return _context.Set<T>().Where(x => x.Durumu == Core.Entity.Enum.Status.Aktif).ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            //fonksiyonu olan ifadeyi getirme
            return _context.Set<T>().Where(exp).FirstOrDefault();
        }

        public T GetByID(Guid id)
        {
            //idsi verilen ürünü döndürür
            return _context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            //fonksiyonda verilen ürünleri döndürür
            return _context.Set<T>().Where(exp).ToList();
        }

        public bool Remove(T item)
        {
            try
            {
                item.Durumu = Core.Entity.Enum.Status.Silinmis;
                Update(item);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Remove(Guid id, Guid userID)
        {
            try
            {
                T item = GetByID(id);
                item.Durumu = Core.Entity.Enum.Status.Silinmis;
                Update(item);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Remove(Guid id)
        {
            try
            {
                T item = GetByID(id);
                item.Durumu = Core.Entity.Enum.Status.Silinmis;
                Update(item);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public bool Update(T item)
        {
            try
            {
                T itemToBeUpdated = GetByID(item.ID);
                DbEntityEntry entry = _context.Entry(itemToBeUpdated);
                //varolan degerlerin uzerine set etme
                entry.CurrentValues.SetValues(item);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
