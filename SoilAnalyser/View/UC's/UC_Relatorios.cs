using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoilAnalyser
{
    public partial class UC_Relatorios : UserControl
    {
        public UC_Relatorios()
        {
            InitializeComponent();

            label8.Parent = pictureBox1;
            bunifuImageButton1.Parent = pictureBox1;
            label1.Parent = pictureBox1;
            bunifuImageButton2.Parent = pictureBox1;
            label2.Parent = pictureBox1;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["Rel_Medicoes_Parametros"] == null)
                {
                    Rel_Medicoes_Parametros Rel_Medicoes_Parametros = new Rel_Medicoes_Parametros();
                    Rel_Medicoes_Parametros.Show();

                }
                else
                {
                    Application.OpenForms["Rel_Medicoes_Parametros"].BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["Rel_Irrigacoes_Parametros"] == null)
                {
                    Rel_Irrigacoes_Parametros Rel_Irrigacoes_Parametros = new Rel_Irrigacoes_Parametros();
                    Rel_Irrigacoes_Parametros.Show();

                }
                else
                {
                    Application.OpenForms["Rel_Irrigacoes_Parametros"].BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
