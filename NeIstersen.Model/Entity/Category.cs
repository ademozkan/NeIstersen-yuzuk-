using NeIstersen.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Model.Entity
{
    public class Category:CoreEntity
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public string Adi { get; set; }
        public string Aciklama { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
