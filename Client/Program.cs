using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Client
{
    public static void Main()
    {
        TcpClient client = new TcpClient();
        Console.Write("Введіть IP-адресу сервера: ");
        string ipAddress = Console.ReadLine();
        Console.Write("Введіть ваше ім'я: ");
        string clientName = Console.ReadLine();

        try
        {
            client.Connect(ipAddress, 12345);
            NetworkStream clientStream = client.GetStream();

            Console.WriteLine($"Ви приєдналися до сервера як '{clientName}'.");

            while (true)
            {
                string message = Console.ReadLine();
                string formattedMessage = $"{clientName}: {message}";

                byte[] data = Encoding.ASCII.GetBytes(formattedMessage);
                clientStream.Write(data, 0, data.Length);
                clientStream.Flush();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Помилка: " + e.Message);
        }
        finally
        {
            client.Close();
        }
    }
}
