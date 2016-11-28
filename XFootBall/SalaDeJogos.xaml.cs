using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace XFootBall
{
    /// <summary>
    /// Interaction logic for SalaDeJogos.xaml
    /// </summary>
    public partial class SalaDeJogos : UserControl
    {
        Temporizador teste;
        public SalaDeJogos()
        {
            InitializeComponent();
            d11.nome.Content = "Real Madrid";
            AtribuiCores();
            teste = new Temporizador();
            anelProgresso.Maximum = 22;
            ThreadPool.QueueUserWorkItem(p => teste.start());
            anelProgresso.Minimum = 0;
            var worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerAsync();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
             int i = teste.getSegundos();
            while (teste.isCounting() == true)
            {
                if (i != teste.getSegundos())
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        anelProgresso.Value = teste.getSegundos();
                    });

                    Console.WriteLine("[SALA DE JOGOS] - {0}", teste.getSegundos());
                    i = teste.getSegundos();
                }
            }
        }

        private void AtribuiCores()
        {
            List <Color> cores = new List<Color>();
            Random rand = new Random();
            int i = 0;
            while(i<1000) //fazer numeros mais aleatorios
            {
                rand.Next(700);
                i++;
            }
            while (cores.Count < 40)
            {
                cores.Add(Color.FromArgb((byte)100, (byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255)));
            }
            i = 0;
            d11.Background = new SolidColorBrush(cores[i]);
            i++;
            d12.Background = new SolidColorBrush(cores[i]);
            i++;
            d13.Background = new SolidColorBrush(cores[i]);
            i++;
            d14.Background = new SolidColorBrush(cores[i]);
            i++;
            d15.Background = new SolidColorBrush(cores[i]);
            i++;
            d16.Background = new SolidColorBrush(cores[i]);
            i++;
            d17.Background = new SolidColorBrush(cores[i]);
            i++;
            d18.Background = new SolidColorBrush(cores[i]);
            i++;
            d19.Background = new SolidColorBrush(cores[i]);
            i++;
            d110.Background = new SolidColorBrush(cores[i]);
            i++;
            d21.Background = new SolidColorBrush(cores[i]);
            i++;
            d22.Background = new SolidColorBrush(cores[i]);
            i++;
            d23.Background = new SolidColorBrush(cores[i]);
            i++;
            d24.Background = new SolidColorBrush(cores[i]);
            i++;
            d25.Background = new SolidColorBrush(cores[i]);
            i++;
            d26.Background = new SolidColorBrush(cores[i]);
            i++;
            d27.Background = new SolidColorBrush(cores[i]);
            i++;
            d28.Background = new SolidColorBrush(cores[i]);
            i++;
            d29.Background = new SolidColorBrush(cores[i]);
            i++;
            d210.Background = new SolidColorBrush(cores[i]);
            i++;
            d31.Background = new SolidColorBrush(cores[i]);
            i++;
            d32.Background = new SolidColorBrush(cores[i]);
            i++;
            d33.Background = new SolidColorBrush(cores[i]);
            i++;
            d34.Background = new SolidColorBrush(cores[i]);
            i++;
            d35.Background = new SolidColorBrush(cores[i]);
            i++;
            d36.Background = new SolidColorBrush(cores[i]);
            i++;
            d37.Background = new SolidColorBrush(cores[i]);
            i++;
            d38.Background = new SolidColorBrush(cores[i]);
            i++;
            d39.Background = new SolidColorBrush(cores[i]);
            i++;
            d310.Background = new SolidColorBrush(cores[i]);
            i++;
            d41.Background = new SolidColorBrush(cores[i]);
            i++;
            d42.Background = new SolidColorBrush(cores[i]);
            i++;
            d43.Background = new SolidColorBrush(cores[i]);
            i++;
            d44.Background = new SolidColorBrush(cores[i]);
            i++;
            d45.Background = new SolidColorBrush(cores[i]);
            i++;
            d46.Background = new SolidColorBrush(cores[i]);
            i++;
            d47.Background = new SolidColorBrush(cores[i]);
            i++;
            d48.Background = new SolidColorBrush(cores[i]);
            i++;
            d49.Background = new SolidColorBrush(cores[i]);
            i++;
            d410.Background = new SolidColorBrush(cores[i]);
        }

    }
}
