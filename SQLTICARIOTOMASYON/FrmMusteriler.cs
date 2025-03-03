using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLTICARIOTOMASYON
{
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select* From TBL_MUSTERILER",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("select SEHIR from TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            listele();
            sehirlistesi();
        }

        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select ILCE from TBL_ILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbil.SelectedIndex+1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbilce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("insert into TBL_MUSTERILER (AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRE) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
            sqlCommand.Parameters.AddWithValue("@p1", txtAd.Text);
            sqlCommand.Parameters.AddWithValue("@p2", txtsoyad.Text);
            sqlCommand.Parameters.AddWithValue("@p3", mskTelefon1.Text);
            sqlCommand.Parameters.AddWithValue("@p4", mskTelefon2.Text);
            sqlCommand.Parameters.AddWithValue("@p5", mskTC.Text);
            sqlCommand.Parameters.AddWithValue("@p6", txtMail.Text);
            sqlCommand.Parameters.AddWithValue("@p7", cmbil.Text);
            sqlCommand.Parameters.AddWithValue("@p8", cmbilce.Text);
            sqlCommand.Parameters.AddWithValue("@p9", rchAdres.Text);
            sqlCommand.Parameters.AddWithValue("@p10", txtvergidairesi.Text);
            sqlCommand.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("Delete from TBL_MUSTERILER where ID=@p1", bgl.baglanti());
            sqlCommand.Parameters.AddWithValue("@p1", Txtid.Text);
            sqlCommand.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            listele();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update TBL_MUSTERILER set AD=@p1,SOYAD=@p2,TELEFON=@p3,TELEFON2=@p4,TC=@p5,MAIL=@p6,IL=@p7,ILCE=@p8,ADRES=@p9,VERGIDAIRE=@p11 where ID=@p10", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtAd.Text);
            komut2.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut2.Parameters.AddWithValue("@p3", mskTelefon1.Text);
            komut2.Parameters.AddWithValue("@p4", mskTelefon2.Text);
            komut2.Parameters.AddWithValue("@p5", mskTC.Text);
            komut2.Parameters.AddWithValue("@p6", txtMail.Text);
            komut2.Parameters.AddWithValue("@p7", cmbil.Text);
            komut2.Parameters.AddWithValue("@p8", cmbilce.Text);
            komut2.Parameters.AddWithValue("@p9", rchAdres.Text);
            komut2.Parameters.AddWithValue("@p10", Txtid.Text);
            komut2.Parameters.AddWithValue("@p11", txtvergidairesi.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["ID"].ToString();
                txtAd.Text = dr["AD"].ToString();
                txtsoyad.Text = dr["SOYAD"].ToString();
                mskTelefon1.Text = dr["TELEFON"].ToString();
                mskTelefon2.Text = dr["TELEFON2"].ToString();
                mskTC.Text = dr["TC"].ToString();
                txtMail.Text = dr["MAIL"].ToString();
                cmbil.Text = dr["IL"].ToString();
                cmbilce.Text = dr["ILCE"].ToString();
                rchAdres.Text = dr["ADRES"].ToString();
                txtvergidairesi.Text = dr["VERGIDAIRE"].ToString();
            }
        }
    }
}
