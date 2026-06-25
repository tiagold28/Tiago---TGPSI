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

namespace Hotel_Luxe
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            // Subscreve os eventos necessários para o cálculo em tempo real
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.guna2DateTimePicker2.ValueChanged += new System.EventHandler(this.guna2DateTimePicker2_ValueChanged);
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            guna2DateTimePicker1.MinDate = DateTime.Today;

            guna2DateTimePicker2.MinDate =
                guna2DateTimePicker1.Value.AddDays(1);

            guna2DateTimePicker2.MaxDate =
                guna2DateTimePicker1.Value.AddDays(90);

            // Executa o cálculo inicial assim que o formulário é carregado
            CalcularEstadia();
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            guna2DateTimePicker2.MinDate =
                guna2DateTimePicker1.Value.AddDays(1);

            guna2DateTimePicker2.MaxDate =
                guna2DateTimePicker1.Value.AddDays(90);

            // Atualiza o valor se a data de início mudar
            CalcularEstadia();
        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            // Atualiza o valor se a data de fim mudar
            CalcularEstadia();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Atualiza o valor se o regime de alojamento mudar
            CalcularEstadia();
        }

        private void CalcularEstadia()
        {
            // Validação de segurança para evitar exceções de referência nula
            if (guna2DateTimePicker1 == null || guna2DateTimePicker2 == null || comboBox1 == null || label6 == null)
            {
                return;
            }

            DateTime dataCheckIn = guna2DateTimePicker1.Value.Date;
            DateTime dataCheckOut = guna2DateTimePicker2.Value.Date;

            // Impede cálculos incorretos se as datas forem inconsistentes
            if (dataCheckOut <= dataCheckIn)
            {
                label6.Text = "0.00€";
                return;
            }

            // Calcula a diferença exata em dias (noites)
            int noites = (dataCheckOut - dataCheckIn).Days;

            double precoPorNoite = 0;
            string regimeSelecionado = comboBox1.SelectedItem?.ToString();

            // Avalia o regime selecionado. Altera os textos caso uses termos diferentes na tua ComboBox
            switch (regimeSelecionado)
            {
                case "Apenas Quarto":
                    precoPorNoite = 50.00;
                    break;
                case "Pequeno-Almoço Incluído":
                    precoPorNoite = 65.00;
                    break;
                case "Pensão Completa":
                    precoPorNoite = 90.00;
                    break;
                default:
                    precoPorNoite = 50.00;
                    break;
            }

            // Realiza a operação matemática e formata a string com duas casas decimais
            double precoTotal = noites * precoPorNoite;
            label6.Text = $"{precoTotal:F2}€";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Por favor, selecione um Regime de Alojamento antes de continuar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (guna2DateTimePicker2.Value.Date <= guna2DateTimePicker1.Value.Date)
            {
                MessageBox.Show("A data de Check-Out tem de ser posterior à data de Check-In.", "Erro de Datas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TimeSpan diferenca = guna2DateTimePicker2.Value.Date - guna2DateTimePicker1.Value.Date;
            int dias = diferenca.Days;

            decimal precoDiario = 0;
            string regimeEscolhido = comboBox1.Text;
            int nomeCliente = 0;

            switch (regimeEscolhido)
            {
                case "Só Alojamento":
                    precoDiario = 50.00m;
                    break;
                case "Pequeno Almoço":
                    precoDiario = 65.00m;
                    break;
                case "Meia Pensão":
                    precoDiario = 90.00m;
                    break;
                case "Pensão Completa":
                    precoDiario = 125.00m;
                    break;
                default:
                    precoDiario = 50.00m;
                    break;
            }

            decimal precoTotal = precoDiario * dias;

            SqlConnection conexao = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Projeto;Trusted_Connection=True;");

            string query = "INSERT INTO ConfirmarReserva (nome_cliente, regime_alimentar, preco_diario, numero_dias, preco_total) " +
                           "VALUES (@nome, @regime, @precoDiario, @dias, @precoTotal)";

            using (SqlCommand cmd = new SqlCommand(query, conexao))
            {
                cmd.Parameters.AddWithValue("@nome", nomeCliente);
                cmd.Parameters.AddWithValue("@regime", regimeEscolhido);
                cmd.Parameters.AddWithValue("@precoDiario", precoDiario);
                cmd.Parameters.AddWithValue("@dias", dias);
                cmd.Parameters.AddWithValue("@precoTotal", precoTotal);

                try
                {
                    conexao.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Reserva Confirmada com Sucesso!\n\n" +
                                    $"Dias de Estadia: {dias}\n" +
                                    $"Preço Diário: {precoDiario:C}\n" +
                                    $"Valor Total a Pagar: {precoTotal:C}",
                                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao ligar ou gravar no SQL Server: " + ex.Message, "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conexao.State == System.Data.ConnectionState.Open)
                    {
                        conexao.Close();
                    }
                }
            }
        }
    }
}