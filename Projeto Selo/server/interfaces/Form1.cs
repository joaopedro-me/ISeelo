using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace interfaces
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Label informativoLabel;
        private Agente agente;

        public Form1()
        {
            var networkInterface = NetworkInterface.GetAllNetworkInterfaces()
           .FirstOrDefault(
               ni => ni.OperationalStatus == OperationalStatus.Up
                  && ni.NetworkInterfaceType != NetworkInterfaceType.Loopback
                  && ni.GetIPProperties().GatewayAddresses.Any()
           );


            var ipServer = networkInterface?.GetIPProperties()?.UnicastAddresses
            .FirstOrDefault(ip => ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?.Address;

            InitializeComponent();

            string ipString = ipServer.ToString();

            ServerWebSocket.Iniciar(ipString);
            agente = new Agente(this);

            informativoLabel.Text = $"Servidor inicializado...\nIP: {ipString}\nporta: 3051";
        }


        public static class ServerWebSocket
        {
            public static void Iniciar(string ip)
            {
                var server = new WebSocketServer(IPAddress.Parse(ip), 3051);
                server.AddWebSocketService<Chat>("/Chat");
                server.Start();
            }
        }

    }
    public static class Selo
    {

        public static string VerificarStatus()
        {
            Process[] processos = Process.GetProcessesByName("selodigital");

            foreach (Process process in processos)
            {
                if (!string.IsNullOrEmpty(process.MainWindowTitle))
                {
                    return "n";
                }
                else
                    return "s";
            }

            return "n";
        }

        public static void Executar(string caminho)
        {
            Process process = new Process();
            string verificar = Selo.VerificarStatus();

            if (verificar == "n")
            {

                process.StartInfo.FileName = caminho;

                process.StartInfo.Arguments = "AUTOEXEC=11";

                process.Start();

                process.WaitForExit();
                int exitCode = process.ExitCode;
            }
        }
    }


    public class Chat : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            switch (e.Data)
            {
                case "v":
                    string status = Selo.VerificarStatus();
                    Send(status);
                    break;

                default:
                    Selo.Executar(e.Data);
                    break;
            }
        }
    }

}






