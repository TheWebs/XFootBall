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
    /// Interaction logic for NumeroPlayers.xaml
    /// </summary>
    public partial class NumeroPlayers : UserControl
    {
        public NumeroPlayers()
        {
            InitializeComponent();
            umjogador.IsChecked = true;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            short i = 0;
            if(umjogador.IsChecked == true)
            {
                i = 1;

            }
            else if (doisjogadores.IsChecked == true)
            {
                i = 2;
            }
            else if (tresjogadores.IsChecked == true)
            {
                i = 3;
            }
            else if(quatrojogadores.IsChecked == true)
            {
                i = 4;
            }
            XFootBall.Properties.Settings.Default.NumeroDeJogadores = i;

            Switcher.Switch(new CriaPlayer());
                }

        
    }
}
