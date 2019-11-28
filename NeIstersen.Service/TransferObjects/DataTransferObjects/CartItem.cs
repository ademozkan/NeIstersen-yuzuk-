using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Service.TransferObjects.DataTransferObjects
{
    //Sepetteki bir ürünü temsil eden sınıf
    public class CartItem
    {
        public Guid ID { get; set; }
        public string UrunAdi { get; set; }
        public decimal Fiyati { get; set; }
        public decimal YuzukOlcu { get; set; }

        //Sepetteki miktarını tutmak için
        public int Miktari { get; set; }

        public string ImagePath { get; set; }
    }
}
