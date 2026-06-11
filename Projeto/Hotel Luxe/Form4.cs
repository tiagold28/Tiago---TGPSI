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
    public partial class Form4 : Form
    {
        public static int hotelSelecionado = 0;

        public Form4()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e) 
        {
            if (hotelSelecionado != 1)
            {
                hotelSelecionado = 1;
                pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox3.BorderStyle = BorderStyle.None;
                pictureBox4.BorderStyle = BorderStyle.None;
                pictureBox5.BorderStyle = BorderStyle.None;
               
            }
            else if (hotelSelecionado == 1)
            {
                pictureBox1.BorderStyle = BorderStyle.None;
                hotelSelecionado = 0;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (hotelSelecionado != 4)
            {
                hotelSelecionado = 4;
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox3.BorderStyle = BorderStyle.None;
                pictureBox4.BorderStyle = BorderStyle.Fixed3D;
                pictureBox5.BorderStyle = BorderStyle.None;

            }
            else if (hotelSelecionado == 4)
            {
                pictureBox4.BorderStyle = BorderStyle.None;
                hotelSelecionado = 0;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (hotelSelecionado != 2)
            {
                hotelSelecionado = 2;
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox4.BorderStyle = BorderStyle.None;
                pictureBox3.BorderStyle = BorderStyle.None;
                pictureBox2.BorderStyle = BorderStyle.Fixed3D;
                pictureBox5.BorderStyle = BorderStyle.None;

            }
            else if (hotelSelecionado == 2)
            {
                pictureBox2.BorderStyle = BorderStyle.None;
                hotelSelecionado = 0;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (hotelSelecionado != 3)
            {
                hotelSelecionado = 3;
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox4.BorderStyle = BorderStyle.None;
                pictureBox3.BorderStyle = BorderStyle.Fixed3D;
                pictureBox5.BorderStyle = BorderStyle.None;

            }
            else if (hotelSelecionado == 3)
            {
                pictureBox3.BorderStyle = BorderStyle.None;
                hotelSelecionado = 0;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (hotelSelecionado != 5)
            {
                hotelSelecionado = 5;
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox3.BorderStyle = BorderStyle.None;
                pictureBox5.BorderStyle = BorderStyle.Fixed3D;
                pictureBox4.BorderStyle = BorderStyle.None;

            }
            else if (hotelSelecionado == 5)
            {
                pictureBox5.BorderStyle = BorderStyle.None;
                hotelSelecionado = 0;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (hotelSelecionado == 0)
            {
                MessageBox.Show("Por favor, selecione um hotel primeiro!");
                return;
            }

            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
