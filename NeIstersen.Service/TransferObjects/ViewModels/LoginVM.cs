using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Service.TransferObjects.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string KullaniciAdi { get; set; }

        [Required]
        public string Parola { get; set; }
    }
}
