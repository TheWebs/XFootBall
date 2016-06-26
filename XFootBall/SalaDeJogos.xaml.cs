using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace XFootBall
{
    /// <summary>
    /// Interaction logic for SalaDeJogos.xaml
    /// </summary>
    public partial class SalaDeJogos : UserControl
    {
        public SalaDeJogos()
        {
            InitializeComponent();
            d11.nome.Content = "Real Madrid";
            AtribuiCores();
        }

        private void AtribuiCores()
        {
            List <Color> cores = new List<Color>();
            Random rand = new Random();
            while (cores.Count < 40)
            {
                cores.Add(Color.FromArgb((byte)100, (byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255)));
            }
            int i = 0;
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

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AtribuiCores();
        }
    }
}
