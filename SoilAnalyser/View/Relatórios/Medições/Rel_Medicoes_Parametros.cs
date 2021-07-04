using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoilAnalyser
{
    public partial class Rel_Medicoes_Parametros : Form
    {
        public Rel_Medicoes_Parametros()
        {
            InitializeComponent();

            txt_data_ini.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            txt_data_fim.CustomFormat = "dd/MM/yyyy HH:mm:ss";
        }

        private void btn_filtro_area_Click(object sender, EventArgs e)
        {
            try
            {
                //Instancia o form de pesquisa
                TelaPesqArea TelaPesqArea = new TelaPesqArea();
                TelaPesqArea.Owner = this;

                // no clique do botão de filtro(lupinha) abre o form de pesquisa.
                TelaPesqArea.ShowDialog();


                if (!String.IsNullOrEmpty(TelaPesqArea.codioRetorno))
                {
                    // Campo pesquisa recebe o código de retorno da pesquisa
                    this.txt_area.Text = TelaPesqArea.codioRetorno;

                    //chama propriedade leave do campo de pesquisa
                    this.txt_area_Leave(null, null);
                }



            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_area_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(txt_area.Text))
                {
                    AreaDAO AreaDAO = new AreaDAO();
                    DataTable dt = new DataTable();
                    dt = AreaDAO.Retornar_areas_porID(txt_area.Text);

                    if (dt.Rows.Count == 1)
                    {
                        txt_area.Text = dt.Rows[0]["id_area"].ToString();
                        txt_desc_area.Text = dt.Rows[0]["descricao"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Área não localizada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_area.Focus();
                    }
                }
                else
                {
                    txt_desc_area.Clear();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_area_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Se a tecla digitada não for numérica
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                {

                    e.Handled = true;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_fecha_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimiza_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int P_ID_AREA;
            int P_ID_AREA_TODOS;
            if (!String.IsNullOrWhiteSpace(txt_area.Text))
            {
                P_ID_AREA  = Convert.ToInt32(txt_area.Text);
                P_ID_AREA_TODOS = 1;
            }
            else
            {
                P_ID_AREA       = 0;
                P_ID_AREA_TODOS = 0;
            }

            string P_DATA_INI = txt_data_ini.Value.ToString("yyyy-MM-dd HH:mm:ss"); ;
            string P_DATA_FIM = txt_data_fim.Value.ToString("yyyy-MM-dd HH:mm:ss");

            //Instancia o form do contrato.
            Rel_Medicoes_View Rel_Medicoes_View = new Rel_Medicoes_View(P_ID_AREA, P_ID_AREA_TODOS, P_DATA_INI, P_DATA_FIM);
            Rel_Medicoes_View.Owner = this;

            //Passa o código do contrato como parâmetro.
            //Comprovante_devolucao.codioRetorno = Convert.ToInt32(txt_contrato.Text);

            //abre o form de contrato.
            Rel_Medicoes_View.ShowDialog();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                String pasta = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                System.Diagnostics.Process.Start(pasta + "\\Manuais\\relatorio_medicoes.pdf");
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
