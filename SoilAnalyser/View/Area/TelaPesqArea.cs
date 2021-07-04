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
    public partial class TelaPesqArea : Form
    {
        int indice_coluna = 0; //Usando na pesquisa, define qual coluna será pesquisada.
        public string codioRetorno { get; set; }

        AreaDAO AreaDAO = new AreaDAO();

        public TelaPesqArea()
        {
            try
            {
                InitializeComponent();

                dgv_areas.DataSource = AreaDAO.Retornar_pesquisa_areas();

                dgv_areas.Columns[0].HeaderText = "Descrição";
                dgv_areas.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgv_areas.Columns[1].HeaderText = "Código";
                dgv_areas.Columns[1].Width = 80;
                dgv_areas.Columns[1].Visible = false;
                //dgv_areas inicia com a coluna indice 0 selecionada para pesquisa (Negrito)
                dgv_areas.Columns[0].HeaderCell.Style.Font = new Font(DefaultFont, FontStyle.Bold);
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

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_pesquisa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgv_areas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                foreach (DataGridViewRow row in dgv_areas.Rows)
                {
                    if (row.Cells[indice_coluna].Value.ToString().StartsWith(txt_pesquisa.Text))
                    {
                        row.Selected = true;
                        break;
                    }
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

        private void dgv_areas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {

                    DataGridViewRow row = this.dgv_areas.Rows[e.RowIndex];
                    codioRetorno = row.Cells["id_area"].Value.ToString();
                    this.Close();

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

        private void dgv_areas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                for (int i = 0; i < dgv_areas.Columns.Count; i++)
                {
                    if (e.ColumnIndex == i)
                    {
                        dgv_areas.Columns[i].HeaderCell.Style.Font = new Font(DefaultFont, FontStyle.Bold);
                    }
                    else
                    {
                        dgv_areas.Columns[i].HeaderCell.Style.Font = new Font(DefaultFont, FontStyle.Regular);
                    }
                }

                indice_coluna = e.ColumnIndex;
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
