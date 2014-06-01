using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Remoting.Messaging;

namespace ClassLibrary
{
    public static class Messenger
    {
        public static void Listen(AsyncCallback callback)
        {
            IPHostEntry ipHostInfo = Dns.GetHostByAddress("127.0.0.1");
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(localEndPoint);
            socket.Listen(100);

            while (true)
            {
                Console.WriteLine("Waiting for connection...");
                Socket socketServer = socket.Accept();
                Console.WriteLine("Socket connection accepted from: " + ((IPEndPoint)socketServer.RemoteEndPoint).Address.ToString());

                ProcessMessageAsync caller = new ProcessMessageAsync(ProcessMessage);
                IAsyncResult result = caller.BeginInvoke(socketServer, callback, null);
            }
        }

        public static Socket ProcessMessage(Socket socket)
        {
            return socket;
        }

        public static Message ReceiveMessage(Socket socket)
        {
            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {

                byte[] header = new byte[5];
                int bytesRead = socket.Receive(header);
                MessageType messageType = (MessageType)header[0];
                Int32 dataSize = BitConverter.ToInt32(header, 1);
                Console.WriteLine("Bytes read: {0}", bytesRead);
                Console.WriteLine("Message Type: {0}", messageType);
                Console.WriteLine("Payload Size: {0}", dataSize);

                byte[] data = new byte[dataSize];
                byte[] buffer = new byte[1024];


                Int32 totalBytesRead = 0;
                while (totalBytesRead < dataSize)
                {
                    bytesRead = socket.Receive(buffer);
                    Console.WriteLine("Bytes read: {0}", bytesRead);
                    Array.Copy(buffer, 0, data, totalBytesRead, bytesRead);
                    totalBytesRead += bytesRead;
                }
                Console.WriteLine("Bytes read: {0}", totalBytesRead);
                Console.WriteLine("Payload Size: {0}", dataSize);

                MemoryStream stream = new MemoryStream(data);
                IFormatter formatter = new BinaryFormatter();
                Object payload = formatter.Deserialize(stream);

                Message message = new Message(messageType, payload);
                return message;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return null;
        }

        public static void SendMessage(Socket socket, Message message)
        {
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, message.payload);
            byte[] payload = stream.ToArray(); // we have the byte[] array! 
            Console.WriteLine("Payload Length: {0}", payload.Length);
            byte[] data = new byte[payload.Length + 5];
            data[0] = (byte)message.messageType;
            byte[] intBytes = BitConverter.GetBytes(payload.Length);
            data[1] = intBytes[0];
            data[2] = intBytes[1];
            data[3] = intBytes[2];
            data[4] = intBytes[3];
            Console.WriteLine("Length Bytes: {0} {1} {2} {3}", data[1], data[2], data[3], data[4]);
            Array.Copy(payload, 0, data, 5, payload.Length);

            Console.WriteLine("Sending");
            socket.Send(data);
        }

        public static Socket SendMessage(Message message)
        {
            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                // This example uses port 11000 on the local computer.
                IPHostEntry ipHostInfo = Dns.GetHostByAddress("127.0.0.1");
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP  socket.
                Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    sender.Connect(remoteEndPoint);
                    Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

                    SendMessage(sender, message);
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

                return sender;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return null;
        }
    }

    public delegate Socket ProcessMessageAsync(Socket socket);

}
