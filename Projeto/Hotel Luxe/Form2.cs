using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hotel_Luxe
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                label2.Visible = false;
            }
            else
            {
                label2.Visible = true;
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                label3.Visible = false;
            }
            else
            {
                label3.Visible = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string password = textBox2.Text;

            bool emailValido = System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@gmail\.com$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (!emailValido)
            {
                MessageBox.Show("Introduz um email válido no formato exemplo@gmail.com.", "Email inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            // Validar password
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, introduz a tua password.", "Password em falta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            MessageBox.Show("Login com sucesso!");

            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }
    }
}
