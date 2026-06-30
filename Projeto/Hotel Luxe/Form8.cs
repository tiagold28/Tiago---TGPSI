using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Luxe
{
    public partial class Form8 : Form
    {
        string emailCliente;
        string nomeCliente;
        public Form8(string email)
        {
            InitializeComponent();
            emailCliente = email;
  
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(emailCliente);
            form5.Show();
            this.Hide();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form12 form12 = new Form12(emailCliente);
            form12.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
