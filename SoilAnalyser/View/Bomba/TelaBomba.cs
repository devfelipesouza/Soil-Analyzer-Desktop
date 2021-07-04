using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoilAnalyser
{
    public partial class TelaBomba : Form
    {
        BombaDAO BombaDAO = new BombaDAO();
        public TelaBomba()
        {
            InitializeComponent();
            desabilita_componentes();
        }

        private void limpa_campos()
        {
            try
            {
                txt_codigo.Clear();
                txt_descricao.Clear();
                txt_vazao.Clear();

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

        private void desabilita_componentes()
        {
            try
            {
                txt_descricao.Enabled = false;
                txt_vazao.Enabled = false;
                btn_gravar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_excluir.Enabled = false;

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

        private void habilita_componentes()
        {
            try
            {
                txt_descricao.Enabled = true;
                txt_vazao.Enabled = true;
                btn_gravar.Enabled = true;
                btn_cancelar.Enabled = true;
                btn_excluir.Enabled = true;

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


        private void bloqueia_numero(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Se a tecla digitada não for numérica
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                {

                    e.Handled = true;
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

        private void btn_fecha_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimiza_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txt_pesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloqueia_numero(txt_pesquisa, e);
        }

        private void txt_vazao_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloqueia_numero(txt_vazao, e);
        }

        private void TelaBomba_KeyDown(object sender, KeyEventArgs e)
        {
            //indica que é para mudar para o próximo campo se pressionado ENTER
            //e ir para o campo anterior se pressionados SHIFT e ENTER simultaneamente
            //(o mesmo funcionamento do SHIFT + TAB). 
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                limpa_campos();
                desabilita_componentes();
                btn_novo.Enabled = true;
                btn_gravar.Text = "Gravar";
                txt_pesquisa.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            try
            {
                limpa_campos();
                habilita_componentes();
                btn_novo.Enabled = false;
                btn_gravar.Text = "Gravar";
                txt_descricao.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txt_descricao.Text))
                {
                    MessageBox.Show("Informe a descrição da bomba.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_descricao.Focus();

                    return;
                }

                if (String.IsNullOrWhiteSpace(txt_vazao.Text))
                {
                    MessageBox.Show("Informe a vazão.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_vazao.Focus();

                    return;
                }

                if (btn_gravar.Text.Equals("Gravar"))
                {


                    //insere o registro no DB
                    BombaDAO.Inserir_bomba(txt_descricao.Text, txt_vazao.Text);

                    MessageBox.Show("Cadastro realizado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpa_campos();
                    desabilita_componentes();
                    btn_novo.Enabled = true;
                    txt_pesquisa.Focus();

                }
                else if (btn_gravar.Text.Equals("Atualizar"))
                {

                    //atualiza o registro no DB
                    BombaDAO.Atualizar_bomba(txt_descricao.Text, txt_vazao.Text, txt_codigo.Text);

                    MessageBox.Show("Cadastro atualizado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_pesquisa.Focus();
                    limpa_campos();
                    desabilita_componentes();
                    btn_novo.Enabled = true;

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

        private void txt_pesquisa_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(txt_pesquisa.Text))
                {
                    DataTable dt = new DataTable();
                    dt = BombaDAO.Retornar_bombas_porID(txt_pesquisa.Text);

                    if (dt.Rows.Count == 1)
                    {
                        txt_codigo.Text = dt.Rows[0]["id_bomba"].ToString();
                        txt_descricao.Text = dt.Rows[0]["descricao"].ToString();
                        txt_vazao.Text = dt.Rows[0]["vazao"].ToString();
                        txt_pesquisa.Clear();
                        habilita_componentes();
                        btn_gravar.Text = "Atualizar";
                    }
                    else
                    {
                        MessageBox.Show("Bomba não localizada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_pesquisa.Clear();
                        txt_pesquisa.Focus();
                        limpa_campos();
                        desabilita_componentes();
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

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma a exclusão desta bomba?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Exclui usuário
                    BombaDAO.Exclui_bomba(txt_codigo.Text);

                    MessageBox.Show("Bomba excluída com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpa_campos();
                    desabilita_componentes();
                    txt_pesquisa.Focus();

                    btn_novo.Enabled = true;
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                if (ex.Number == 1451) //ForeignKey
                {
                    MessageBox.Show("Não foi possível excluir, existem registros utilizando este cadastro. \n \n" + "Detalhes do erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_filtro_Click(object sender, EventArgs e)
        {
            try
            {
                //Instancia o form de pesquisa
                TelaPesqBomba TelaPesqBomba = new TelaPesqBomba();
                TelaPesqBomba.Owner = this;

                // no clique do botão de filtro(lupinha) abre o form de pesquisa.
                TelaPesqBomba.ShowDialog();

                // Campo pesquisa recebe o código de retorno da pesquisa
                this.txt_pesquisa.Text = TelaPesqBomba.codioRetorno;

                //chama propriedade leave do campo de pesquisa
                this.txt_pesquisa_Leave(null, null);
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

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                String pasta = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                System.Diagnostics.Process.Start(pasta + "\\Manuais\\cadastro_bomba.pdf");
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
