/*
  @Autor: Marcus Vinicius Campos    Email: marcus_ultimate@hotmail.com
  Esta classe pode ser modificada, distribuida gratuitamente e pode ser usada em projetos de qualquer espécie, 
  contanto que não retire os creditos do autor.
*/

//Para usar esta classe, você precisa adicionar esta linha de codigo "using VerificarIndentidade; em seu classe, formulário, etc...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace VerificarIndentidade
{
    class VerificaIndentidade
    {
        MySqlConnection objconexao = new MySqlConnection(Program._ConectionStringMySql); //Indicar onde ta salva a conection string

        public bool Verifica()
        {
			bool rtn = false;
            try
            {
                objconexao.Open();
            }
            catch
            {
                return;
            }

            if (objconexao.State == ConnectionState.Open)
            {
                string _SQL = "select * from tbl_usuario;";
                MySqlDataAdapter objadapter = new MySqlDataAdapter(_SQL, objconexao);
                DataSet objdataset = new DataSet();
                objadapter.Fill(objdataset);

                if (objdataset.Tables[0].Rows.Count > 0)
                {
					rtn = true;
                }
                else
                {
					rtn = false;
                }
            }
			else
			{
				rtn = false;
			}
        }
    }
}
