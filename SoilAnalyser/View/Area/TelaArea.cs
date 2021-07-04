using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Packaging;
using System.Reflection;

namespace SoilAnalyser
{
    public partial class TelaArea : Form
    {
        AreaDAO AreaDAO = new AreaDAO();

        public TelaArea()
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
                txt_bomba.Clear();
                txt_desc_bomba.Clear();
                txt_seco.Clear();
                txt_ideal_menor.Clear();
                txt_ideal_maior.Clear();
                txt_umido.Clear();
                numUpDownUmidade.Value = 1;
                txt_end_ip.Clear();

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
                txt_bomba.Enabled = false;
                txt_desc_bomba.Enabled = false;
                txt_seco.Enabled = false;
                txt_ideal_menor.Enabled = false;
                txt_ideal_maior.Enabled = false;
                txt_umido.Enabled = false;
                btn_gravar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_excluir.Enabled = false;
                numUpDownUmidade.Enabled = false;
                txt_end_ip.Enabled = false;

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
                txt_bomba.Enabled = true;
                txt_desc_bomba.Enabled = true;
                txt_seco.Enabled = true;
                txt_ideal_menor.Enabled = true;
                txt_ideal_maior.Enabled = true;
                txt_umido.Enabled = true;
                btn_gravar.Enabled = true;
                btn_cancelar.Enabled = true;
                btn_excluir.Enabled = true;
                numUpDownUmidade.Enabled = true;
                txt_end_ip.Enabled = true;

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

        private void txt_pesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloqueia_numero(txt_pesquisa, e);
        }

        private void TelaArea_KeyDown(object sender, KeyEventArgs e)
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
                    MessageBox.Show("Informe a descrição da área.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_descricao.Focus();

                    return;
                }


                if (String.IsNullOrWhiteSpace(txt_bomba.Text))
                {
                    MessageBox.Show("Informe a bomba.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_bomba.Focus();

                    return;
                }

                if (String.IsNullOrWhiteSpace(txt_seco.Text))
                {
                    MessageBox.Show("Informe o nível de umidade seco.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_seco.Focus();

                    return;
                }
           
                if (String.IsNullOrWhiteSpace(txt_ideal_menor.Text))
                {
                    MessageBox.Show("Informe o nível mínimo de umidade ideal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_ideal_menor.Focus();

                    return;
                }

                if (Convert.ToInt32(txt_ideal_menor.Text) <= Convert.ToInt32(txt_seco.Text))
                {
                    MessageBox.Show("O nível mínimo da umidade ideal não pode ser menor ou igual ao nível seco.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_ideal_menor.Focus();

                    return;
                }

                if (String.IsNullOrWhiteSpace(txt_ideal_maior.Text))
                {
                    MessageBox.Show("Informe o nível máximo de umidade ideal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_ideal_menor.Focus();

                    return;
                }

                if (Convert.ToInt32(txt_ideal_maior.Text) < Convert.ToInt32(txt_ideal_menor.Text))
                {
                    MessageBox.Show("O nível máximo da umidade ideal não pode ser menor que o nível mínimo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_ideal_menor.Focus();

                    return;
                }

                if (String.IsNullOrWhiteSpace(txt_umido.Text))
                {
                    MessageBox.Show("Informe o nível de umidade umido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_umido.Focus();

                    return;
                }

                if (Convert.ToInt32(txt_umido.Text) <= Convert.ToInt32(txt_ideal_maior.Text))
                {
                    MessageBox.Show("O nível de umidade úmido não pode ser menor ou igual ao nível máximo de ideal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_ideal_menor.Focus();

                    return;
                }

                if (numUpDownUmidade.Value <= 0)
                {
                    MessageBox.Show("Informe código do sensor de úmidade.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    numUpDownUmidade.Focus();

                    return;
                }


                DataTable dt = new DataTable();

                dt = AreaDAO.Retornar_areas_por_IDSENSOR(numUpDownUmidade.Value);

                

                if (dt.Rows.Count >= 1 && !dt.Rows[0]["id_area"].ToString().Equals(txt_codigo.Text))
                {
                    MessageBox.Show("Já existe cadastro de uma área com este sensor de umidade.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    numUpDownUmidade.Focus();
                    return;
                }

                if (String.IsNullOrWhiteSpace(txt_end_ip.Text))
                {
                    MessageBox.Show("Informe o endereço de IP da Micro Controladora ligada nesta área.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_end_ip.Focus();
                    return;
                }

                if (btn_gravar.Text.Equals("Gravar"))
                {

                
                    //insere o registro no DB
                    AreaDAO.Inserir_area(txt_descricao.Text, txt_bomba.Text, numUpDownUmidade.Text, txt_seco.Text, txt_ideal_menor.Text, txt_ideal_maior.Text, txt_umido.Text, txt_end_ip.AccessibilityObject.Value.Replace(',', '.'));

                    MessageBox.Show("Cadastro realizado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpa_campos();
                    desabilita_componentes();
                    btn_novo.Enabled = true;
                    txt_pesquisa.Focus();

                }
                else if (btn_gravar.Text.Equals("Atualizar"))
                {

                    //atualiza o registro no DB
                    AreaDAO.Atualizar_area(txt_descricao.Text, txt_bomba.Text, numUpDownUmidade.Text, txt_seco.Text, txt_ideal_menor.Text, txt_ideal_maior.Text, txt_umido.Text, txt_end_ip.AccessibilityObject.Value.Replace(',', '.'), txt_codigo.Text);

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
                    dt = AreaDAO.Retornar_areas_porID(txt_pesquisa.Text);

                    if (dt.Rows.Count == 1)
                    {
                        txt_codigo.Text = dt.Rows[0]["id_area"].ToString();
                        txt_descricao.Text = dt.Rows[0]["descricao"].ToString();
                        txt_bomba.Text = dt.Rows[0]["id_bomba"].ToString();
                        this.txt_bomba_Leave(null, null);
                        
                        txt_seco.Text = dt.Rows[0]["seco"].ToString();
                        txt_ideal_menor.Text = dt.Rows[0]["ideal_menor"].ToString();
                        txt_ideal_maior.Text = dt.Rows[0]["ideal_maior"].ToString();
                        txt_umido.Text = dt.Rows[0]["umido"].ToString();
                        numUpDownUmidade.Value = Convert.ToInt32(dt.Rows[0]["id_sensor"].ToString());
                        txt_end_ip.Text = dt.Rows[0]["ip"].ToString();

                        txt_pesquisa.Clear();
                        habilita_componentes();
                        btn_gravar.Text = "Atualizar";
                    }
                    else
                    {
                        MessageBox.Show("Área não localizada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (MessageBox.Show("Confirma a exclusão desta área?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Exclui usuário
                    AreaDAO.Exclui_area(txt_codigo.Text);

                    MessageBox.Show("Área excluída com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpa_campos();
                    desabilita_componentes();
                    txt_pesquisa.Focus();

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

        private void btn_minimiza_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_fecha_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_filtro_Click(object sender, EventArgs e)
        {
            try
            {
                //Instancia o form de pesquisa
                TelaPesqArea TelaPesqArea = new TelaPesqArea();
                TelaPesqArea.Owner = this;

                // no clique do botão de filtro(lupinha) abre o form de pesquisa.
                TelaPesqArea.ShowDialog();

                // Campo pesquisa recebe o código de retorno da pesquisa
                this.txt_pesquisa.Text = TelaPesqArea.codioRetorno;

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

        private void txt_bomba_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloqueia_numero(txt_bomba, e);
        }

        private void txt_seco_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloqueia_numero(txt_seco, e);
        }

        private void txt_ideal_menor_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloqueia_numero(txt_ideal_menor, e);            
        }

        private void txt_ideal_maior_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloqueia_numero(txt_ideal_maior, e);
        }

        private void txt_umido_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloqueia_numero(txt_umido, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Instancia o form de pesquisa
                TelaPesqBomba TelaPesqBomba = new TelaPesqBomba();
                TelaPesqBomba.Owner = this;

                // no clique do botão de filtro(lupinha) abre o form de pesquisa.
                TelaPesqBomba.ShowDialog();

                
                if (!String.IsNullOrEmpty(TelaPesqBomba.codioRetorno))
                {
                    // Campo pesquisa recebe o código de retorno da pesquisa
                    this.txt_bomba.Text = TelaPesqBomba.codioRetorno;

                    //chama propriedade leave do campo de pesquisa
                    this.txt_bomba_Leave(null, null);
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

        private void txt_bomba_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(txt_bomba.Text))
                {
                    BombaDAO BombaDAO = new BombaDAO();
                    DataTable dt = new DataTable();
                    dt = BombaDAO.Retornar_bombas_porID(txt_bomba.Text);

                    if (dt.Rows.Count == 1)
                    {
                        txt_bomba.Text = dt.Rows[0]["id_bomba"].ToString();
                        txt_desc_bomba.Text = dt.Rows[0]["descricao"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Bomba não localizada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_bomba.Clear();
                        txt_bomba.Focus();
                    }
                }
                else
                {
                    txt_desc_bomba.Clear();
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

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {            
            try
            {
                String pasta = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                System.Diagnostics.Process.Start(pasta+ "\\Manuais\\cadastro_area.pdf");
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
