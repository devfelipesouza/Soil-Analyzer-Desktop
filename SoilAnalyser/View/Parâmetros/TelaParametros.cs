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
    public partial class TelaParametros : Form
    {
        ParametrosDAO ParametrosDAO = new ParametrosDAO();
        public TelaParametros()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Controla_Checks(Bunifu.Framework.UI.BunifuCheckbox Chk)
        {
            try
            {
                Chk_1minuto.Checked = false;
                Chk_30minutos.Checked = false;
                Chk_1hora.Checked = false;
                Chk_3horas.Checked = false;

                Chk.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }


        private void Chk_1minuto_OnChange(object sender, EventArgs e)
        {
            Controla_Checks(Chk_1minuto);
        }

        private void Chk_30minutos_OnChange(object sender, EventArgs e)
        {
            Controla_Checks(Chk_30minutos);
        }

        private void Chk_1hora_OnChange(object sender, EventArgs e)
        {
            Controla_Checks(Chk_1hora);
        }

        private void Chk_3horas_OnChange(object sender, EventArgs e)
        {
            Controla_Checks(Chk_3horas);
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            try
            {


                decimal tempo_registro = 0m; //Minutos

                if (Chk_1minuto.Checked)
                {
                    tempo_registro = 1; //Minutos
                }
                else if (Chk_30minutos.Checked)
                {
                    tempo_registro = 30; //Minutos
                }
                else if (Chk_1hora.Checked)
                {
                    tempo_registro = 60; //Minutos
                }
                else if (Chk_3horas.Checked)
                {
                    tempo_registro = 180; //Minutos
                }

                ParametrosDAO.Atualizar_parametros(tempo_registro);

                MessageBox.Show("Registros atualizados com sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void carrega_dados()
        {
            try
            {

                DataTable dt = new DataTable();
                dt = ParametrosDAO.Retornar_parametros();

                if (dt.Rows.Count == 1)
                {
                    decimal tempo_registro = Convert.ToDecimal(dt.Rows[0]["tempo_registro"]);

                    if (tempo_registro == 1)
                    {
                        Controla_Checks(Chk_1minuto);
                    }
                    else if (tempo_registro == 30)
                    {
                        Controla_Checks(Chk_30minutos);
                    }
                    else if (tempo_registro == 60)
                    {
                        Controla_Checks(Chk_1hora);
                    }
                    else if (tempo_registro == 180)
                    {
                        Controla_Checks(Chk_3horas);
                    }

                    //txt_vazao.Text = dt.Rows[0]["vazao_bomba"].ToString().Replace(",",".");
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

        private void TelaParametros_Load(object sender, EventArgs e)
        {
            carrega_dados();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            carrega_dados();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                String pasta = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                System.Diagnostics.Process.Start(pasta + "\\Manuais\\tela_parametros.pdf");
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
