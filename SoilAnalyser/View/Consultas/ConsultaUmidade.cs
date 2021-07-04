using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoilAnalyser
{
    public partial class ConsultaUmidade : Form
    {
        public ConsultaUmidade()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsultaUmidade_Load(object sender, EventArgs e)
        {
            //atualiza_percentual();
        }

        private void btn_minimiza_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txt_area.Text))
                {
                    MessageBox.Show("Seleciona uma área", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_area.Focus();

                    return;
                }

                TelaCarregandoConsultaUmidade TelaCarregandoConsultaUmidade = new TelaCarregandoConsultaUmidade(txt_area.Text);
                TelaCarregandoConsultaUmidade.ShowDialog();
                percent_umidade.Value = TelaCarregandoConsultaUmidade.umidade;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                    percent_umidade.Value = 0;
                }
                else
                {
                    txt_desc_area.Clear();
                    percent_umidade.Value = 0;
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

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                String pasta = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                System.Diagnostics.Process.Start(pasta + "\\Manuais\\grafico_umidade.pdf");
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
