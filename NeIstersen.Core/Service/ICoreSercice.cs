using NeIstersen.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Core.Service
{
    public interface ICoreSercice<T> where T:CoreEntity
    {
        //Genel olarak tüm tabloların ihtiyacı olacak davranışları tanımlıyoruz.
        //Void metotları test etmek zor oldugundan bool tanımladım.
        bool Add(T item);
        bool Add(List<T> items);
        bool Update(T item);
        bool Remove(T item);
        bool Remove(Guid id);

        //Silinmemis bütün ürünleri(durumu aktif olanları)cekmek icin metod
        List<T> GetActive();

        T GetByID(Guid id);

        //kac kayıt etkilendi
        int Save();

        //Alttaki metotlar, parametrelerinde ifade kabul ederler.
        // Örnek : GetDefault(product => product.Price >= 100) gibi.
        T GetByDefault(Expression<Func<T, bool>> exp);
        List<T> GetDefault(Expression<Func<T, bool>> exp);
    }
}
