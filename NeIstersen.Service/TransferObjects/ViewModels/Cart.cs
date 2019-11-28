using NeIstersen.Service.TransferObjects.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Service.TransferObjects.ViewModels
{
    //Sepet Sınıfı
    public class Cart
    {
        Dictionary<Guid, CartItem> _myCart = new Dictionary<Guid, CartItem>();


        //Birtur kapsulleme işlemidir.dısarıdan list görunp icerde calısırken dictionary olarak ıslerimi kolaylastırıp daha hızlı calısmaktadır.
        public List<CartItem> MyCart
        {
            get
            {
                return _myCart.Values.ToList();
            }
        }

        //dısarıdan gelen urun sepette varsa miktarını arttır yoksa sepete yeni ekle
        public void AddItem(CartItem item)
        {
            if (_myCart.ContainsKey(item.ID))
            {
                if (item.Miktari > 0)
                {
                    _myCart[item.ID].Miktari += item.Miktari;
                    return;
                }
                else
                {
                    _myCart[item.ID].Miktari += 1;
                    return;

                }

            }
            _myCart.Add(item.ID, item);
        }
    }
}
