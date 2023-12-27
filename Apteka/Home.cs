using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apteka
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form fAuthorization = new Info();
            fAuthorization.Show();
            fAuthorization.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form fAuthorization = new Lekarstva();
            fAuthorization.Show();
            fAuthorization.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form fAuthorization = new NalichieLekarstva();
            fAuthorization.Show();
            fAuthorization.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
        }
        private void form_FormClosed(object sender, EventArgs e)
        {         
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form fAuthorization = new Zaprosi();
            fAuthorization.Show();
            fAuthorization.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
        }
    }
}
