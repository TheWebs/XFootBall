using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Inicio.xaml
    /// </summary>
    public partial class Inicio : UserControl
    {
        string pasta = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball";
        public Inicio()
        {
            InitializeComponent();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //REINICIA EQUIPAS/ RESETA TRANSFERENCIAS EFETUADAS EM JOGOS ANTIGOS
            foreach(string file in Directory.GetFiles(pasta + "\\backup"))
            {
                FileInfo info = new FileInfo(file);
                File.Copy(info.FullName, pasta + "\\Equipas\\" + info.Name, true);
            }
            Switcher.Switch(new NumeroPlayers());
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new SalaDeJogos());
        }
    }
}
