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
    public partial class Clientes : Form
    {
        string ConectbdBlob = ConfigurationManager.ConnectionStrings["conexaobd"].ToString();
        public Clientes()
        {
            InitializeComponent();
        }
      
        private void dgvConfigIniciar()
        {
            banco Clien = new banco();
            var dgvClien = Clien.iniciardgvCliente(ConectbdBlob);
            dgvCliente.DataSource = dgvClien;

            dgvCliente.Columns[0].HeaderCell.Value = "ID";
            dgvCliente.Columns[1].HeaderCell.Value = "Nome Do Cliente";
            dgvCliente.Columns[2].HeaderCell.Value = "E-mail";
            dgvCliente.Columns[3].HeaderCell.Value = "Telefone";
            dgvCliente.Columns[4].HeaderCell.Value = "Data Nascimento";
            dgvCliente.Columns[5].HeaderCell.Value = "Data De Cadastro";
            


            dgvCliente.RowsDefaultCellStyle.BackColor = Color.White;
            dgvCliente.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
        }


        private void dgvConfigBuscar()
        {
            string btnBuscarCliente = tsBuscarClient.Text;

            banco Clien = new banco();
            var dgvClien = Clien.PesquisarCliente(btnBuscarCliente, ConectbdBlob);
            dgvCliente.DataSource = dgvClien;

            dgvCliente.Columns[0].HeaderCell.Value = "ID";
            dgvCliente.Columns[1].HeaderCell.Value = "Nome Do Cliente";
            dgvCliente.Columns[2].HeaderCell.Value = "E-mail";
            dgvCliente.Columns[3].HeaderCell.Value = "Telefone";
            dgvCliente.Columns[4].HeaderCell.Value = "Data Nascimento";
            dgvCliente.Columns[5].HeaderCell.Value = "Data De Cadastro";



            dgvCliente.RowsDefaultCellStyle.BackColor = Color.White;
            dgvCliente.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
        }
        private void Clientes_Load(object sender, EventArgs e)
        {
            
            dgvConfigIniciar();
        }

        private void btnpc_Click(object sender, EventArgs e)
        {
            dgvConfigBuscar();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tsBuscarClient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string CBuscar = tsBuscarClient.Text;
                banco blob = new banco();
                var bdblob = blob.PesquisarCliente(CBuscar, ConectbdBlob);
                dgvCliente.DataSource = bdblob;
                
            }
        }
    }
}
