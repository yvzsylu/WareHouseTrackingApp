using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Depo_Takip_Uygulamasi
{
    public partial class Form1 : Form
    {
        private Depo_Takip_Uygulamasi.UrunIslem ui;
        public Form1()
        {
            InitializeComponent();
            ui = new UrunIslem();
        }

        //public void UrunEkle(Urun urn)
        //{ 
        //}

        //public List<Urun> UrunleriGetir()
        //{ 
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            

            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            btnGetir.PerformClick();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Urun u = new Urun(txtAd.Text, txtBarkod.Text);

            ui.UrunEkle(u);

            txtAd.Clear();
            txtBarkod.Text = "";
            
            btnGetir.PerformClick();

            txtAd.Focus();
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            List<Urun> urunler = ui.TumUrunleriGetir();

            dataGridView1.DataSource = urunler;

            //for (int i = 0; i < urunler.Count; i++)
            //{
            //    MessageBox.Show(urunler[i].Ad);
            //}
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txtAd.Focus();
        }

        private void btnGetir_MouseEnter(object sender, EventArgs e)
        {
            btnGetir.BackColor = Color.Red;
        }

        private void btnGetir_MouseLeave(object sender, EventArgs e)
        {
            btnGetir.BackColor = Color.Gray;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek üyeyi gridden secmelisiniz.");
            }

            int urunId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            bool durum = ui.UrunSil(urunId);
            if (durum)
            {
                btnGetir.PerformClick();
            }
            else
            {
                MessageBox.Show("hata");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // lblId.Text = Convert.ToString((int)dataGridView1.SelectedRows[0].Cells[0].Value);
            lblId.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtAd.Text = (string)dataGridView1.SelectedRows[0].Cells[1].Value;
            txtBarkod.Text = (string)dataGridView1.SelectedRows[0].Cells[2].Value;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (lblId.Text != "")
            {
                int id = Convert.ToInt32(lblId.Text);
                
                Urun urn = ui.UrunGetir(id);
                urn.Ad = txtAd.Text;
                urn.Barkod = txtBarkod.Text;

                ui.UrunGuncelle(urn);

                btnGetir.PerformClick();
            }
        }

        
    }
}
