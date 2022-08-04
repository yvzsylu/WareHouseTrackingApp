using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depo_Takip_Uygulamasi
{
    class Hareket
    {
        public int HareketId { get; set; }
        public Urun Urun { get; set; }
        public int Adet { get; set; }
        public string Muhatap { get; set; }
        public DateTime IslemTarihi { get; set; }
    }
}