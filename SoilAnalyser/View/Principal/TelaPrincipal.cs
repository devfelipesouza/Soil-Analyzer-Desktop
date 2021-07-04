using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SoilAnalyser
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }



        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (slidePane.Width == 38)
                {
                    slidePane.Visible = false;
                    slidePane.Width = 189;
                    PanelAnimator.ShowSync(slidePane);
                    //logoAnimator.ShowSync(largeLogo);
                }
                else
                {
                    //logoAnimator.Hide(largeLogo);
                    slidePane.Visible = false;
                    slidePane.Width = 38;
                    PanelAnimator.ShowSync(slidePane);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_cadastros_Click(object sender, EventArgs e)
        {
            try
            {

                uC_Irrigacoes1.Visible = false;
                uC_Relatorios1.Visible = false;
                uC_Graficos1.Visible = false;
                uC_Configuracoes1.Visible = false;
                uC_Ajuda1.Visible = false;

                if (uC_Cadastros1.Visible)
                {
                    uC_Cadastros1.Visible = false;                   
                }
                else
                {                    
                    AnimatorMenus.ShowSync(uC_Cadastros1);
                    uC_Cadastros1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btn_controles_Click(object sender, EventArgs e)
        {
            try
            {
                uC_Cadastros1.Visible = false;
                uC_Relatorios1.Visible = false;
                uC_Graficos1.Visible = false;
                uC_Configuracoes1.Visible = false;
                uC_Ajuda1.Visible = false;

                if (uC_Irrigacoes1.Visible)
                {
                    uC_Irrigacoes1.Visible = false;
                }
                else
                {
                    AnimatorMenus.ShowSync(uC_Irrigacoes1);
                    uC_Irrigacoes1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_relatorios_Click(object sender, EventArgs e)
        {
            try
            {
                uC_Cadastros1.Visible = false;
                uC_Irrigacoes1.Visible = false;
                uC_Graficos1.Visible = false;
                uC_Configuracoes1.Visible = false;
                uC_Ajuda1.Visible = false;

                if (uC_Relatorios1.Visible)
                {
                    uC_Relatorios1.Visible = false;
                }
                else
                {
                    AnimatorMenus.ShowSync(uC_Relatorios1);
                    uC_Relatorios1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_graficos_Click(object sender, EventArgs e)
        {
            try
            {
                uC_Cadastros1.Visible = false;
                uC_Irrigacoes1.Visible = false;
                uC_Relatorios1.Visible = false;
                uC_Configuracoes1.Visible = false;
                uC_Ajuda1.Visible = false;

                if (uC_Graficos1.Visible)
                {
                    uC_Graficos1.Visible = false;
                }
                else
                {
                    AnimatorMenus.ShowSync(uC_Graficos1);
                    uC_Graficos1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_configuracoes_Click(object sender, EventArgs e)
        {
            try
            {
                uC_Cadastros1.Visible = false;
                uC_Irrigacoes1.Visible = false;
                uC_Relatorios1.Visible = false;
                uC_Graficos1.Visible = false;
                uC_Ajuda1.Visible = false;

                if (uC_Configuracoes1.Visible)
                {
                    uC_Configuracoes1.Visible = false;
                }
                else
                {
                    AnimatorMenus.ShowSync(uC_Configuracoes1);
                    uC_Configuracoes1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_ajuda_Click(object sender, EventArgs e)
        {
            try
            {
                uC_Cadastros1.Visible = false;
                uC_Irrigacoes1.Visible = false;
                uC_Relatorios1.Visible = false;
                uC_Graficos1.Visible = false;
                uC_Configuracoes1.Visible = false;

                if (uC_Ajuda1.Visible)
                {
                    uC_Ajuda1.Visible = false;
                }
                else
                {
                    AnimatorMenus.ShowSync(uC_Ajuda1);
                    uC_Ajuda1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TelaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
