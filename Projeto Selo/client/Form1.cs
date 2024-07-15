using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Net.WebSockets;
using System.Net.Sockets;
using Microsoft.Win32;


namespace client
{
    public partial class teste : Form
    {

        private ClientWebSocket _webSocket;
        private TextBox enderecoIPTextBox;
        private System.Windows.Forms.TextBox caminhoExecutar;
        private Agente agente;

        public teste()
        {
            var registros = new RegistrarInformacoes();
            agente = new Agente(this);


            _webSocket = new ClientWebSocket();
            InitializeComponent();

            RegistryKey chaveRegistro = Registry.CurrentUser.OpenSubKey("Software\\Iseelo\\informações", true);

            if (chaveRegistro != null)
            {
                string ip = (string)chaveRegistro.GetValue("IP");
                string caminho = (string)chaveRegistro.GetValue("LocalExecucao");
                IniciarWebSocket(ip);

                enderecoIPTextBox.Text = ip;
                caminhoExecutar.Text = caminho;
            }
            else
            {
                registros.CriarRegistros();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.WindowState == FormWindowState.Minimized)
            {
                agente.Minimizar();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            agente.Remover();
        }


        private async void IniciarWebSocket(string ip)
        {
            string serverIP = "ws://" + ip + ":3051/Chat";

            Uri serverUri = new Uri(serverIP);

            try
            {
                await _webSocket.ConnectAsync(serverUri, CancellationToken.None);
                informativoLabel.Text = "Conectado ao servidor WebSocket!";
                ReceberMensagem();

                var bytes = Encoding.UTF8.GetBytes("v");
                await _webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
            }
            catch (Exception ex)
            {
                informativoLabel.Text = $"Erro: verifique o IP informado.";
            }
        }
        private async void ReceberMensagem()
        {
            var buffer = new byte[1024];

            try
            {
                while (_webSocket.State == WebSocketState.Open)
                {
                    var result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);

                    switch (message)
                    {
                        case "s":
                            desaAtivado.Text = "Ativado";
                            desaAtivado.BackColor = Color.Green;

                            painelSelo.BackColor = Color.Green;
                            painel2.BackColor = Color.Green;
                            break;

                        case "n":
                            desaAtivado.Text = "Desativado";
                            desaAtivado.BackColor = Color.Red;
                            painelSelo.BackColor = Color.Red;
                            painel2.BackColor = Color.Red;
                            break;

                        case "e1":
                            MessageBox.Show("Software executado");
                            break;

                        case "e0":
                            MessageBox.Show("Software não foi executado");
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                informativoLabel.Text = $"Erro ao receber mensagens: {ex.Message}";
            }
        }
        private async void botaoVerificar_Click(object sender, EventArgs e)
        {
            string enderecoIP = enderecoIPTextBox.Text;

            var registros = new RegistrarInformacoes();
            RegistryKey chaveRegistro = Registry.CurrentUser.OpenSubKey("Iseelo\\informações");

            if (chaveRegistro == null)
            {
                registros.SalvarIP(enderecoIPTextBox.Text);
            }

            if (_webSocket.State == WebSocketState.Open)
            {
                var message = "v";
                var bytes = Encoding.UTF8.GetBytes(message);

                try
                {
                    await _webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
                    informativoLabel.Text = "Mensagem 'v' enviada!";
                }
                catch (Exception ex)
                {
                    informativoLabel.Text = $"Erro ao enviar mensagem: {ex.Message}";
                }
            }
            else
            {
                IniciarWebSocket(enderecoIP);
            }
        }
        private async void botaoExecutar_Click(object sender, EventArgs e)
        {
            string enderecoIP = enderecoIPTextBox.Text;

            string caminho = caminhoExecutar.Text;

            var registros = new RegistrarInformacoes();
            RegistryKey chaveRegistro = Registry.CurrentUser.OpenSubKey("Iseelo\\informações");

            if (chaveRegistro == null)
            {
                registros.SalvarExecucao(caminhoExecutar.Text);
            }

            if (_webSocket.State == WebSocketState.Open)
            {
                var bytesCaminho = Encoding.UTF8.GetBytes(caminho);
                try
                {
                    await _webSocket.SendAsync(new ArraySegment<byte>(bytesCaminho), WebSocketMessageType.Text, true, CancellationToken.None);
                    informativoLabel.Text = "Mensagem do caminho enviada!";
                }
                catch (Exception ex)
                {
                    informativoLabel.Text = $"Erro ao enviar mensagem: {ex.Message}";
                }
            }
            else
            {
                IniciarWebSocket(enderecoIP);
            }
        }
    }
}




