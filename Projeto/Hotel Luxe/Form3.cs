using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hotel_Luxe
{
    public partial class Form3 : Form
    {
        
        SqlConnection conectar = new SqlConnection(
            @"Server=(localdb)\MSSQLLocalDB;Database=Projeto;Trusted_Connection=True;");
        
        public Form3()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox5.UseSystemPasswordChar = true; // começa escondida
            checkBox1.Checked = false; // começa desmarcado
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                label4.Visible = false;
            }
            else
            {
                label4.Visible = true;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                label5.Visible = false;
            }
            else
            {
                label5.Visible = true;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                label6.Visible = false;
            }
            else
            {
                label6.Visible = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
             textBox5.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            string nome = textBox3.Text.Trim();
            string email = textBox4.Text.Trim();
            string password = textBox5.Text;

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Por favor, introduz o teu nome.", "Nome em falta",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }

            bool emailValido = System.Text.RegularExpressions.Regex.IsMatch(email,@"^[^@\s]+@gmail\.com$",System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (!emailValido)
            {
                MessageBox.Show("Introduz um email válido no formato exemplo@gmail.com.",
                                "Email inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                textBox4.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, introduz a tua password.",
                                "Password em falta",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                textBox5.Focus();
                return;
            }

            try
            {
                using (SqlConnection conectar = new SqlConnection(
                    @"Server=(localdb)\MSSQLLocalDB;Database=Projeto;Trusted_Connection=True;"))
                {
                    conectar.Open();

                    // Verifica se o email já existe
                    string verificar = "SELECT COUNT(*) FROM Utilizadores WHERE Email = @Email";

                    using (SqlCommand cmdVerificar = new SqlCommand(verificar, conectar))
                    {
                        cmdVerificar.Parameters.AddWithValue("@Email", email);

                        int existe = (int)cmdVerificar.ExecuteScalar();

                        if (existe > 0)
                        {
                            MessageBox.Show("Este email já está registado.");
                            return;
                        }
                    }

                    // Inserir utilizador
                    string sql = @"INSERT INTO Utilizadores (Nome, Email, Senha)
                           VALUES (@Nome, @Email, @Senha)";

                    using (SqlCommand cmd = new SqlCommand(sql, conectar))
                    {
                        cmd.Parameters.AddWithValue("@Nome", nome);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Senha", password);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Conta criada com sucesso!");

                Form4 form4 = new Form4(email);
                form4.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar conta: " + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
