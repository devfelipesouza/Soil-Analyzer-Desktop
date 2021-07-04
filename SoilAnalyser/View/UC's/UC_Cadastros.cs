using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SoilAnalyser
{
    public partial class UC_Cadastros : UserControl
    {
        public UC_Cadastros()
        {
            InitializeComponent();

            label8.Parent = pictureBox1;

            btn_usuarios.Parent = pictureBox1;
            lb_usuarios.Parent = pictureBox1;

            btn_areas.Parent = pictureBox1;
            lb_areas.Parent = pictureBox1;

            btn_bombas.Parent = pictureBox1;
            lb_bombas.Parent = pictureBox1;

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["TelaUsuario"] == null)
                {
                    TelaUsuario TelaUsuario = new TelaUsuario();
                    TelaUsuario.Show();
                    
                }
                else
                {
                    Application.OpenForms["TelaUsuario"].BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);              
            }
        }

        private void btn_areas_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["TelaArea"] == null)
                {
                    TelaArea TelaArea = new TelaArea();
                    TelaArea.Show();
                }
                else
                {
                    Application.OpenForms["TelaArea"].BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_bombas_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["TelaBomba"] == null)
                {
                    TelaBomba TelaBomba = new TelaBomba();
                    TelaBomba.Show();
                }
                else
                {
                    Application.OpenForms["TelaBomba"].BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
