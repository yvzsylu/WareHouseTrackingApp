using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depo_Takip_Uygulamasi
{
    class Urun {
        public int UrunId { get; set; }
        public string Ad { get; set; }
        public string Barkod { get; set; }
        public DateTime KayitTarihi { get; set; }

        public Urun(string ad, string barkod) {
            Ad = ad;
            Barkod = barkod;
            KayitTarihi = DateTime.Now;
        }

        public Urun(int id, string ad, string barkod, DateTime kayitTarihi) : this(ad, barkod) {
            UrunId = id;
            KayitTarihi = kayitTarihi;
        }
    }
}
