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
    public partial class TelaCarregando : Form
    {
        DB DB = new DB();

        Boolean oculta_botoes;
        public TelaCarregando(Boolean admin)
        {
            InitializeComponent();

            oculta_botoes = !admin;
        }

        //Permite mover form            
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_LBUTTONDOWN)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {                
                ProgressBar.Value += 5;

                lb_percent.Text = ProgressBar.Value.ToString() + " %";

                if (ProgressBar.Value == 80)
                {
                    try
                    {
                        DB.testar_conexao();
                     
                    }
                    catch (Exception ex)
                    {
                        timer1.Stop();
                        MessageBox.Show("Não foi possível conectar ao banco de dados, verifique sua conexão. \n \n" + "Detalhes do erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                       
                        Application.Exit();
                    }
                   
                }

                if ((ProgressBar.Value == ProgressBar.MaximumValue))
                {
                    timer1.Stop();

                    TelaPrincipal telaPrincipal = new TelaPrincipal();
                    
                    if (oculta_botoes)
                    {
                        telaPrincipal.btn_cadastros.Visible = false;
                        telaPrincipal.btn_configuracoes.Visible = false;

                        telaPrincipal.btn_relatorios.Location = new Point(0, 33);
                        telaPrincipal.btn_graficos.Location = new Point(0, 83);
                        telaPrincipal.btn_ajuda.Location = new Point(0, 133);

                    }
                    else
                    {
                        telaPrincipal.btn_cadastros.Visible = true;
                        telaPrincipal.btn_configuracoes.Visible = true;
                    }

                    telaPrincipal.Show();
                    this.Hide();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
