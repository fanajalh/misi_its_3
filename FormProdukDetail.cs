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

namespace FromProdukUtama
{
    public partial class FormProdukDetail : Form
    {
        public FormProdukDetail()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = koneksi.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO Produk (NamaProduk, Harga, Stok,KategoriId) VALUES (@nama, @harga, @stok, @kategori)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nama", txtNamaProduk.Text);
                    cmd.Parameters.AddWithValue("@harga",
                    Convert.ToDecimal(txtHarga.Text));
                    cmd.Parameters.AddWithValue("@stok",
                    Convert.ToInt32(txtStok.Text));
                    cmd.Parameters.AddWithValue("@kategori", ((KeyValuePair<int,
                    string>)cmbKategori.SelectedItem).Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Produk berhasil ditambahkan!");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menambahkan produk: " + ex.Message);
                }
            }
        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormProdukDetail_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = koneksi.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Id, NamaKategori FROM kkategori";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Dictionary<int, string> kategoriDict = new Dictionary<int,
                    string>();
                    while (reader.Read())
                    {
                        kategoriDict.Add((int)reader["Id"],
                        reader["NamaKategori"].ToString());
                    }
                    cmbKategori.DataSource = new BindingSource(kategoriDict, null);
                    cmbKategori.DisplayMember = "Value";
                    cmbKategori.ValueMember = "Key";
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat kategori: " + ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
