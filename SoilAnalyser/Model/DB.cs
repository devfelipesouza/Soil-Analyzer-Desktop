using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace SoilAnalyser
{
    class DB
    {
        MySqlConnection conn;
        string connString = "SERVER = localhost; PORT = 3306; DATABASE = db_soil_analyser; UID = root; PASSWORD = 1234;";

        public void Conectar()
        {
            if (conn != null)
            {
                conn.Close();
            }

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void testar_conexao()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }

                string StringTesteConexao = "SERVER = localhost; PORT = 3306; DATABASE = db_soil_analyser; UID = root; PASSWORD = 1234;";

                conn = new MySqlConnection();
                conn.ConnectionString = StringTesteConexao;
                conn.Open();
                
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public void ExecutarComandoSQL(string comandoSQL)
        {
            try
            {
                Conectar();

                MySqlCommand comando = new MySqlCommand(comandoSQL, conn);
                comando.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable retorna_registro(String SQL)
        {
            try
            {
                Conectar();

                DataTable dt = new DataTable();


                using (MySqlDataAdapter comando = new MySqlDataAdapter(SQL, conn))
                {
                    comando.Fill(dt);
                }

                return dt;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public MySqlDataReader Listar(String sql)
        {
            try
            {
                Conectar();

                conn = new MySqlConnection();
                MySqlCommand comando = new MySqlCommand(sql, conn);
                MySqlDataReader dr = comando.ExecuteReader();
                dr.Read();
                return dr;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<double> Retorna_list(String SQL, String nColuna)
        {
            try
            {
                Conectar();
                List<double> List_Values = new List<double>();

                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {

                    Double Value = dataReader.GetDouble(dataReader.GetOrdinal(nColuna));

                    List_Values.Add(Value);
                }

                return List_Values;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
