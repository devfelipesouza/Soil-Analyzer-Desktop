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
    public partial class UC_Configuracoes : UserControl
    {
        public UC_Configuracoes()
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
                if (Application.OpenForms["TelaParametros"] == null)
                {
                    TelaParametros TelaParametros = new TelaParametros();
                    TelaParametros.Show();
                }
                else
                {
                    Application.OpenForms["TelaParametros"].BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
