using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depo_Takip_Uygulamasi
{
    class UrunIslem
    {
        VeriIslem vi;

        public UrunIslem()
        {
            vi = new VeriIslem();
        }


        /// <summary>
        /// Belirtilen ID'ye sahip ürünü veri tabanından getirir. Bu id'ye sahip urun veri tabanında yoksa null deger dondurur.
        /// </summary>
        /// <param name="urunId">Getirelecek urune ait id</param>
        /// <returns>Belirtilen ID'ye sahip ürünü veri tabanından getirir. Urun tipinde döndürür</returns>
        public Urun UrunGetir(int urunId)
        {
            SqlDataReader dr = vi.ExecuteReader("select UrunId,Ad,Barkod,KayitTarihi from Urun where UrunId=" + urunId);

            Urun u = null;

            if (dr.Read())
            {
                int id = (int)dr[0];
                string ad = (string)dr[1];
                string barkod = (string)dr[2];
                DateTime tarih = (DateTime)dr[3];

                u = new Urun(id, ad, barkod, tarih);
            }

            dr.Close();

            return u;
        }

        public List<Urun> TumUrunleriGetir()
        {
            SqlDataReader dr = vi.ExecuteReader("select UrunId,Ad,Barkod,KayitTarihi from Urun");

            List<Urun> urunler = new List<Urun>();

            while (dr.Read())
            {
                int id = (int)dr[0];
                string ad = (string)dr[1];
                string barkod = (string)dr[2];
                DateTime tarih = (DateTime)dr[3];

                Urun u = new Urun(id, ad, barkod, tarih);

                urunler.Add(u);
            }

            dr.Close();

            return urunler;
        }

        public bool UrunEkle(Urun urn)
        {
            int etk = vi.ExecuteNonQuery($"insert into Urun(Ad, Barkod) values('{urn.Ad}', '{urn.Barkod}')");
            return etk == 1;
        }

        public bool UrunGuncelle(Urun guncelUrun)
        {
            int etk = vi.ExecuteNonQuery($"update Urun set Ad = '{guncelUrun.Ad}', Barkod = '{guncelUrun.Barkod}' where UrunId = {guncelUrun.UrunId}");

            return etk == 1;
        }

        public bool UrunSil(Urun silinecekUrun)
        {
            return UrunSil(silinecekUrun.UrunId);
        }

        public bool UrunSil(int urunId)
        {
            int etk = vi.ExecuteNonQuery("delete from Urun where UrunId = " + urunId.ToString());

            return etk == 1;
        }
    }
}
