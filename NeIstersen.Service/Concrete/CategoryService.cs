using NeIstersen.Model.Entity;
using NeIstersen.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace NeIstersen.Service.Concrete
{
    public class CategoryService:BaseService<Category>
    {
        public bool CategoryVarmi(Category item)
        {
            bool sonuc = _context.Categories.Any(c => c.Adi == item.Adi);
            return sonuc;
        }
    }
}
