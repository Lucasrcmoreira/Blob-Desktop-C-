using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using MySql.Data;

namespace BLOB
{
    public class banco
    {
       



        public DataTable iniciardgvCliente(string ConectbdBlob)
        {

            MySqlConnection conexao = new MySqlConnection(ConectbdBlob);
            MySqlCommand cmdbuscarc = new MySqlCommand("SELECT id_usuario ,nome ,email ,telefone ,dt_nasc ,dt_cadastro  FROM tb_usuario WHERE id_grupo_usuario=3", conexao);

            try
            {
                MySqlDataAdapter DA = new MySqlDataAdapter(cmdbuscarc);
                DataTable DT = new DataTable();

                DA.Fill(DT);

                return DT;
            }

            catch (Exception error)
            {
                throw error;
            }
        }


        public DataTable iniciardgvFunc(string Conexaobd)
        {

            MySqlConnection conexao = new MySqlConnection(Conexaobd);
            MySqlCommand cmdiniciardgvFunc = new MySqlCommand("SELECT id_usuario ,id_grupo_usuario ,nome ,email ,cpf ,telefone ,sexo ,dt_nasc ,dt_admissao ,cargo ,cep ,endereco , cidade ,estado ,dt_cadastro FROM tb_usuario WHERE id_grupo_usuario < 3 ", conexao);

            try
            {
                MySqlDataAdapter DA = new MySqlDataAdapter(cmdiniciardgvFunc);
                DataTable DT = new DataTable();

                DA.Fill(DT);

                return DT;
            }

            catch (Exception error)
            {
                throw error;
            }
        }


            public DataTable iniciardgvProjeto(string ConectbdBlob)
            {

            MySqlConnection conexao = new MySqlConnection(ConectbdBlob);
            MySqlCommand cmdIniciarProj = new MySqlCommand("SELECT id_solicitacao , id_status , titulo , descricao , dt_inicio , dt_termino  FROM tb_projeto", conexao);

            try
            {
                
                MySqlDataAdapter DA = new MySqlDataAdapter(cmdIniciarProj);
                DataTable DT = new DataTable();

                DA.Fill(DT);
                
                return DT;
            }

            catch (Exception error)
            {
                throw error;
            }
            }


       

        public DataTable PesquisarProjeto(string PBuscar, string ConectbdBlob)
        {

            MySqlConnection conexao = new MySqlConnection(ConectbdBlob);
            MySqlCommand cmdBuscarProj = new MySqlCommand("SELECT id_solicitacao, id_status , titulo , descricao , dt_inicio , dt_termino FROM tb_projeto WHERE titulo LIKE '%" + PBuscar + "%'OR descricao LIKE '%" + PBuscar + "%' ", conexao);

            try
            {
                MySqlDataAdapter DA = new MySqlDataAdapter(cmdBuscarProj);
                DataTable DT = new DataTable();

                DA.Fill(DT);

                return DT;
            }

            catch (Exception error)
            {
                throw error;
            }
        }

        public DataTable PesquisarCliente(string CBuscar, string ConectbdBlob)
        {

            MySqlConnection conexao = new MySqlConnection(ConectbdBlob);
            MySqlCommand cmdBuscarCliente = new MySqlCommand("SELECT id_usuario, nome, email, telefone, dt_nasc, dt_cadastro FROM tb_usuario WHERE id_grupo_usuario = 3  AND (nome LIKE '%" + CBuscar + "%'  OR email LIKE '%" + CBuscar + "%' ) ", conexao);

            try
            {
                MySqlDataAdapter DA = new MySqlDataAdapter(cmdBuscarCliente);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                return DT;
            }

            catch (Exception error)
            {
                throw error;
            }
        }

             public DataTable BuscarFunc(string btnBuscar, string conexaobd)
        {

            MySqlConnection conexao = new MySqlConnection(conexaobd);
            MySqlCommand cmdbuscar = new MySqlCommand("SELECT id_usuario ,id_grupo_usuario ,nome ,email ,cpf ,telefone ,sexo ,dt_nasc ,dt_admissao ,cargo ,cep ,endereco , cidade ,estado ,dt_cadastro FROM tb_usuario WHERE id_grupo_usuario < 3 AND (nome LIKE '%" + btnBuscar + "%' OR email LIKE '%" + btnBuscar + "%' OR cpf LIKE '%" + btnBuscar + "%' OR cargo LIKE '%" + btnBuscar + "%' OR telefone LIKE '%" + btnBuscar + "%' OR estado LIKE '%" + btnBuscar + "%')", conexao);

            try
            {
                MySqlDataAdapter DA = new MySqlDataAdapter(cmdbuscar);
                DataTable DT = new DataTable();

                DA.Fill(DT);

                return DT;
            }

            catch (Exception error)
            {
                throw error;
            }
        }

        
    }
}
