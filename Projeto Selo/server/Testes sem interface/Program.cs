using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Diagnostics;

namespace Server
{
    class Program
    {
        static async Task Main(string[] args)
        {

            ServerWebSocket.Iniciar();
            await Task.Delay(-1);
        }

        public static class ServerWebSocket
        {
            public static void Iniciar()
            {
                var server = new WebSocketServer(IPAddress.Parse("127.0.0.1"), 3051);
                server.AddWebSocketService<Chat>("/Chat");
                server.Start();
                Console.WriteLine("WebSocket server started at ws://127.0.0.1:3051/Chat");
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
                Console.WriteLine($"Processo encontrado: {process.ProcessName}, ID: {process.Id}");

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

                if (exitCode == 0)
                {
                    Console.WriteLine("Seu processo foi executado com sucesso.");
                }
            }
        }
    }


    public class Chat : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine($"Received message from {Context.UserEndPoint.Address}.");

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

