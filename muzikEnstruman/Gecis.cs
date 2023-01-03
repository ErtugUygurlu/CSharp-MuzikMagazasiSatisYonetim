using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuzikEnstrumanSatis
{
    public partial class Gecis : Form
    {
        public Gecis()
        {
            InitializeComponent();
        }
        int baslangic = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            baslangic = baslangic + 1;
            bar.Value = baslangic;
            Yuzdelbl.Text = baslangic + "%";
            if (bar.Value == 100)
            {
                bar.Value = 0;
                timer1.Stop();
                Login log = new Login();
                log.Show();
                this.Hide();
            }

        }

        private void Gecis_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

    }
}
