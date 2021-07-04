using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace SoilAnalyser
{
    public partial class TelaLogin : Form
    {
        UsuarioDAO UsuarioDAO = new UsuarioDAO();
        public TelaLogin()
        {
            InitializeComponent();

            //Marca d'água nos campos.
            List<TextBox> tList = new List<TextBox>();
            List<string> sList = new List<string>();
            tList.Add(txtUsuario);
            sList.Add("Usuário");
            tList.Add(txtSenha);
            sList.Add("Senha");
            SetCueBanner(ref tList, sList);
        }

        protected ToolTip Balloon = new ToolTip();
        protected delegate void ExeBallon(Control Control, bool Show);
        protected event ExeBallon ExeShowBallon;
        protected int Salto;

        //Marca d'água nos campos.
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr i, string str);

        void SetCueBanner(ref List<TextBox> textBox, List<string> CueText)
        {
            for (int x = 0; x < textBox.Count; x++)
            {
                SendMessage(textBox[x].Handle, 0x1501, (IntPtr)1, CueText[x]);
            }
        }

        //Mensagem Caps Lock ativado - início.
        private void Form1_Load(object sender, EventArgs e)
        {
            ExeShowBallon += Form1_ExeShowBallon;
            Salto = 0;
        }

        void Form1_ExeShowBallon(Control Control, bool Show)
        {
            if (Show && Salto == 0)
            {
                Balloon.InitialDelay = 0;
                Balloon.IsBalloon = true;
                Balloon.ShowAlways = true;
                Balloon.ToolTipIcon = ToolTipIcon.Warning;
                Balloon.UseFading = false;
                Balloon.ToolTipTitle = "Informação ...";
                Balloon.Show("Caps Lock Habilitado", this, Control.Location.X + Control.Width + 5, Control.Location.Y - 30);
                Salto = 1;
            }
            else if (!Show && Salto == 1)
            {
                Balloon.Hide(this);
                Balloon.InitialDelay = 0;
                Salto = 0;
            }
        }

        //Permite mover form            
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_LBUTTONDOWN)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        private void btnAcessar_Click(object sender, EventArgs e)
        {
            Logar();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Logar();
            }
        }

        private void Logar()
        {
            try
            {

                if (String.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    MessageBox.Show("Informe o usuário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (String.IsNullOrWhiteSpace(txtSenha.Text))
                {
                    MessageBox.Show("Informe o senha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DataTable dt = new DataTable();
                dt = UsuarioDAO.Retornar_usuario(txtUsuario.Text);

                if (dt.Rows.Count > 0)
                {
                    String usuario = dt.Rows[0]["usuario"].ToString();
                    String senha = dt.Rows[0]["senha"].ToString();
                    Boolean admin = Convert.ToBoolean(dt.Rows[0]["admin"].ToString());

                    if (usuario.Equals(txtUsuario.Text) && senha.Equals(txtSenha.Text))
                    {
                        TelaCarregando TelaCarregando = new TelaCarregando(admin);
                        TelaCarregando.Owner = this;
                        TelaCarregando.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou Senha Inválidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                
                if (ex.Number == 1042 || ex.Number == 0) //Falha de conexão
                {
                    MessageBox.Show("Não foi possível conectar ao banco de dados, verifique sua conexão. \n \n" + "Detalhes do erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }


}
