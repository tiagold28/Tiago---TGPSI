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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Hotel_Luxe
{
    public partial class Form5 : Form
    {
        int quartoSelecionado = 0;
        string emailCliente;
      

        SqlConnection conexao = new SqlConnection(
        @"Server=(localdb)\MSSQLLocalDB;Database=Projeto;Trusted_Connection=True;");

        public Form5(string email)
        {
            InitializeComponent();
            emailCliente = email;
           

        }

        bool QuartoDisponivel(int idQuarto)
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT Disponivel FROM Quartos WHERE IdQuarto = @id", conexao);

            cmd.Parameters.AddWithValue("@id", idQuarto);

            conexao.Open();
            object result = cmd.ExecuteScalar();
            conexao.Close();

            return Convert.ToBoolean(result);
        }

        bool SouDonoDaReserva(int idQuarto)
        {
            SqlCommand cmd = new SqlCommand(@"
                SELECT COUNT(*) 
                FROM Reservas 
                WHERE IdQuarto = @Quarto AND EmailCliente = @Email
            ", conexao);

            cmd.Parameters.AddWithValue("@Quarto", idQuarto);
            cmd.Parameters.AddWithValue("@Email", emailCliente);

            conexao.Open();
            int result = (int)cmd.ExecuteScalar();
            conexao.Close();

            return result > 0;
        }

        private void SelecionarQuarto(int id, PictureBox pb)
        {
            bool disponivel = QuartoDisponivel(id);
            bool meuQuarto = SouDonoDaReserva(id);

            if (!disponivel && !meuQuarto)
            {
                MessageBox.Show("❌ Este quarto está ocupado por outro cliente!");
                return;
            }

            quartoSelecionado = id;

            pictureBox1.BorderStyle = BorderStyle.None;
            pictureBox2.BorderStyle = BorderStyle.None;
            pictureBox3.BorderStyle = BorderStyle.None;
            pictureBox4.BorderStyle = BorderStyle.None;
            pictureBox5.BorderStyle = BorderStyle.None;
            pictureBox7.BorderStyle = BorderStyle.None;

            pb.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox1_Click(object sender, EventArgs e) => SelecionarQuarto(1, pictureBox1);
        private void pictureBox2_Click(object sender, EventArgs e) => SelecionarQuarto(2, pictureBox2);
        private void pictureBox5_Click(object sender, EventArgs e) => SelecionarQuarto(3, pictureBox5);
        private void pictureBox3_Click(object sender, EventArgs e) => SelecionarQuarto(4, pictureBox3);
        private void pictureBox4_Click(object sender, EventArgs e) => SelecionarQuarto(5, pictureBox4);
        private void pictureBox7_Click(object sender, EventArgs e) => SelecionarQuarto(6, pictureBox7);

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (quartoSelecionado == 0)
            {
                MessageBox.Show("Selecione um quarto!");
                return;
            }

            bool disponivel = QuartoDisponivel(quartoSelecionado);
            bool meuQuarto = SouDonoDaReserva(quartoSelecionado);

            if (!disponivel && !meuQuarto)
            {
                MessageBox.Show("❌ Este quarto está ocupado por outro cliente!");
                return;
            }

            if (!meuQuarto)
            {
                SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Reservas (EmailCliente, IdQuarto, DataReserva)
                    VALUES (@Email, @Quarto, GETDATE());

                    UPDATE Quartos
                    SET Disponivel = 0
                    WHERE IdQuarto = @Quarto;
                ", conexao);

                cmd.Parameters.AddWithValue("@Email", emailCliente);
                cmd.Parameters.AddWithValue("@Quarto", quartoSelecionado);

                conexao.Open();
                cmd.ExecuteNonQuery();
                conexao.Close();
            }

            AbrirFormQuarto();
        }

        private void AbrirFormQuarto()
        {
            if (quartoSelecionado == 1)
                new Form6(emailCliente).Show();
            else if (quartoSelecionado == 2)
                new Form7(emailCliente).Show();
            else if (quartoSelecionado == 3)
                new Form8(emailCliente).Show();
            else if (quartoSelecionado == 4)
                new Form9(emailCliente).Show();
            else if (quartoSelecionado == 5)
                new Form10(emailCliente).Show();
            else if (quartoSelecionado == 6)
                new Form11(emailCliente).Show();

            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (quartoSelecionado == 0)
            {
                MessageBox.Show("Selecione o quarto que quer cancelar!");
                return;
            }

            if (!SouDonoDaReserva(quartoSelecionado))
            {
                MessageBox.Show("❌ Não podes cancelar esta reserva (não és o dono)!");
                return;
            }

            SqlCommand cmd = new SqlCommand(@"
                DELETE FROM Reservas 
                WHERE EmailCliente = @Email AND IdQuarto = @Quarto;

                UPDATE Quartos 
                SET Disponivel = 1 
                WHERE IdQuarto = @Quarto;
            ", conexao);

            cmd.Parameters.AddWithValue("@Email", emailCliente);
            cmd.Parameters.AddWithValue("@Quarto", quartoSelecionado);

            conexao.Open();
            cmd.ExecuteNonQuery();
            conexao.Close();

            MessageBox.Show("✔ Reserva cancelada com sucesso!");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(emailCliente);
            form4.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}