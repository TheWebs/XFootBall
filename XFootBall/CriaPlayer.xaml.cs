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
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XFootBall
{
    /// <summary>
    /// Interaction logic for CriaPlayer.xaml
    /// </summary>
    public partial class CriaPlayer : UserControl
    {
        int numero;
        int o = 1;
        public CriaPlayer()
        {
            InitializeComponent();
            if(XFootBall.Properties.Settings.Default.NumeroDeJogadores == 1)
            {
                numero = 1;
                button.Content = "Avancar";
            }
            else if (XFootBall.Properties.Settings.Default.NumeroDeJogadores == 2)
            {
                numero = 2;
            }
            else if (XFootBall.Properties.Settings.Default.NumeroDeJogadores == 3)
            {
                numero = 3;
            }
            else if (XFootBall.Properties.Settings.Default.NumeroDeJogadores == 4)
            {
                numero = 4;
            }
        }

        private void textBox_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {
            int idade;
            if (Int32.TryParse(textBox_Copy.Text, out idade))
            {
                Console.WriteLine(idade);
                this.player.idade_label.Content = "Idade: " + idade.ToString();
                button.IsEnabled = true;
            }
            else
            {
                button.IsEnabled = false;
                this.player.idade_label.Content = "Idade: " + idade.ToString();
                Console.WriteLine("String could not be parsed.");
            }


        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Player playerr = new Player();
            if (o < numero)
            {
                 playerr.nome = textBox.Text;
            playerr.idade = (short)Int32.Parse(textBox_Copy.Text);
            
            string data = JsonConvert.SerializeObject(playerr);

            File.WriteAllText(Directory.GetCurrentDirectory() + "\\" + o + ".XFile", data);
            o++;
                textBox.Text = "";
                textBox_Copy.Text = "";
            }
            else if(o == numero)
            {
                playerr.nome = textBox.Text;
                playerr.idade = (short)Int32.Parse(textBox_Copy.Text);

                string data = JsonConvert.SerializeObject(playerr);

                File.WriteAllText(Directory.GetCurrentDirectory() + "\\" + o + ".XFile", data);
                o++;
                textBox.Text = "";
                textBox_Copy.Text = "";
                Switcher.Switch(new SortearEquipas());
            }


        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.player.nome_label.Content = "Nome: " + textBox.Text;
        }
    }
  }
    

