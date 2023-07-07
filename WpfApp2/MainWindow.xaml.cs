using System.IO.Pipes;
using System.IO;
using System;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            RecvMsg();
        }

        private void RecvMsg()
        {
            Console.WriteLine("Waiting for clients...");

            using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("MyPipe"))
            {
                pipeServer.WaitForConnection();

                Console.WriteLine("Client connected.");

                try
                {
                    using (StreamReader reader = new StreamReader(pipeServer))
                    {
                        string? message = reader.ReadLine();
                        Console.WriteLine("Received message: " + message);
                        MsgTextBlock.Text = message;
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error: {0}", e.Message);
                }
            }
        }
    }
}
