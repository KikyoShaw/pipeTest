using System.IO.Pipes;
using System.IO;
using System;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var text = MsgTextBox.Text;
            using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "MyPipe", PipeDirection.Out))
            {
                pipeClient.Connect();

                Console.WriteLine("Connected to server.");

                using (StreamWriter writer = new StreamWriter(pipeClient))
                {
                    writer.AutoFlush = true;
                    writer.WriteLine(text);
                }
            }
        }
    }
}
