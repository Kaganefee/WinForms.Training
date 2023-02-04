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

namespace Winform.Ornekler
{
    public partial class Frmogrenci : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        /// <summary>
        /// Seçilmiş öğrencileri temizler.
        /// </summary>
        private void ClearInputs()
        {
            txtAdsoyad.Text = "";
            txtTlf.Text = "";
            txtNo.Text = "";
            txtMail.Text = "";
            txtClass.Text = "";
        }

        private bool ValidateInputs()
        {
            return (txtAdsoyad.Text == "") || (txtClass.Text == "") || (txtMail.Text == "") || (txtNo.Text == "") || (txtTlf.Text == "");
        }
        /// <summary>
        /// komut parametrelerini text boxlarla eşitler.
        /// </summary>
        private void ParametreEsitle()
        {
            komut.Parameters.AddWithValue("@AdSoyad", txtAdsoyad.Text);
            komut.Parameters.AddWithValue("@Telefon", txtTlf.Text);
            komut.Parameters.AddWithValue("@Numara", txtNo.Text);
            komut.Parameters.AddWithValue("@Email", txtMail.Text);
            komut.Parameters.AddWithValue("@Sinif", txtClass.Text);
        }
        /// <summary>
        /// Öğrencileri sql serverdan çekmeye yarar.
        /// </summary>
        private void OgrenciGetir()
        {
            baglanti = new SqlConnection("server=.;Initial Catalog=OkulDb;Integrated security=true");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT *FROM Ogrenciler", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        public Frmogrenci()
        {
            InitializeComponent();
        }

        private void Frmogrenci_Load(object sender, EventArgs e)
        {
            OgrenciGetir();
            ClearInputs();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAdsoyad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtTlf.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtNo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtMail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtClass.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                MessageBox.Show("Bütün alanların dolu olduğundan emin olunuz.");
            }
            else
            {
                string sorgu = "INSERT INTO Ogrenciler(AdSoyad,Telefon,Numara,Email,Sinif) VALUES (@AdSoyad,@Telefon,@Numara,@Email,@Sinif)";
                komut = new SqlCommand(sorgu, baglanti);
                ParametreEsitle();
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                OgrenciGetir();
                ClearInputs();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
             if (ValidateInputs())
            {
                MessageBox.Show("Güncellemek için önce bir öğrenci seçiniz veya tüm alanları doldurunuz.");
            }
            else
            {
                string sorgu = "UPDATE Ogrenciler SET AdSoyad=@AdSoyad,Telefon=@Telefon,Numara=@Numara,Email=@Email,Sinif=@Sinif WHERE AdSoyad=@AdSoyad";
                komut = new SqlCommand(sorgu, baglanti);
                ParametreEsitle();
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                OgrenciGetir();
                ClearInputs();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                MessageBox.Show("Silmek için önce bir öğrenci seçiniz");
            }
            else
            {
                var result = MessageBox.Show("Seçilen öğrenciyi silmek istediğinize emin misiniz?", "Öğrenci Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string sorgu = "DELETE FROM Ogrenciler WHERE AdSoyad=@AdSoyad";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@AdSoyad", txtAdsoyad.Text);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    OgrenciGetir();
                    ClearInputs();
                }

            }
        }
    }
}