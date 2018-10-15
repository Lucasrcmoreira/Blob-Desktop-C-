using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace BLOB
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        string conexaobd = ConfigurationManager.ConnectionStrings["conexaobd"].ToString();
        public int resultado;
        bool verificar;





        public void FuncLogar()
        {
            string Senha = txtlsenha.Text;
            string Email = txtemail.Text;

            if (Email == "")
            {
                MessageBox.Show("obrigatório preencher os campos em branco ! ", "ERRO");
                txtemail.Focus();
                return;
            }
            if (Senha == "")
            {
                MessageBox.Show("obrigatório preencher os campos em branco ! ", "ERRO");
                txtlsenha.Focus();
                return;
            }

            MySqlConnection conexao = new MySqlConnection(conexaobd);
            MySqlCommand cmdlogin = new MySqlCommand();
            MySqlCommand cmdloginP = new MySqlCommand();

            try
            {
                conexao.Open();
                cmdlogin.Connection = conexao;
                cmdlogin.CommandText = "SELECT email, senha FROM tb_usuario WHERE email = '" + Email + "'AND senha = '" + Senha + "' ";

                cmdloginP.Connection = conexao;
                cmdloginP.CommandText = "SELECT id_grupo_usuario FROM tb_usuario WHERE email = '" + Email + "'AND senha = '" + Senha + "' ";
                MySqlDataReader reader = cmdloginP.ExecuteReader();

                if (reader.Read())
                {
                    resultado = reader.GetInt32(0);
                    reader.Close();
                    verificar = cmdlogin.ExecuteReader().HasRows;

                    if (resultado > 2 && verificar == true)
                    {
                        MessageBox.Show("Cliente não pode Logar neste Sistema", "Segurança BLOB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtemail.Clear();
                        txtlsenha.Clear();
                        txtemail.Focus();
                        
                    }
                    if (resultado < 3 && verificar == true)
                    {
                        if (resultado == 1)
                        {
                            MessageBox.Show("seja bem vindo Administrador BLOB", "Segurança BLOB", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.Hide();
                            Menu acessarMenu = new Menu(resultado);
                            acessarMenu.Closed += (s, args) => this.Close();
                            acessarMenu.Show();
                        }
                        if (resultado == 2)
                        {
                            MessageBox.Show("seja bem vindo Colaborador BLOB", "Segurança BLOB", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.Hide();
                            Menu acessarMenu = new Menu(resultado);
                            acessarMenu.Closed += (s, args) => this.Close();
                            acessarMenu.Show();
                        }
                    }
                }

                if (verificar == false)
                {
                    MessageBox.Show("Login ou Senha Errado", "Não foi possivel Logar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtlsenha.Clear();
                    txtlsenha.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Não foi possivel conectar", "Verifique sua conecção com a internet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtemail.Clear();
                txtlsenha.Clear();
                txtemail.Focus();
            }
           finally
            {
                conexao.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           FuncLogar();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtlsenha.UseSystemPasswordChar = true;
        }
    } 
}

