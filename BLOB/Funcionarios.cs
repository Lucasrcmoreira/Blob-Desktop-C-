using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace BLOB
{
    public partial class Funcionarios : Form
    {
        string Conexaobd = ConfigurationManager.ConnectionStrings["conexaobd"].ToString();
        int Idgrupo;
        // public Funcionarios(int resultado)
        //{
        //  InitializeComponent();
        //  }
        public Funcionarios()
        {
            InitializeComponent();
        }

        private void dgvConfig()
        {
            banco AttFunc = new banco();
            var AtualizarFunc = AttFunc.iniciardgvFunc(Conexaobd);
            dgvfunc.DataSource = AtualizarFunc;

            dgvfunc.Columns[0].HeaderCell.Value = "ID";
            dgvfunc.Columns[1].HeaderCell.Value = "PERMISSAO";
            dgvfunc.Columns[2].HeaderCell.Value = "Nome Funcionario";
            dgvfunc.Columns[3].HeaderCell.Value = "E-mail";
            dgvfunc.Columns[4].HeaderCell.Value = "CPF";
            dgvfunc.Columns[5].HeaderCell.Value = "Telefone";
            dgvfunc.Columns[6].HeaderCell.Value = "Sexo";
            dgvfunc.Columns[7].HeaderCell.Value = "Data Nascimento";
            dgvfunc.Columns[8].HeaderCell.Value = "Data Admissao";
            dgvfunc.Columns[9].HeaderCell.Value = "Cargo";
            dgvfunc.Columns[10].HeaderCell.Value = "CEP";
            dgvfunc.Columns[11].HeaderCell.Value = "Endereco";
            dgvfunc.Columns[12].HeaderCell.Value = "Cidade";
            dgvfunc.Columns[13].HeaderCell.Value = "UF";
            dgvfunc.Columns[14].HeaderCell.Value = "Data Cadastro";


            dgvfunc.RowsDefaultCellStyle.BackColor = Color.White;
            dgvfunc.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
        }

        private void dgvConfigBuscar()
        {
            string btnBuscar = txtBuscar.Text;

            banco Func = new banco();
            var dgvFunc = Func.BuscarFunc(btnBuscar, Conexaobd);
            dgvfunc.DataSource = dgvFunc;

            dgvfunc.Columns[0].HeaderCell.Value = "ID";
            dgvfunc.Columns[1].HeaderCell.Value = "PERMISSAO";
            dgvfunc.Columns[2].HeaderCell.Value = "Nome Funcionario";
            dgvfunc.Columns[3].HeaderCell.Value = "E-mail";
            dgvfunc.Columns[4].HeaderCell.Value = "CPF";
            dgvfunc.Columns[5].HeaderCell.Value = "Telefone";
            dgvfunc.Columns[6].HeaderCell.Value = "Sexo";
            dgvfunc.Columns[7].HeaderCell.Value = "Data Nascimento";
            dgvfunc.Columns[8].HeaderCell.Value = "Data Admissao";
            dgvfunc.Columns[9].HeaderCell.Value = "Cargo";
            dgvfunc.Columns[10].HeaderCell.Value = "CEP";
            dgvfunc.Columns[11].HeaderCell.Value = "Endereco";
            dgvfunc.Columns[12].HeaderCell.Value = "Cidade";
            dgvfunc.Columns[13].HeaderCell.Value = "UF";
            dgvfunc.Columns[14].HeaderCell.Value = "Data Cadastro";


            dgvfunc.RowsDefaultCellStyle.BackColor = Color.White;
            dgvfunc.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
        }

        private void LimparCampos()
        {
            txtcargo.SelectedIndex = -1;
            txtcep.Clear();
            txtpm.SelectedIndex = -1;
            txtnasc.Clear();
            dtadm.Clear();
            txtid.Clear();
            txtsenha.Clear();
            txtcsenha.Clear();
            txtnome.Clear();
            txtemail.Clear();
            txtcpf.Clear();
            txtcid.Clear();
            txtcid.Clear();
            txtend.Clear();
            txttel.Clear();
            txtsexo.SelectedIndex = -1;
            txtuf.SelectedIndex = -1;
            txtnasc.Clear();
            txtBuscar.Clear();

        }

        private void HabilitarCampos()
        {
            txtcargo.Enabled = true;
            txtcep.Enabled = true;
            txtpm.Enabled = true;
            txtnasc.Enabled = true;
            dtadm.Enabled = true;
            txtid.Enabled = false;
            txtsenha.Enabled = true;
            txtcsenha.Enabled = true;
            txtnome.Enabled = true;
            txtemail.Enabled = true;
            txtcpf.Enabled = true;
            txtcid.Enabled = true;
            txtcid.Enabled = true;
            txtend.Enabled = true;
            txttel.Enabled = true;
            txtsexo.Enabled = true;
            txtuf.Enabled = true;
            txtnasc.Enabled = true;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            btnExcluir.Enabled = true;
            btnEditar.Enabled = true;
        }

        private void DesabilitarCampos()
        {
            txtid.Enabled = false;
            txtsenha.Enabled = false;
            txtcsenha.Enabled = false;
            txtnome.Enabled = false;
            txtemail.Enabled = true;
            txtcpf.Enabled = false;
            txtcid.Enabled = false;
            txtcid.Enabled = false;
            txtend.Enabled = false;
            txttel.Enabled = false;
            txtsexo.Enabled = false;
            txtuf.Enabled = false;
            toolStrip1.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnExcluir.Enabled = false;
            btnEditar.Enabled = false;
            txtnasc.Enabled = false;
            dtadm.Enabled = false;
            txtpm.Enabled = false;
            txtcep.Enabled = false;
            txtemail.Enabled = false;
            txtcargo.Enabled = false;
            txtBuscar.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void dgvSelecionar()
        {
            string permissao;

            txtid.Text = dgvfunc.CurrentRow.Cells[0].Value.ToString();
            permissao = dgvfunc.CurrentRow.Cells[1].Value.ToString();
            if (permissao == "1") { txtpm.Text = "Administrador"; }
            else { txtpm.Text = "Funcionario"; }
            txtnome.Text = dgvfunc.CurrentRow.Cells[2].Value.ToString();
            txtemail.Text = dgvfunc.CurrentRow.Cells[3].Value.ToString();
            txtcpf.Text = dgvfunc.CurrentRow.Cells[4].Value.ToString();
            txttel.Text = dgvfunc.CurrentRow.Cells[5].Value.ToString();
            txtsexo.Text = dgvfunc.CurrentRow.Cells[6].Value.ToString();
            txtnasc.Text = dgvfunc.CurrentRow.Cells[7].Value.ToString();
            dtadm.Text = dgvfunc.CurrentRow.Cells[8].Value.ToString();
            txtcargo.Text = dgvfunc.CurrentRow.Cells[9].Value.ToString();
            txtcep.Text = dgvfunc.CurrentRow.Cells[10].Value.ToString();
            txtend.Text = dgvfunc.CurrentRow.Cells[11].Value.ToString();
            txtcid.Text = dgvfunc.CurrentRow.Cells[12].Value.ToString();
            txtuf.Text = dgvfunc.CurrentRow.Cells[13].Value.ToString();
        }

        public Funcionarios(int IdGrupo)
        {
            InitializeComponent();
            Idgrupo = IdGrupo;
        }

        private void Funcionarios_Load(object sender, EventArgs e)
        {
            txtsenha.UseSystemPasswordChar = true;
            txtcsenha.UseSystemPasswordChar = true;

            if (Idgrupo == 2)
            {
                DesabilitarCampos();
            }

            else
            {
                HabilitarCampos();
            }

            dgvConfig();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            LimparCampos();
            dgvConfigBuscar();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string Id = txtid.Text;
            string Senha = txtsenha.Text;
            string Csenha = txtcsenha.Text;
            string Nome = txtnome.Text;
            string Sexo = txtsexo.Text;
            string Cpf = txtcpf.Text;
            string Tel = txttel.Text;
            string Email = txtemail.Text;
            string End = txtend.Text;
            string Cid = txtcid.Text;
            string Uf = txtuf.Text;
            string Nasc = txtnasc.Text;
            string Pm = txtpm.Text;
            string Admissao = dtadm.Text;
            string Cargo = txtcargo.Text;
            string Cep = txtcep.Text;


            Nasc = DateTime.Parse(Nasc).ToString("yyyy-MM-dd");
            Admissao = DateTime.Parse(Admissao).ToString("yyyy-MM-dd");

            if (Nome == "" || Senha == "" || Csenha == "" || Sexo == "" || Cpf == "" || Tel == "" || Email == "" || End == "" || Cid == "" || Uf == "" || Nasc == "" || Pm == "")
            {
                MessageBox.Show("obrigatório preencher os campos em branco ! ", "ERRO");
                return;
            }

            if (Csenha != Senha)
            {
                MessageBox.Show("Senhas não conferem ", "ERRO");
                return;
            }
            else
            {

                MySqlConnection conexao = new MySqlConnection(Conexaobd);

                if (Pm == "admin")
                {
                    Pm = "1";
                    int valor = Convert.ToInt32(Pm);
                }

                else
                {
                    Pm = "2";
                    int valor = Convert.ToInt32(Pm);
                }

                try
                {
                    conexao.Open();
                    MySqlCommand cmdSalvar = new MySqlCommand("INSERT INTO tb_usuario (id_grupo_usuario, nome, email, senha, cpf, telefone, sexo, dt_nasc, dt_admissao, cargo, cep, endereco, cidade, estado)" + "VALUES ('" + Pm + "','" + Nome + "','" + Email + "','" + Senha + "','" + Cpf + "','" + Tel + "','" + Sexo + "','" + Nasc + "','" + Admissao + "','" + Cargo + "','" + Cep + "','" + End + "','" + Cid + "','" + Uf + "')", conexao);
                    MySqlDataReader reader = cmdSalvar.ExecuteReader();
                    MessageBox.Show("Registrado com Sucesso !!");

                    LimparCampos();
                    dgvConfig();
                    return;
                }
                catch
                {
                    MessageBox.Show("nao foi possivel conectar", "ERRO E CONEXAO");
                    conexao.Close();
                    return;
                }
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            string Pm = txtpm.Text;
            string Id = txtid.Text;
            string Senha = txtsenha.Text;
            string Csenha = txtcsenha.Text;
            string Nome = txtnome.Text;
            string Sexo = txtsexo.Text;
            string Cpf = txtcpf.Text;
            string Tel = txttel.Text;
            string Email = txtemail.Text;
            string End = txtend.Text;
            string Cid = txtcid.Text;
            string Uf = txtuf.Text;
            string Nasc = txtnasc.Text;
            string Admissao = dtadm.Text;
            string Cargo = txtcargo.Text;
            string Cep = txtcep.Text;


            if (string.IsNullOrEmpty(txtid.Text))
            {
                MessageBox.Show("Selecione o Funcionário na tabela abaixo e clique em 'Selecionar' ou clique duas vezes na linha Selecionada ", "Não foi possível Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Nasc = DateTime.Parse(Nasc).ToString("yyyy-MM-dd");
            Admissao = DateTime.Parse(Admissao).ToString("yyyy-MM-dd");

            if (Pm == "Administrador")
            {
                Pm = "1";
                int valor = Convert.ToInt32(Pm);
            }

            else
            {
                Pm = "2";
                int valor = Convert.ToInt32(Pm);
            }

            MySqlConnection conexao = new MySqlConnection(Conexaobd);

            if (MessageBox.Show("Tem certeza que deseja Editar Dados Deste Funcionario ?", "confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Senha != Csenha)
                {
                    MessageBox.Show("Senhas não conferem ");
                }

                else
                {
                    try
                    {

                        conexao.Open();
                        MySqlCommand cmdEditar = new MySqlCommand("UPDATE tb_usuario SET id_grupo_usuario ='" + Pm + "', nome='" + Nome + "', email ='" + Email + "', senha='" + Senha + "', cpf='" + Cpf + "', telefone='" + Tel + "', sexo='" + Sexo + "', dt_nasc='" + Nasc + "', dt_admissao ='" + Admissao + "', cargo='" + Cargo + "', cep='" + Cep + "', endereco='" + End + "', cidade='" + Cid + "', estado='" + Uf + "' WHERE id_usuario='" + Id + "' ", conexao);
                        MySqlDataReader reader = cmdEditar.ExecuteReader();
                        MessageBox.Show("Editado com Sucesso !!");

                        LimparCampos();
                        dgvConfig();
                        return;

                    }
                    catch
                    {
                        MessageBox.Show("nao foi possivel conectar", "ERRO E CONEXAO");
                        conexao.Close();
                        return;
                    }
                }

            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            LimparCampos();
            DesabilitarCampos();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string Id = txtid.Text;

            if (string.IsNullOrEmpty(txtid.Text))
            {
                MessageBox.Show("Selecione o funcionário na tabela abaixo e clique em 'Selecionar' ou clique duas vezes na linha Selecionada", "Não foi possível Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("TEM CERTEZA QUE DESEJA EXCLUIR FUNCIONÁRIO ?", "confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                MySqlConnection conexao = new MySqlConnection(Conexaobd);

                MySqlCommand cmdExcluir = new MySqlCommand("DELETE FROM tb_usuario WHERE id_usuario= '" + Id + "' ", conexao);
                cmdExcluir.CommandType = CommandType.Text;


                try
                {
                    conexao.Open();
                    cmdExcluir.ExecuteNonQuery();
                    MessageBox.Show("Registro excluído com sucesso!");

                    LimparCampos();
                    dgvConfig();
                }

                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.ToString());
                }
                finally
                {
                    conexao.Close();
                }
            }
        }

        private void dgvfunc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvSelecionar();
            HabilitarCampos();
        }
        private void dgvfunc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            dgvSelecionar();
            HabilitarCampos();
        }

        private void txtBuscar_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dgvConfigBuscar();

            }
        }
    }
}

