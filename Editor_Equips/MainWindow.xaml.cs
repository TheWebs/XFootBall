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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;

namespace Editor_Equips
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int maxID;
        string pasta = Directory.GetCurrentDirectory();
        public MainWindow()
        {
            InitializeComponent();
            AtualizarLista();
            id_t.Text = (maxID + 1).ToString();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button_Click(object sender, RoutedEventArgs e) //Criar equipa
        {
            
            Equipa ze = new Equipa();
            ze.Nome = nome_t.Text;
            ze.Divisao = Int32.Parse(divisao_t.Text);
            ze.Id = Int32.Parse(id_t.Text);
            ze.Emblema = pasta + "\\Emblemas\\" + ze.Nome + ".png";
            ze.Valor = Int32.Parse(valor_t.Text);
            string dados_final = Compactar(ze);
            WebClient net = new WebClient();
            net.DownloadFile(emblema_t.Text, pasta + "\\Emblemas\\" + ze.Nome + ".png");
            File.WriteAllText(pasta + "\\Equipas\\" + ze.Nome + ".XFileE", dados_final);
            AtualizarLista();
            id_t.Text = (maxID + 1).ToString();
            nome_t.Text = "";
            divisao_t.Text = "";
            valor_t.Text = "";
            emblema_t.Text = "";

        }

        public class Equipa
        {
            public string Nome { get; set; }
            public int Id { get; set; }
            public string Emblema { get; set; }
            public int Divisao { get; set; }
            public int Valor { get; set; }
        }

        public string Compactar(Equipa equipa)
        {
            string resultado;
            resultado = JsonConvert.SerializeObject(equipa);
            return resultado;
        }

        public Equipa PegaDados (string dados)
        {
            Equipa temp = new Equipa();
            temp = JsonConvert.DeserializeObject<Equipa>(dados);
            return temp;
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                //atualizando lista...
            }
            else
            {
                string dados = File.ReadAllText(pasta + "\\Equipas\\" + listBox.SelectedItem + ".XFileE");
                Equipa tempo = PegaDados(dados);
                nome_equipa.Content = "Nome: " + tempo.Nome;
                divisao_equipa.Content = "Divisao: " + tempo.Divisao;
                valor_equipa.Content = "Valor: " + tempo.Valor;
                id_equipa.Content = "ID: " + tempo.Id;
                BitmapImage imagem = new BitmapImage(new Uri(tempo.Emblema));
                image.Source = imagem;
            }
        }

        private void AtualizarLista()
        {
            maxID = 0;
            listBox.Items.Clear();
            string[] equipas = Directory.GetFiles(pasta + "\\Equipas\\");
            foreach (string equipa in equipas)
            {
                maxID++;
                FileInfo info = new FileInfo(equipa);
                listBox.Items.Add(info.Name.Replace(".XFileE", ""));
            }
            listBox.SelectedIndex = 0;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

    }
}
