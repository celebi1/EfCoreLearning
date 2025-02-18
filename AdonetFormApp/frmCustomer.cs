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

namespace AdonetFormApp
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Server=ARDAPOS-1\\SQL2019;initial catalog =DbOrnekChart;integrated security=true");

        private void btnList_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("select [CustomerId],[CustomerName],[CustomerSurname],[CustomerBalance],\r\n[CustomerStatus],[CityName] from TblCustomer Inner join TblCity on TblCity.CityId= TblCustomer.CustomerCity\r\n", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            sqlConnection.Close();
        }

        private void btnProcedure_Click(object sender, EventArgs e)
        {
            // Veritabanı bağlantısını açıyoruz
            sqlConnection.Open();

            // 'CustomerListWithCity' adında bir SQL komutu (Stored Procedure) çalıştırıyoruz
            SqlCommand command = new SqlCommand("execute CustomerListWithCity", sqlConnection);

            // SqlDataAdapter, komut ile veritabanından veri almayı sağlar
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            // Verileri depolamak için bir DataTable oluşturuyoruz
            DataTable dataTable = new DataTable();

            // Veritabanından gelen verileri DataTable'a dolduruyoruz
            adapter.Fill(dataTable);

            // Elde edilen verileri DataGridView kontrolüne bağlıyoruz
            dataGridView1.DataSource = dataTable;

            // Veritabanı bağlantısını kapatıyoruz
            sqlConnection.Close();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select *From TblCity", sqlConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cmbCity.ValueMember = "CityId";
            cmbCity.DisplayMember = "CityName";
            cmbCity.DataSource = dataTable;

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Insert into TblCustomer(CustomerName,CustomerSurname,CustomerCity,CustomerBalance,CustomerStatus)values (@customerName,@CustomerSurname,@customerCity,@customerBalance,@CustomerStatus)",sqlConnection);
            command.Parameters.AddWithValue("@customerName", txtCustomerName.Text);
            command.Parameters.AddWithValue("@CustomerSurname", txtCustomerSurname.Text);
            command.Parameters.AddWithValue("@CustomerCity", cmbCity.SelectedValue);
            command.Parameters.AddWithValue("@CustomerBalance", txtBalance.Text);
            if (rdbActive.Checked)
            {
                command.Parameters.AddWithValue("@CustomerStatus", true);
            }
            if (rdbPassive.Checked)
            {
                command.Parameters.AddWithValue("@CustomerStatus", false);

            }
            command.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Müşteri başarılı bir şekilde eklendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Delete From TblCustomer Where CustomerId=@customerId", sqlConnection);
            command.Parameters.AddWithValue("@customerId", txtCustomerId.Text);
            command.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Müşsteri Başarılı bir şekilde silindi", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("update TblCustomer set CustomerName=@customerName,CustomerSurname=@customerSurname,CustomerCity=@customerCity,CustomerBalance=@customerBalance,CustomerStatus=@customerStatus where CustomerId=@customerId", sqlConnection);
            command.Parameters.AddWithValue("@customerName", txtCustomerName.Text);
            command.Parameters.AddWithValue("@CustomerSurname", txtCustomerSurname.Text);
            command.Parameters.AddWithValue("@CustomerCity", cmbCity.SelectedValue);
            command.Parameters.AddWithValue("@CustomerBalance", txtBalance.Text);
            command.Parameters.AddWithValue("@customerId", txtCustomerId.Text);
            if (rdbActive.Checked)
            {
                command.Parameters.AddWithValue("@CustomerStatus", true);
            }
            if (rdbPassive.Checked)
            {
                command.Parameters.AddWithValue("@CustomerStatus", false);

            }
            command.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Müşteri başarılı bir şekilde güncellendi");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("select [CustomerId],[CustomerName],[CustomerSurname],[CustomerBalance],\r\n[CustomerStatus],[CityName] from TblCustomer Inner join TblCity on TblCity.CityId= TblCustomer.CustomerCity\r\n where CustomerName =@customerName", sqlConnection);
            command.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            sqlConnection.Close();
        }
    }
}
