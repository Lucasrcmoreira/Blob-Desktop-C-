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
    public partial class Projetos : Form
    {
        int Idgrupo;
        string ConectbdBlob = ConfigurationManager.ConnectionStrings["conexaobd"].ToString();
        public Projetos()
        {
            InitializeComponent();

        }
        public Projetos(int IdGrupo)
        {
            InitializeComponent();
            Idgrupo = IdGrupo;
        }

        private void LimparCampos()
        {
            txtitulo.Clear();
            txtId.Clear();
            txtdesc.Clear();
            txtdtTermino.Clear();
            txtdtInicio.Clear();
            txtstatus.SelectedIndex = -1;
        }
        private void dgvConfigIniciar()
        {
            banco Proj = new banco();
            var dgvProj = Proj.iniciardgvProjeto(ConectbdBlob);
            dgvProjeto.DataSource = dgvProj;

            dgvProjeto.Columns[0].HeaderCell.Value = "ID Do Projeto";
            dgvProjeto.Columns[1].HeaderCell.Value = "ID Status";
            dgvProjeto.Columns[2].HeaderCell.Value = "Titulo";
            dgvProjeto.Columns[3].HeaderCell.Value = "Descricão";
            dgvProjeto.Columns[4].HeaderCell.Value = "Data Inicio";
            dgvProjeto.Columns[5].HeaderCell.Value = "Data Termino Do Projeto";

            dgvProjeto.RowsDefaultCellStyle.BackColor = Color.White;
            dgvProjeto.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
        }

        private void dgvConfigBuscar()
        {
            string cmdBuscarProj = txtBuscar.Text;

            banco Proj = new banco();
            var dgvProj = Proj.PesquisarProjeto(cmdBuscarProj, ConectbdBlob);
            dgvProjeto.DataSource = dgvProj;

            dgvProjeto.Columns[0].HeaderCell.Value = "ID Do Projeto";
            dgvProjeto.Columns[1].HeaderCell.Value = "ID Status";
            dgvProjeto.Columns[2].HeaderCell.Value = "Titulo";
            dgvProjeto.Columns[3].HeaderCell.Value = "Descricão";
            dgvProjeto.Columns[4].HeaderCell.Value = "Data Inicio";
            dgvProjeto.Columns[5].HeaderCell.Value = "Data Termino Do Projeto";

            dgvProjeto.RowsDefaultCellStyle.BackColor = Color.White;
            dgvProjeto.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
        }

        private void SelecionarHabilitar()
        {
            string status;

            txtId.Text = dgvProjeto.CurrentRow.Cells[0].Value.ToString();
            status = dgvProjeto.CurrentRow.Cells[1].Value.ToString();
            if (status == "1") { txtstatus.Text = "Em Andamento"; }
            else { txtstatus.Text = "Arquivado"; }
            txtitulo.Text = dgvProjeto.CurrentRow.Cells[2].Value.ToString();
            txtdesc.Text = dgvProjeto.CurrentRow.Cells[3].Value.ToString();
            txtdtInicio.Text = dgvProjeto.CurrentRow.Cells[4].Value.ToString();
            txtdtTermino.Text = dgvProjeto.CurrentRow.Cells[5].Value.ToString();

            txtId.Enabled = false;
            txtstatus.Enabled = true;
            txtitulo.Enabled = true;
            txtdesc.Enabled = true;
            txtdtInicio.Enabled = true;
            txtdtTermino.Enabled = true;
        }

        private void SelecionarDesabilitar()
        {
            string status;

            txtId.Text = dgvProjeto.CurrentRow.Cells[0].Value.ToString();
            status = dgvProjeto.CurrentRow.Cells[1].Value.ToString();
            if (status == "1") { txtstatus.Text = "Em Andamento"; }
            else { txtstatus.Text = "Arquivado"; }
            txtitulo.Text = dgvProjeto.CurrentRow.Cells[2].Value.ToString();
            txtdesc.Text = dgvProjeto.CurrentRow.Cells[3].Value.ToString();
            txtdtInicio.Text = dgvProjeto.CurrentRow.Cells[4].Value.ToString();
            txtdtTermino.Text = dgvProjeto.CurrentRow.Cells[5].Value.ToString();

            txtId.Enabled = false;
            txtstatus.Enabled = false;
            txtitulo.Enabled = false;
            txtdesc.Enabled = false;
            txtdtInicio.Enabled = false;
            txtdtTermino.Enabled = false;
        }

        private void HabilitarCampos()
        {
            txtId.Enabled = false;
            txtstatus.Enabled = true;
            txtitulo.Enabled = true;
            txtdesc.Enabled = true;
            txtdtInicio.Enabled = true;
            txtdtTermino.Enabled = true;
        }
        private void DesabilitarCampos()
        {
            txtId.Enabled = false;
            txtstatus.Enabled = false;
            txtitulo.Enabled = false;
            txtdesc.Enabled = false;
            txtdtInicio.Enabled = false;
            txtdtTermino.Enabled = false;
        }
        private void Projetos_Load(object sender, EventArgs e)
        {
            dgvConfigIniciar();
            txtId.Enabled = false;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {}

        private void label2_Click(object sender, EventArgs e)
        {}

        private void textBox9_TextChanged(object sender, EventArgs e)
        {}

        private void textBox2_TextChanged(object sender, EventArgs e)
        {}

        private void dgvProjeto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {}

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {}

        private void dgvProjeto_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {}

        private void dgvProjeto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string status;
            status = dgvProjeto.CurrentRow.Cells[1].Value.ToString();
            if (status == "1") { txtstatus.Text = "Em Andamento"; }
            else { txtstatus.Text = "Arquivado"; }

            if (txtstatus.Text == "Em Andamento")
            {
                SelecionarHabilitar();
            }
            if(txtstatus.Text == "Arquivado" && Idgrupo == 2)
            {
                SelecionarDesabilitar();
            }
            else
            {
                SelecionarHabilitar();
                HabilitarCampos();
            }
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            string PId = txtId.Text;
            string Ptitulo = txtitulo.Text;
            string Pstatus = txtstatus.Text;
            string PDescricao = txtdesc.Text;
            string PdtInicio = txtdtInicio.Text;
            string PdtTermino = txtdtTermino.Text;
           
            txtId.Enabled = false;
            int vstatus;

            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Selecione o Projeto na tabela abaixo e clique em 'Selecionar' ou clique duas vezes na linha Selecionada ", "Não foi possível Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PdtInicio = DateTime.Parse(PdtInicio).ToString("yyyy-MM-dd");
            PdtTermino = DateTime.Parse(PdtTermino).ToString("yyyy-MM-dd");


            if (Pstatus == "Em Andamento")
            {
                Pstatus = "1";

                vstatus = Convert.ToInt32(Pstatus);

            }
            if(Pstatus == "Arquivado")
            {
                Pstatus = "0";
                vstatus = Convert.ToInt32(Pstatus);

            }

            MySqlConnection conexao = new MySqlConnection(ConectbdBlob);

            if (MessageBox.Show("Tem certeza que deseja Editar Dados Deste Projeto ?", "confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    conexao.Open();
                    MySqlCommand cmdEditar = new MySqlCommand("UPDATE tb_projeto SET id_status='" + Pstatus + "', titulo='" + Ptitulo + "', descricao='" + PDescricao + "', dt_inicio='" + PdtInicio + "', dt_termino='" + PdtTermino + "' WHERE id_solicitacao ='" + PId + "' ", conexao);
                    MySqlDataReader reader = cmdEditar.ExecuteReader();
                    MessageBox.Show("Editado com Sucesso !!");

                    banco atualizarProj = new banco();
                    var AttProj = atualizarProj.iniciardgvProjeto(ConectbdBlob);
                    dgvProjeto.DataSource = AttProj;

                    LimparCampos();
                    return;
                }
                catch
                {
                    MessageBox.Show("nao foi possivel Editar Projeto", "ERRO");
                    conexao.Close();
                    return;
                }
            }
}

        private void tsPesquisar_Click(object sender, EventArgs e)
        {
            dgvConfigBuscar();
        }

        private void tsCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            DesabilitarCampos();
        }

        private void txtstatus_SelectedIndexChanged(object sender, EventArgs e)
        {}

        private void label3_Click(object sender, EventArgs e)
        {}

        private void bntVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu acessarMenu = new Menu();
            acessarMenu.Closed += (s, args) => this.Close();
            acessarMenu.Show();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dgvConfigBuscar();
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            string status;
            status = dgvProjeto.CurrentRow.Cells[1].Value.ToString();
            if (status == "1") { txtstatus.Text = "Em Andamento"; }
            else { txtstatus.Text = "Arquivado"; }

            if (txtstatus.Text == "Em Andamento" )
            {
                SelecionarHabilitar();
            }
            else
            {
                SelecionarDesabilitar();
            }
        }
    }
}
