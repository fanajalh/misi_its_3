using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FromProdukUtama
{
    internal class koneksi
    {
        public static SqlConnection GetConnection()
        {
            // Ganti SERVER_NAME dengan nama server kamu, biasanya
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TokoDB;Integrated Security=True;";
            return new SqlConnection(connectionString);
        }
    }
}
