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
using Guna.UI2.WinForms;

namespace MuzikEnstrumanSatis
{
    public partial class Bilgi : Form
    {
        public Bilgi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-ORL2PMQ\SQLEXPRESS;Initial Catalog=MuzikDb;Integrated Security=True");

        private void Bilgi_Load(object sender, EventArgs e)
        {
            uyeler();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EnstAdTb.Text == "" || UcretTb.Text == "" || MiktarTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "insert into EnstrumanTbl values ('" + EnstAdTb.Text + "','" + MarkaCb.SelectedItem.ToString() + "','" + MiktarTb.Text + "','" + UcretTb.Text + "','" + KategoriCb.SelectedItem.ToString() + "')";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Enstrüman Başarıyla Eklendi");
                    baglanti.Close();
                    uyeler();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void uyeler()
        {
            baglanti.Open();
            string query = "select * from EnstrumanTbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BilgiDgv.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void Filter()
        {
            baglanti.Open();
            string query = "select * from EnstrumanTbl where EnsMarka= '" + FilterCb.SelectedItem.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BilgiDgv.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int EnsKey;

        private void button3_Click(object sender, EventArgs e)
        {
            if (EnstAdTb.Text == "")
            {
                MessageBox.Show("Silinecek Enstrümanı Seçiniz");
            }
            else
            {
                EnsKey = Convert.ToInt32(BilgiDgv.SelectedRows[0].Cells[0].Value.ToString());
                try
                {
                    baglanti.Open();
                    string query = "delete from EnstrumanTbl where EnsId= " + EnsKey + "";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Enstrüman Başarıyla Silindi");
                    baglanti.Close();
                    uyeler();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void BilgiDgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            EnsKey = Convert.ToInt32(BilgiDgv.SelectedRows[0].Cells[0].Value.ToString());
            EnstAdTb.Text = BilgiDgv.SelectedRows[0].Cells[1].Value.ToString();
            MarkaCb.Text = BilgiDgv.SelectedRows[0].Cells[2].Value.ToString();
            MiktarTb.Text = BilgiDgv.SelectedRows[0].Cells[3].Value.ToString();
            UcretTb.Text = BilgiDgv.SelectedRows[0].Cells[4].Value.ToString();
            KategoriCb.Text = BilgiDgv.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EnstAdTb.Text == "" || UcretTb.Text == "" || MiktarTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "update EnstrumanTbl set EnsAD='" + EnstAdTb.Text + "',EnsMarka='" + MarkaCb.SelectedItem.ToString() + "',EnsMiktar=" + MiktarTb.Text + ",EnsUcret=" + UcretTb.Text + ",EnsKategori='" + KategoriCb.SelectedItem.ToString() + "' where EnsId=" + EnsKey + ";";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Enstrüman Başarıyla Güncellendi");
                    baglanti.Close();
                    uyeler();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void FilterCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Filter();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            uyeler();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (BilgiSifreTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "update AdminTbl set AdminSifre='" + BilgiSifreTb.Text + "'where AdminId=" + 1 + ";";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Şifre Başarıyla Güncellendi");
                    baglanti.Close();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void FilterCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
