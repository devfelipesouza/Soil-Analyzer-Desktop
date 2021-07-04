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
    public partial class UC_Ajuda : UserControl
    {
        public UC_Ajuda()
        {
            InitializeComponent();

            label8.Parent = pictureBox1;
            bunifuImageButton1.Parent = pictureBox1;
            label1.Parent = pictureBox1;
        }

    }
}
