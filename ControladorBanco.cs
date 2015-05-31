/*
  @Autor: Marcus Vinicius Campos    Email: marcus_ultimate@hotmail.com
  Esta classe pode ser modificada, distribuida gratuitamente e pode ser usada em projetos de qualquer espécie, 
  contanto que não retire os creditos do autor.
*/

//Para usar esta classe, você precisa adicionar esta linha de codigo "using ControladorDeDatabases; em seu classe, formulário, etc...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace ControladorDeDatabases
{
    class ControladorBanco
    {
        private DataTable dataTable = new DataTable();
        private ArrayList tabelaArray;       
        
        public DataTable _dataTable
        {
            get { return dataTable; }
            set { dataTable = value; }
        }

        public ArrayList _tableaArray
        {
            get { return tabelaArray; }
            set { tabelaArray = value; }
        }
      
               

        public void Modificador(string _SQL, bool _enviarMSG = false, string _MSG = "Comando executado com sucesso!")
        {                   
            MySqlConnection objconexao = new MySqlConnection(Program._ConectionStringMySql);
            try
            {
                objconexao.Open();
            }
            catch(Exception ex)
            {             
				MessageBox.Show(ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);			
            }

            try
            {
               if (objconexao.State == ConnectionState.Open)
               {        
                    MySqlCommand CMD = new MySqlCommand(_SQL,objconexao);
                    CMD.ExecuteNonQuery();
                    if (_enviarMSG == true)
                    {
                        MessageBox.Show(_MSG, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }                   
               }
               else
               {
			   
               }
               objconexao.Close();
            }
            catch(Exception ex)
            {
				MessageBox.Show(ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void Visualizador(string _SQL)
        {
            MySqlConnection objconexao = new MySqlConnection(Program._ConectionStringMySql);
            try
            {
                objconexao.Open();
            }
            catch(Exception ex)
            {
               MessageBox.Show(ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (objconexao.State == ConnectionState.Open)
            {
                try
                {
                    _dataTable.Clear();
                    string SQL = _SQL;
                    MySqlDataAdapter objadapter = new MySqlDataAdapter(SQL, objconexao);
                    objadapter.Fill(_dataTable);                    
                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
			
            }
            objconexao.Close();
        }
        
    }
}
