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
    public partial class Form5 : Form
    {
        int quartoSelecionado = 0;

        public Form5()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (quartoSelecionado != 1) { 
            
                
                quartoSelecionado = 1;
                pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox3.BorderStyle = BorderStyle.None;
                pictureBox4.BorderStyle = BorderStyle.None;
                pictureBox5.BorderStyle = BorderStyle.None;
                pictureBox7.BorderStyle = BorderStyle.None;
            }
            else if (quartoSelecionado == 1)
            {
                pictureBox1.BorderStyle = BorderStyle.None;
                quartoSelecionado = 0;
            }
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (quartoSelecionado != 5)
            {


                quartoSelecionado = 5;
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox3.BorderStyle = BorderStyle.None;
                pictureBox4.BorderStyle = BorderStyle.Fixed3D;
                pictureBox5.BorderStyle = BorderStyle.None;
                pictureBox7.BorderStyle = BorderStyle.None;
            }
            else if (quartoSelecionado == 5)
            {
                pictureBox4.BorderStyle = BorderStyle.None;
                quartoSelecionado = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (quartoSelecionado == 1) 
            { 
                Form6 form6 = new Form6();
                form6.Show();
                this.Hide();
            }
            else if (quartoSelecionado == 2)
            {
                
            }
            else if (quartoSelecionado == 3)
            {
               
            }
            else if (quartoSelecionado == 4)
            {
                
            }
            else if (quartoSelecionado == 5)
            {
               
            }
            else if (quartoSelecionado == 6)
            {
               
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (quartoSelecionado != 6)
            {


                quartoSelecionado = 6;
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox3.BorderStyle = BorderStyle.None;
                pictureBox4.BorderStyle = BorderStyle.None;
                pictureBox5.BorderStyle = BorderStyle.None;
                pictureBox7.BorderStyle = BorderStyle.Fixed3D;
            }
            else if (quartoSelecionado == 6)
            {
                pictureBox7.BorderStyle = BorderStyle.None;
                quartoSelecionado = 0;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (quartoSelecionado != 2)
            {


                quartoSelecionado = 2;
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox2.BorderStyle = BorderStyle.Fixed3D;
                pictureBox3.BorderStyle = BorderStyle.None;
                pictureBox4.BorderStyle = BorderStyle.None;
                pictureBox5.BorderStyle = BorderStyle.None;
                pictureBox7.BorderStyle = BorderStyle.None;
            }
            else if (quartoSelecionado == 2)
            {
                pictureBox2.BorderStyle = BorderStyle.None;
                quartoSelecionado = 0;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (quartoSelecionado != 3)
            {


                quartoSelecionado = 3;
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox3.BorderStyle = BorderStyle.None;
                pictureBox4.BorderStyle = BorderStyle.None;
                pictureBox5.BorderStyle = BorderStyle.Fixed3D;
                pictureBox7.BorderStyle = BorderStyle.None;
            }
            else if (quartoSelecionado == 3)
            {
                pictureBox5.BorderStyle = BorderStyle.None;
                quartoSelecionado = 0;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (quartoSelecionado != 4)
            {


                quartoSelecionado = 4;
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox3.BorderStyle = BorderStyle.Fixed3D;
                pictureBox4.BorderStyle = BorderStyle.None;
                pictureBox5.BorderStyle = BorderStyle.None;
                pictureBox7.BorderStyle = BorderStyle.None;
            }
            else if (quartoSelecionado == 4)
            {
                pictureBox3.BorderStyle = BorderStyle.None;
                quartoSelecionado = 0;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
