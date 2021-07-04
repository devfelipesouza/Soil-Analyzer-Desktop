using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoilAnalyser
{
    public partial class Rel_Medicoes_View : Form
    {
        int vn_id_area;
        int vn_id_area_todos;
        string vv_data_ini;
        string vv_data_fim;

        public Rel_Medicoes_View(int P_ID_AREA, int P_ID_AREA_TODOS, string P_DATA_INI, string P_DATA_FIM)
        {
            InitializeComponent();

            vn_id_area = P_ID_AREA;
            vn_id_area_todos = P_ID_AREA_TODOS;
            vv_data_ini = P_DATA_INI;
            vv_data_fim = P_DATA_FIM;


        }

        private void Rel_Medicoes_View_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet_Medicoes.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.DataSet_Medicoes.DataTable1, vn_id_area, vn_id_area_todos, vv_data_ini, vv_data_fim);

            if (this.DataSet_Medicoes.DataTable1.Rows.Count <= 0)
            {
                MessageBox.Show("Nenhuma informação neste período.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }


            //this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.ZoomPercent = 100;
            this.reportViewer1.RefreshReport();
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
