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

namespace MuzikEnstrumanSatis
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-ORL2PMQ\SQLEXPRESS;Initial Catalog=MuzikDb;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            KullaniciTb.Text = "";
            SifreTb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count (*) from AdminTbl where AdminAdSoyad='" + KullaniciTb.Text + "' and AdminSifre='" + SifreTb.Text + "'", baglanti);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Bilgi bil = new Bilgi();
                bil.Show();
                this.Hide();
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Yada Şifre");
            }
            baglanti.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Satis sat = new Satis();
            sat.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
