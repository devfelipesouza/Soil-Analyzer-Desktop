using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoilAnalyser
{
    public partial class TelaCarregandoConsultaUmidade : Form
    {
        const int PORT_NO = 80;
        string SERVER_IP = "";
        public int umidade;

        String id_area;
        private Thread _backgroundWorkerThread;

        public TelaCarregandoConsultaUmidade(String P_ID_AREA)
        {
            InitializeComponent();
            //Guarda parâmetro do id_area
            id_area = P_ID_AREA;
        }

        private string carrega_percentual(String PN_ID_AREA)
        {
                //Retorna endereço de IP
                AreaDAO AreaDAO = new AreaDAO();

                DataTable dt = new DataTable();
                dt = AreaDAO.retornar_IP_Area(PN_ID_AREA);

                if (dt.Rows.Count == 1)
                {
                    SERVER_IP = dt.Rows[0]["ip"].ToString();
                }

                //Inicia conexão com IP da área selecionada
                var client = new TcpClient();
                var result = client.BeginConnect(SERVER_IP, PORT_NO, null, null);

                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(15));
                
                //Caso não consiga conectar em 15 segundos, registra uma exception
                if (!success)
                {
                    throw new Exception("Falha ao coletar dados, verifique sua conexão.");
                }

                
                NetworkStream nwStream = client.GetStream();

                //Lê os dados do webserver
                byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);

                //converte para string
                string umidade = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);

                //encerra a conexão
                client.EndConnect(result);

                //fecha o cliente
                client.Close();

                //Chama o garbage collection
                GC.Collect();

                return umidade;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {   //Aborta bgWorker
            AbortBackgroundWorker();
        }

        private void TelaCarregandoConsultaUmidade_Shown(object sender, EventArgs e)
        {   //Starta bgWorker
            backgroundWorker1.RunWorkerAsync();

        }
        

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {   //Fecha tela quando concluir bgWorker
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {   //guarda a tarefa atual
                _backgroundWorkerThread = Thread.CurrentThread;

                //retorna umidade em variavel publica.
                umidade = Convert.ToInt32(carrega_percentual(id_area));
            }
            catch (ThreadAbortException)
            {
               
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void StartBackgroundWorker()
        {

            try
            {  //Inicia método de start bgWorker
                BackgroundWorker backgroundWorker = new BackgroundWorker();

                backgroundWorker.RunWorkerAsync();

            }
            catch (ThreadAbortException)
            {

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Erro: " + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void AbortBackgroundWorker()
        {
            //Método de stop bgWorker
            if (_backgroundWorkerThread != null)
            {
                _backgroundWorkerThread.Abort();
               
                ConsultaUmidade ConsultaUmidade = new ConsultaUmidade();
                umidade = 0;
                this.Close();
            }
                
        }
    }
}
