using NeIstersen.Model.Entity;
using NeIstersen.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Service.Concrete
{
    public class ProductService:BaseService<Product>
    {
        //veri tabanında aynı isimde ürün kontrolu
        public bool ProductVarmı(Product item)
        {
            bool sonuc = _context.Products.Any(c => c.Adi == item.Adi);
            return sonuc;
        }

        //En son eklenen ürünleri veren metot
        public List<Product> SonEklenenUrunler(int productCount)
        {
            return _context.Products.Where(product => product.Durumu == Core.Entity.Enum.Status.Aktif).OrderByDescending(product => product.EklenmeTarihi).Take(productCount).ToList();
        }

        //Categori idye gore urun veren metot
        public List<Product> CategoriIdyeGoreUrunler(Guid id) => GetDefault(product => product.CategoryID == id && product.Durumu == Core.Entity.Enum.Status.Aktif);

        //Product ID ye Gore Urun Veren metot
        public Product ProdutidyeGoreUrun(Guid id) => GetByDefault(product => product.ID == id);
    }
}
