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
    public partial class TelaPesqBomba : Form
    {
        int indice_coluna = 0; //Usando na pesquisa, define qual coluna será pesquisada.
        public string codioRetorno { get; set; }

        BombaDAO BombaDAO = new BombaDAO();

        public TelaPesqBomba()
        {
            try
            {
                InitializeComponent();

                dgv_bombas.DataSource = BombaDAO.Retornar_pesquisa_bombas();

                dgv_bombas.Columns[0].HeaderText = "Descrição";
                dgv_bombas.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgv_bombas.Columns[1].HeaderText = "Código";
                dgv_bombas.Columns[1].Width = 80;

                //dgv_areas inicia com a coluna indice 0 selecionada para pesquisa (Negrito)
                dgv_bombas.Columns[0].HeaderCell.Style.Font = new Font(DefaultFont, FontStyle.Bold);
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
                dgv_bombas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                foreach (DataGridViewRow row in dgv_bombas.Rows)
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

        private void dgv_bombas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex >= 0)
                {

                    DataGridViewRow row = this.dgv_bombas.Rows[e.RowIndex];
                    codioRetorno = row.Cells["id_bomba"].Value.ToString();
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


        private void dgv_bombas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                for (int i = 0; i < dgv_bombas.Columns.Count; i++)
                {
                    if (e.ColumnIndex == i)
                    {
                        dgv_bombas.Columns[i].HeaderCell.Style.Font = new Font(DefaultFont, FontStyle.Bold);
                    }
                    else
                    {
                        dgv_bombas.Columns[i].HeaderCell.Style.Font = new Font(DefaultFont, FontStyle.Regular);
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
