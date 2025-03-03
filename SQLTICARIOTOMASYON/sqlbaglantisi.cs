using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace SQLTICARIOTOMASYON
{
     class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=ARDAPOS-1\SQL2019;Initial Catalog=DbLearn;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
