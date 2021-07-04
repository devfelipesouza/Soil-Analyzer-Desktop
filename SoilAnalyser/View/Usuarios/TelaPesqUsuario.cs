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
    public partial class TelaPesqUsuario : Form
    {
        UsuarioDAO UsuarioDAO = new UsuarioDAO();

        int indice_coluna = 0; //Usando na pesquisa, define qual coluna será pesquisada.
        public string codioRetorno { get; set; }

        public TelaPesqUsuario()
        {
            try
            {
                InitializeComponent();

                dgv_usuarios.DataSource = UsuarioDAO.Retornar_pesquisa_usuarios();

                dgv_usuarios.Columns[0].HeaderText = "Usuário";
                dgv_usuarios.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgv_usuarios.Columns[1].HeaderText = "Nome";
                dgv_usuarios.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgv_usuarios.Columns[2].HeaderText = "Código";
                dgv_usuarios.Columns[2].Width = 80;

                //Sempre inicia com a coluna indice 0 selecionada para pesquisa (Negrito)
                dgv_usuarios.Columns[0].HeaderCell.Style.Font = new Font(DefaultFont, FontStyle.Bold);

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

        private void txt_pesquisa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgv_usuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                foreach (DataGridViewRow row in dgv_usuarios.Rows)
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

        private void dgv_usuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {

                    DataGridViewRow row = this.dgv_usuarios.Rows[e.RowIndex];
                    codioRetorno = row.Cells["id_usuario"].Value.ToString();
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

        private void dgv_usuarios_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                for (int i = 0; i < dgv_usuarios.Columns.Count; i++)
                {
                    if (e.ColumnIndex == i)
                    {
                        dgv_usuarios.Columns[i].HeaderCell.Style.Font = new Font(DefaultFont, FontStyle.Bold);
                    }
                    else
                    {
                        dgv_usuarios.Columns[i].HeaderCell.Style.Font = new Font(DefaultFont, FontStyle.Regular);
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

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
