using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using DataAccessLayer;
using BusinessLogicLayer;

namespace Ogrenci_Not
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void OgrenciListele()
        {
            List<EntityOgrenci> OgrList = BllOgrenci.GetAll();
            dataGridView1.DataSource = OgrList;
            this.Text = "Öğrenci Listesi";
        }

        void KulupListele()
        {
            List<EntityKulup> KlpList = BllKulup.GetAll();
            cmbKulup.DisplayMember = "KulupAd";
            cmbKulup.ValueMember = "KulupID";
            cmbKulup.DataSource = KlpList;
            dataGridView1.DataSource = KlpList;
            this.Text = "Kulüp Listesi";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            OgrenciListele();
            KulupListele();
        }

        void NotListele()
        {
            List<EntityNotlar> entNot = BllNotlar.GetAll();
            dataGridView1.DataSource = entNot;
            this.Text = "Not Listesi";
        }

       

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            EntityOgrenci ent = new EntityOgrenci();
            ent.Ad = txtAd.Text;
            ent.Soyad = txtSoyad.Text;
            ent.Fotograf = txtFotograf.Text;
            ent.KulupID =Convert.ToInt16( cmbKulup.SelectedValue);
            BllOgrenci.Add(ent);
            MessageBox.Show("Öğrenci Kaydı Yapıldı","Yeni Kayıt",MessageBoxButtons.OK,MessageBoxIcon.Information);
            OgrenciListele();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            OgrenciListele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            EntityOgrenci ent = new EntityOgrenci();
            ent.Ad = txtAd.Text;
            ent.Soyad = txtSoyad.Text;
            ent.Fotograf = txtFotograf.Text;
            ent.KulupID = Convert.ToInt16(cmbKulup.SelectedValue);
            ent.ID =Convert.ToInt16( txtid.Text);
            BllOgrenci.Update(ent);
            MessageBox.Show("Öğrenci Bilgileri Güncellendi","Bilgi Güncelleme",MessageBoxButtons.OK,MessageBoxIcon.Information);
            OgrenciListele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(this.Text == "Öğrenci Listesi")
            {
                txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtFotograf.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                cmbKulup.SelectedIndex = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()) - 1;
            }

            if(this.Text=="Not Listesi")
            {
                txtOgrID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                
                txts1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txts2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txts3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            
        }

        private void btnNotListele_Click(object sender, EventArgs e)
        {
            NotListele();
        }

        private void btnKulupListele_Click(object sender, EventArgs e)
        {
            KulupListele();
        }

        private void btnNotGuncelle_Click(object sender, EventArgs e)
        {
            EntityNotlar ent = new EntityNotlar();
            ent.OgrID =Convert.ToInt16( txtOgrID.Text);
            ent.Sinav1 =Convert.ToByte( txts1.Text);
            ent.Sinav2 =Convert.ToByte( txts2.Text);
            ent.Sinav3 =Convert.ToByte( txts3.Text);
            ent.Proje=Convert.ToByte( txtProje.Text);
            ent.Ortalama=Convert.ToByte( txtOrtalama.Text);
            ent.Durum = txtDurum.Text.ToString();
            BllNotlar.Update(ent);
            MessageBox.Show("Not Güncellendi");
            NotListele();
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            int s1, s2, s3, proje;
            double ortalama;
            
            s1 =Convert.ToInt16( txts1.Text);
            s2 =Convert.ToInt16( txts2.Text);
            s3 =Convert.ToInt16( txts3.Text);
            proje = Convert.ToInt16(txtProje.Text);
            ortalama = (s1 + s2 + s3 + proje) / 4;
            txtOrtalama.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                txtDurum.Text="True";
            }
            else
            {
                txtDurum.Text = "False";
            }
        }

        private void btnKulupKaydet_Click(object sender, EventArgs e)
        {
            EntityKulup ent = new EntityKulup();
           
            ent.KulupAd = txtKulupad.Text;
            BllKulup.Add(ent);
            MessageBox.Show("Kulüp Eklendi");
            KulupListele();
        }

        private void btnkulupsil_Click(object sender, EventArgs e)
        {
            EntityKulup ent = new EntityKulup();
            ent.KulupID =Convert.ToInt16 (txtKulupid.Text);
            BllKulup.Delete(ent.KulupID);
            MessageBox.Show("Kulüp Silindi.");
            KulupListele();
        }

        private void btnKulupGuncelle_Click(object sender, EventArgs e)
        {
            EntityKulup ent = new EntityKulup();
            ent.KulupID = Convert.ToInt16(txtKulupid.Text);
            ent.KulupAd = txtKulupad.Text;
            BllKulup.Update(ent);
            MessageBox.Show("Kulüp Güncellendi");
            KulupListele();
        }
    }
}
