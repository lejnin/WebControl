using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WebControlApplication
{
    class Server
    {
        private const int TIMEOUT = 8; // Лиммт времени на приём данных.

        private bool running = false; //Запущено ли?

        private Controller controller;
        private readonly GeneralForm form; // доступ к нашей форме
        private readonly Encoding charEncoder = Encoding.UTF8; // Кодировка
        private Socket serverSocket; // Нащ сокет

        public Server(GeneralForm form)
        {
            this.form = form;
        }

        public bool Start(IPAddress ipAddress = null, int port = 0, int maxNOfCon = 5)
        {
            if (running)
            {
                form.Log("Сервер уже запущен");
                return false;
            }
            
            if (ipAddress == null)
            {
                ipAddress = IPAddress.Parse(this.form.inputIp.Text);
            }

            if (port == 0)
            {
                port = int.Parse(this.form.inputPort.Text);
            }

            controller = new Controller();
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(ipAddress, port));
                serverSocket.Listen(maxNOfCon);
                serverSocket.ReceiveTimeout = TIMEOUT;
                serverSocket.SendTimeout = TIMEOUT;
                running = true;
                form.Log("Сервер запущен");
            }
            catch (Exception e) 
            {
                form.Log("Ошибка при запуске сервера: "+ e.Message);
                return false; 
            }

            // Наш поток ждет новые подключения и создает новые потоки.
            Thread requestListenerT = new Thread(() =>
            {
                while (running)
                {
                    Socket clientSocket;
                    try
                    {
                        clientSocket = serverSocket.Accept();
                        // Создаем новый поток для нового клиента и продолжаем слушать сокет.
                        Thread requestHandler = new Thread(() =>
                        {
                            clientSocket.ReceiveTimeout = TIMEOUT;
                            clientSocket.SendTimeout = TIMEOUT;
                            try { HandleTheRequest(clientSocket); }
                            catch
                            {
                                try { clientSocket.Close(); } catch { }
                            }
                        });
                        requestHandler.Start();
                    }
                    catch { }
                }
            });
            requestListenerT.Start();

            return true;
        }

        public void Stop()
        {
            if (running)
            {
                running = false;
                try { serverSocket.Close(); }
                catch { }
                serverSocket = null;
                form.Log("Сервер остановлен");
            }
        }

        private void HandleTheRequest(Socket clientSocket)
        {
            byte[] buffer = new byte[10240]; // 10 kb
            int receivedBCount = clientSocket.Receive(buffer); // Получаем запрос
            string strReceived = charEncoder.GetString(buffer, 0, receivedBCount);

            // Парсим запрос
            string httpMethod = strReceived.Substring(0, strReceived.IndexOf(" "));

            if (httpMethod.Equals("GET"))
            {
                this.SendPage(clientSocket);
            } 
            else if (httpMethod.Equals("POST"))
            {
                string separator = "\r\n\r\n";
                int start = strReceived.IndexOf(separator) + separator.Length;
                try
                {
                    string body = strReceived.Substring(start);
                    JObject obj = JObject.Parse(body);
                    controller.CallbackReceivedRun(obj);
                } catch (Exception e)
                {
                    form.Log(e.Message);
                }
               
            }
        }

        private void SendPage(Socket clientSocket)
        {
            SendResponse(clientSocket, Properties.Resources.index, "200 OK", "text/html");
        }

        // For strings
        private void SendResponse(Socket clientSocket, string strContent, string responseCode, string contentType)
        {
            byte[] bContent = charEncoder.GetBytes(strContent);
            SendResponse(clientSocket, bContent, responseCode, contentType);
        }

        // For byte arrays
        private void SendResponse(Socket clientSocket, byte[] bContent, string responseCode, string contentType)
        {
            try
            {
                byte[] bHeader = charEncoder.GetBytes(
                                    "HTTP/1.1 " + responseCode + "\r\n"
                                  //+ "Server: Web Server\r\n"
                                  + "Content-Length: " + bContent.Length.ToString() + "\r\n"
                                  + "Connection: close\r\n"
                                  + "Content-Type: " + contentType + "\r\n\r\n");
                clientSocket.Send(bHeader);
                clientSocket.Send(bContent);
                clientSocket.Close();
            }
            catch { }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            for (int i = host.AddressList.Length - 1; i >= 0; i--)
            {
                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    return host.AddressList[i].ToString();
                }
            }
            return "127.0.0.1";
        }
    }
};