using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLOB
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        int IdGrupo;
        public Menu(int id_grupo)
        {
            InitializeComponent();
            if (id_grupo == 1) {
                toolStripStatusLabel1.Text = "ADMINISTRADOR";
                }
            else
            {
                toolStripStatusLabel1.Text = "Colaborador Blob";
            }
            IdGrupo = id_grupo;
        }
        
            private void button1_Click(object sender, EventArgs e)
        {
            
            Funcionarios janelaFunc = new Funcionarios(IdGrupo);
            janelaFunc.MdiParent = this.MdiParent;
            janelaFunc.Show();
            
            //this.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Projetos janelaProj = new Projetos(IdGrupo);
            janelaProj.MdiParent = this.MdiParent;
            janelaProj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clientes janelaClient = new Clientes();
            janelaClient.MdiParent = this.MdiParent;
            janelaClient.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.blob.com.br");


            
        }

        private void projetosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Projetos janelaProj = new Projetos();
           janelaProj.MdiParent = this.MdiParent;
           janelaProj.Show();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes janelaClient = new Clientes();
            janelaClient.MdiParent = this.MdiParent;
            janelaClient.Show();
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funcionarios janelaFunc = new Funcionarios();
            janelaFunc.MdiParent = this.MdiParent;
            janelaFunc.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
           
        }

        private void telaDeLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login acessarLogin = new Login();
            acessarLogin.Closed += (s, args) => this.Close();
            acessarLogin.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
