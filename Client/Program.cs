using System;
using System.Net.Sockets;
using System.Threading;
public class Client
{
    static public void Main(string[] Args)
    {
        TcpClient socketForServer;
        try
        {
            Console.WriteLine("IP:");
            string IpCliente = Console.ReadLine();
            socketForServer = new TcpClient(IpCliente, 10);
        }
        catch
        {
            Console.WriteLine(
            "Failed to connect to server at {0}:999", "localhost");
            return;
        }
       
        NetworkStream networkStream = socketForServer.GetStream();
        System.IO.StreamReader streamReader = new System.IO.StreamReader(networkStream);
        System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(networkStream);
        Console.WriteLine("*******This is client program who is connected to localhost on port No:10*****");
        
        try
        {
            {
                Console.WriteLine("type:");
                string str = Console.ReadLine();
                while (str != "exit")
                {
                    streamWriter.WriteLine(str);
                    streamWriter.Flush();
                    Console.WriteLine("type:");
                    str = Console.ReadLine();
                    string theString = streamReader.ReadLine();
                    Console.WriteLine("Message recieved by server:" + theString);
                }
                if (str == "exit")
                {
                    streamWriter.WriteLine(str);
                    streamWriter.Flush();
                   
                }

                while (true)
                {
                    
                }

            }
        }
        catch
        {
            Console.WriteLine("Exception reading from Server");
        }

        // tidy up

        networkStream.Close();
        Console.WriteLine("Press any key to exit from client program");
        Console.ReadKey();
    }

    private static string GetData()
    {
        //Ack from sql server
        return "ack";
    }
}