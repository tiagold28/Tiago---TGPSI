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
    public partial class Form9 : Form
    {
        string emailCliente;
        public Form9(string email)
        {
            InitializeComponent();
            emailCliente = email;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(emailCliente);
            form5.Show();
            this.Hide();
        }
    }
}
