using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Core.Entity.Enum
{
    //tabloların durumunu(silinmismi vb.) belirtmek icin acılmıs enum.
    //daha genişletilmek istersek tablo olarak acabiliriz.
    public enum Status
    {
        Yok = 0,
        Aktif = 2,
        Silinmis = 4
    }
}
