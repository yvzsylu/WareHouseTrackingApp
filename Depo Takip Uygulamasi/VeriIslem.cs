using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depo_Takip_Uygulamasi
{
    class VeriIslem
    {
        string _baglantiMetni;
        SqlConnection _cnn;
        SqlCommand _cmd;

        public string BaglantiMetni 
        {
            get
            {
                return _baglantiMetni;
            } 
        }

        public string KomutMetni 
        {
            get
            {
                return _cmd.CommandText;
            }
            private set
            {
                if(String.IsNullOrEmpty(value))
                {
                    throw new Exception("komut metni null ya da boş olamaz");
                }

                _cmd.CommandText = value;
            }
        }
        
        public VeriIslem(string baglantiMetni = @"data source=.\SQLEXPRESS;initial catalog = DepoDB; integrated security = true")
        {
            _baglantiMetni = baglantiMetni;

            _cnn = new SqlConnection();
            _cnn.ConnectionString = _baglantiMetni;

            _cmd = new SqlCommand();
            _cmd.Connection = _cnn;
        }

        /*
        public VeriIslem(string komutMetni):this()
        {
            cmd.CommandText = komutMetni;
        }
        */
        void BaglantiAc()
        {
            if (_cnn.State == System.Data.ConnectionState.Closed)
            {
                _cnn.Open();
            }
        }

        void BaglantiKapat()
        {
            _cnn.Close();
        }

        public int ExecuteNonQuery(string komutMetni)
        {
            KomutMetni = komutMetni;
            BaglantiAc();
            int adet = _cmd.ExecuteNonQuery();
            BaglantiKapat();
            return adet;
        }

        public object ExecuteScalar(string komutMetni)
        {
            KomutMetni = komutMetni;
            BaglantiAc();
            object sonuc = _cmd.ExecuteScalar();
            BaglantiKapat();
            return sonuc;
        }

        public SqlDataReader ExecuteReader(string komutMetni)
        {
            KomutMetni = komutMetni;
            BaglantiAc();
            SqlDataReader okuyucu = _cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            return okuyucu;
        }
    }
}
