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
    public partial class TelaUsuario : Form
    {
        UsuarioDAO UsuarioDAO = new UsuarioDAO();

        public TelaUsuario()
        {
            InitializeComponent();
            desabilita_componentes();
        }

        private void desabilita_componentes()
        {
            try
            {
                txt_usuario.Enabled = false;
                txt_senha1.Enabled = false;
                txt_senha2.Enabled = false;
                txt_nome.Enabled = false;
                ckb_adm.Enabled = false;
                ckb_ativo.Enabled = false;
                ckb_mostrasenhas.Enabled = false;
                btn_gravar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_excluir.Enabled = false;
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
                txt_usuario.Enabled = true;
                txt_senha1.Enabled = true;
                txt_senha2.Enabled = true;
                txt_nome.Enabled = true;
                ckb_adm.Enabled = true;
                ckb_ativo.Enabled = true;
                ckb_mostrasenhas.Enabled = true;
                btn_gravar.Enabled = true;
                btn_cancelar.Enabled = true;
                btn_excluir.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void limpa_campos()
        {
            try
            {
                txt_usuario.Clear();
                txt_senha1.Clear();
                txt_senha2.Clear();
                txt_nome.Clear();
                txt_codigo.Clear();
                ckb_adm.Checked = false;
                ckb_ativo.Checked = false;
                ckb_mostrasenhas.Checked = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        bool valida_email(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void TelaUsuario_KeyDown(object sender, KeyEventArgs e)
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
                ckb_ativo.Checked = true;
                btn_gravar.Text = "Gravar";

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
                if (String.IsNullOrEmpty(txt_nome.Text))
                {
                    MessageBox.Show("Informe o nome do usuário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_nome.Focus();

                    return;
                }


                if (String.IsNullOrWhiteSpace(txt_usuario.Text))
                {
                    MessageBox.Show("Informe o usuário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_usuario.Focus();

                    return;
                }


                if (String.IsNullOrWhiteSpace(txt_senha1.Text))
                {
                    MessageBox.Show("Informe a senha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_senha1.Focus();

                    return;
                }

                if (String.IsNullOrWhiteSpace(txt_senha2.Text))
                {
                    MessageBox.Show("Confirme a senha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_senha2.Focus();

                    return;
                }

                if (!String.Equals(txt_senha1.Text, txt_senha2.Text))
                {
                    MessageBox.Show("As senhas digitadas estão diferentes, verifique.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_senha2.Focus();

                    return;
                }


                if (btn_gravar.Text.Equals("Gravar"))
                {

                    DataTable dt = new DataTable();

                    dt = UsuarioDAO.Retornar_usuario(txt_usuario.Text);

                    if (dt.Rows.Count >= 1)
                    {
                        MessageBox.Show("Já existe um cadastro com este de usuário. [" + txt_usuario.Text + "]", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_usuario.Focus();

                        return;
                    }

                    //insere o usuário no DB
                    UsuarioDAO.Inserir_usuario(txt_nome.Text, txt_usuario.Text, txt_senha1.Text, ckb_adm.Checked, ckb_ativo.Checked);

                    MessageBox.Show("Cadastro realizado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpa_campos();
                    desabilita_componentes();
                    btn_novo.Enabled = true;
                    txt_pesquisa.Focus();

                }
                else if (btn_gravar.Text.Equals("Atualizar"))
                {
                    DataTable dt = new DataTable();

                    dt = UsuarioDAO.Retornar_usuario(txt_usuario.Text);

                    if (dt.Rows.Count >= 1 && (!dt.Rows[0]["id_usuario"].ToString().Equals(txt_codigo.Text)))
                    {
                        MessageBox.Show("Já existe um cadastro com este de usuário. [" + txt_usuario.Text + "]", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_usuario.Focus();

                        return;
                    }

                    //atualiza o usuário no DB
                    UsuarioDAO.Atualizar_usuario(txt_nome.Text, txt_usuario.Text, txt_senha1.Text, ckb_adm.Checked, ckb_ativo.Checked, txt_codigo.Text);

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

        private void ckb_mostrasenhas_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txt_senha1.PasswordChar = ckb_mostrasenhas.Checked ? '\0' : '*';
                txt_senha2.PasswordChar = ckb_mostrasenhas.Checked ? '\0' : '*';
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

        private void txt_pesquisa_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(txt_pesquisa.Text))
                {
                    DataTable dt = new DataTable();
                    dt = UsuarioDAO.Retornar_usuario_porID(txt_pesquisa.Text);

                    if (dt.Rows.Count == 1)
                    {
                        txt_codigo.Text = dt.Rows[0]["id_usuario"].ToString();
                        txt_nome.Text = dt.Rows[0]["nome"].ToString();
                        txt_usuario.Text = dt.Rows[0]["usuario"].ToString();
                        txt_senha1.Text = dt.Rows[0]["senha"].ToString();
                        txt_senha2.Text = dt.Rows[0]["senha"].ToString();
                        ckb_ativo.Checked = Convert.ToBoolean(dt.Rows[0]["ativo"].ToString());
                        ckb_adm.Checked = Convert.ToBoolean(dt.Rows[0]["admin"].ToString());

                        txt_pesquisa.Clear();
                        habilita_componentes();
                        btn_gravar.Text = "Atualizar";

                        if (txt_usuario.Text.ToUpper().Equals("ADMIN"))
                        {
                            ckb_adm.Enabled = false;
                            ckb_ativo.Enabled = false;
                            txt_usuario.ReadOnly = true;
                        }
                        else
                        {
                            ckb_adm.Enabled = true;
                            ckb_ativo.Enabled = true;
                            txt_usuario.ReadOnly = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuário não localizado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (MessageBox.Show("Confirma a exclusão deste usuário?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Exclui usuário
                    UsuarioDAO.Exclui_usuario(txt_codigo.Text);

                    MessageBox.Show("Usuário excluído com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_filtro_Click(object sender, EventArgs e)
        {
            try
            {
                //Instancia o form de pesquisa
                TelaPesqUsuario pesquisa_usuarios = new TelaPesqUsuario();
                pesquisa_usuarios.Owner = this;

                // no clique do botão de filtro(lupinha) abre o form de pesquisa.
                pesquisa_usuarios.ShowDialog();

                // Campo pesquisa recebe o código de retorno da pesquisa
                this.txt_pesquisa.Text = pesquisa_usuarios.codioRetorno;

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

        private void bunifuImageButton3_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                String pasta = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                System.Diagnostics.Process.Start(pasta + "\\Manuais\\cadastro_usuario.pdf");
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
