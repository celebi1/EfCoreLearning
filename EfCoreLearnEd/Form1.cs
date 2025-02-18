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

            SqlCommand komut = new SqlCommand("Select * From tbldersler",baglanti);
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
           var query =from item in db.TBLNOTLAR
                      select new
                        {
                            item.NOTID,
                            item.OGR,
                            item.DERS,
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
            //TBLDERSLER d = new TBLDERSLER();
            //d.DERSID = int.Parse(txtDersId.Text);
            //d.DERSAD = txtDersAd.Text;
            t.AD = txtAd.Text;
            t.SOYAD = txtSoyad.Text;

            db.TBLOGRENCI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Eklendi" );
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
            dataGridView1.DataSource =db.TBLOGRENCI.Where(x => x.AD == txtAd.Text | x.SOYAD == txtSoyad.Text).ToList();
        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {
            string aranan = txtAd.Text;
            var degerler = from item in db.TBLOGRENCI
                           where item.AD.Contains(aranan)
                           select item;
            dataGridView1.DataSource = degerler.ToList();
        }
    }
}
