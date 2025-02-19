using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace EfCoreLearnEd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnDersListesi_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=ARDAPOS-1\SQL2019;Initial Catalog=DbEntity;Integrated Security=True");

            SqlCommand komut = new SqlCommand("Select * From tbldersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

        }
        DbEntityEntities db = new DbEntityEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = db.TBLOGRENCI.ToList();
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
        }

        private void btnNotListesi_Click(object sender, EventArgs e)
        {
            var query = from item in db.TBLNOTLAR
                        select new
                        {
                            item.NOTID,
                            item.TBLOGRENCI.AD,
                            item.TBLOGRENCI.SOYAD,
                            item.TBLDERSLER.DERSAD,
                            item.SINAV1,
                            item.SINAV2,
                            item.SINAV3,
                            item.ORTALAMA,
                            item.DURUM
                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLOGRENCI t = new TBLOGRENCI();
            t.AD = txtAd.Text;
            t.SOYAD = txtSoyad.Text;

            db.TBLOGRENCI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Eklendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtOgrencıId.Text);
            var x = db.TBLOGRENCI.Find(id);
            db.TBLOGRENCI.Remove(x);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Silindi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtOgrencıId.Text);
            var x = db.TBLOGRENCI.Find(id);
            x.AD = txtAd.Text;
            x.SOYAD = txtSoyad.Text;
            x.FOTOGRAF = txtFoto.Text;
            db.SaveChanges();
            MessageBox.Show("Öğrenci Güncellendi");

        }

        private void btnProsedur_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.notlist1();
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TBLOGRENCI.Where(x => x.AD == txtAd.Text | x.SOYAD == txtSoyad.Text).ToList();
        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {
            string aranan = txtAd.Text;
            var degerler = from item in db.TBLOGRENCI
                           where item.AD.Contains(aranan)
                           select item;
            dataGridView1.DataSource = degerler.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                List<TBLOGRENCI> liste1 = db.TBLOGRENCI.OrderBy(p => p.AD).ToList();
                dataGridView1.DataSource = liste1;
            }
            if (radioButton2.Checked == true)
            {
                List<TBLOGRENCI> liste2 = db.TBLOGRENCI.OrderByDescending(p => p.AD).ToList();
                dataGridView1.DataSource = liste2;
            }
            if (radioButton3.Checked == true)
            {
                List<TBLOGRENCI> liste3 = db.TBLOGRENCI.OrderBy(p => p.AD).Take(3).ToList();
                dataGridView1.DataSource = liste3;
            }
            if (radioButton4.Checked == true)
            {
                List<TBLOGRENCI> liste4 = db.TBLOGRENCI.Where(p => p.ID == 1).ToList();
                dataGridView1.DataSource = liste4;
            }
            if (radioButton5.Checked == true)
            {
                List<TBLOGRENCI> liste5 = db.TBLOGRENCI.Where(p => p.AD.StartsWith("A")).ToList();
                dataGridView1.DataSource = liste5;
            }
            if (radioButton6.Checked == true)
            {
                bool deger = db.TBLKULUPLER.Any();
                MessageBox.Show(deger.ToString(), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton7.Checked == true)
            {
                int toplam = db.TBLOGRENCI.Count();
                MessageBox.Show(toplam.ToString(), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           if (radioButton8.Checked == true)
            {
                var toplam = db.TBLNOTLAR.Sum(p => p.SINAV1);
                MessageBox.Show("Toplam puan sayısı: " + toplam.ToString(), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
           if (radioButton9.Checked == true)
            {
                var ortalama =db.TBLNOTLAR.Average(p => p.SINAV1);
                MessageBox.Show("Ortalama: " + ortalama.ToString(), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (radioButton10.Checked == true)
            {
                var enyuksek = db.TBLNOTLAR.Max(p => p.SINAV1);
                MessageBox.Show("En yüksek not: " + enyuksek.ToString(), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton11.Checked == true)
            {
                var enkucuk = db.TBLNOTLAR.Min(p => p.SINAV1);
                var enyuksek = db.TBLNOTLAR.Where(p=>p.SINAV1 == enkucuk).ToList();
                MessageBox.Show("En küçük not: " + enkucuk.ToString()+"dsa"+enyuksek.ToString(), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            var sorgu = from d1 in db.TBLNOTLAR 
                        join d2 in db.TBLOGRENCI on d1.OGR equals d2.ID
                        join d3 in db.TBLDERSLER
                        on d1.DERS equals d3.DERSID

                        select new {
                            ogrencı =d2.AD+ " " + d2.SOYAD,
                            sınav1 = d1.SINAV1,
                            sınav2 = d1.SINAV2,
                            sınav3 = d1.SINAV3,
                            ortalama = d1.ORTALAMA,
                            //durum = d1.DURUM
                        };
            dataGridView1.DataSource = sorgu.ToList();
        }
    }
}
