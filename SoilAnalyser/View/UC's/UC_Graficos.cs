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
    public partial class UC_Graficos : UserControl
    {
        public UC_Graficos()
        {
            InitializeComponent();

            label8.Parent = pictureBox1;
            bunifuImageButton1.Parent = pictureBox1;
            label1.Parent = pictureBox1;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["ConsultaUmidade"] == null)
                {
                    ConsultaUmidade ConsultaUmidade = new ConsultaUmidade();
                    ConsultaUmidade.Show();
                }
                else
                {
                    Application.OpenForms["ConsultaUmidade"].BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
