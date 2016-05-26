using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    /// Interaction logic for TeamViewPage.xaml
    /// </summary>
    public partial class TeamViewPage : UserControl
    {
        public int i = XFootBall.Properties.Settings.Default.NumeroDeJogadores;
        string pasta = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball";
        public TeamViewPage()
        {

           
            InitializeComponent();
            if(XFootBall.Properties.Settings.Default.NumeroDeJogadores == 1)
            {
                //caso um jogador
                string dados = File.ReadAllText(Directory.GetCurrentDirectory() + "\\1.XFile");
                Player player = JsonConvert.DeserializeObject<Player>(dados);
                Equipa equipa = PegaDados(File.ReadAllText(pasta + "\\Equipas\\" + player.equipa + ".XFileE"));
                image.Source = new BitmapImage(new Uri(equipa.Emblema));
                label.Content = equipa.Nome;
                treinador_label.Content = "Treinador: " + player.nome;
                //Load dos onze iniciais
                foreach(jogador jogador in equipa.Jogadores)
                {
                    if (jogador.banco == false)
                    {
                        listBox1.Items.Add(jogador.nome);
                    }
                    else
                    {
                        listBox.Items.Add(jogador.nome);
                    }
                }

            }
            else if (XFootBall.Properties.Settings.Default.NumeroDeJogadores == 2)
            {
                //caso 2 jogadores

            }
            else if (XFootBall.Properties.Settings.Default.NumeroDeJogadores == 3)
            {
                //caso 3 jogadores

            }
            else if (XFootBall.Properties.Settings.Default.NumeroDeJogadores == 4)
            {
                //caso 4 jogadores

            }


            /*
            string dados = File.ReadAllText(Directory.GetCurrentDirectory() + "\\1.XFile");
            player = JsonConvert.DeserializeObject<Player>(dados);
            string dados2 = File.ReadAllText(pasta + "\\Equipas\\" + player.equipa + ".XFileE");
            label.Content = player.equipa;
            treinador_label.Content = "Treinador: " + player.nome;
            equipa = JsonConvert.DeserializeObject<Equipa>(dados2);
            BitmapImage emblema = new BitmapImage(new Uri(equipa.Emblema));
            image.Source = emblema;
            foreach(jogador jogador in equipa.Jogadores)
            {
                if (jogador.banco == false)
                {
                    listBox1.Items.Add(jogador.nome);
                }
                else
                {
                    listBox.Items.Add(jogador.nome);
                }

                listBox.SelectedIndex = 0;
                listBox1.SelectedIndex = 0;
            }

    */
        }

        private void ordenar(bool lado) //se for true tmos a mexer no onze

        {
            int i = 0;
            string dados = File.ReadAllText(pasta + "\\Equipas\\" + label.Content + ".XFileE");
            Equipa temp = PegaDados(dados);
            if (lado == true)
            {
                foreach (jogador jogador in temp.Jogadores)
                {
                    if (jogador.banco == false)
                    {
                        if (jogador.posicao == "GK")
                        {
                            listBox1.Items.Clear();
                            listBox1.Items.Add(jogador.nome);

                        }
                        if (jogador.posicao == "SW" || jogador.posicao == "CB" || jogador.posicao == "LB" || jogador.posicao == "LCB" || jogador.posicao == "LWB" || jogador.posicao == "RB" || jogador.posicao == "RCB" || jogador.posicao == "RWB")
                        {
                            listBox1.Items.Add(jogador.nome);
                        }
                        if (jogador.posicao == "DM" || jogador.posicao == "LM" || jogador.posicao == "LCM" || jogador.posicao == "RM" || jogador.posicao == "RCM" || jogador.posicao == "CM" || jogador.posicao == "CDM" || jogador.posicao == "CAM" || jogador.posicao == "AM" || jogador.posicao == "LW" || jogador.posicao == "RW" || jogador.posicao == "CF")
                        {
                            listBox1.Items.Add(jogador.nome);
                        }
                        if (jogador.posicao == "WF" || jogador.posicao == "ST" || jogador.posicao == "LS" || jogador.posicao == "RS")
                        {
                            listBox1.Items.Add(jogador.nome);
                        }



                    }


                }


            }




        }



    


        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string jogadorparabanco = listBox1.SelectedItem.ToString();
            string jogadorparaonze = listBox.SelectedItem.ToString();
            //mudar nas listas
            listBox.Items.Remove(listBox.SelectedItem);
            listBox1.Items.Remove(listBox1.SelectedItem);
            listBox.Items.Add(jogadorparaonze);
            listBox1.Items.Add(jogadorparabanco);
            listBox1.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("", System.ComponentModel.ListSortDirection.Ascending));
            listBox.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("", System.ComponentModel.ListSortDirection.Ascending));
            listBox.Items.Refresh();
            listBox1.Items.Refresh();
            listBox.SelectedIndex = 0;
            listBox1.SelectedIndex = 0;
            //mudar nos ficheiros de jogo
            Equipa teste = PegaDados(File.ReadAllText(pasta + "\\Equipas\\" + label.Content + ".XFileE"));
            foreach(jogador jogador in teste.Jogadores)
            {
                if (jogador.nome == jogadorparabanco)
                {
                    jogador.banco = true;
                }
                else if (jogador.nome == jogadorparaonze)
                {
                    jogador.banco = false;
                }
                else
                { }

            }
            File.WriteAllText(pasta + "\\Equipas\\" + label.Content + ".XFileE", Compactar(teste));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (XFootBall.Properties.Settings.Default.NumeroDeJogadores == 1)
            {

            }
        }


        public string Compactar(Equipa equipa)
        {
            string resultado;
            resultado = JsonConvert.SerializeObject(equipa);
            return resultado;
        }

        public Equipa PegaDados(string dados)
        {
            Equipa temp = new Equipa();
            temp = JsonConvert.DeserializeObject<Equipa>(dados);
            return temp;

        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                //Equipa joel = new Equipa();
                jogador joao = new XFootBall.jogador();
                Equipa team = new Equipa();
                string dados = File.ReadAllText(pasta + "\\Equipas\\" + label.Content.ToString() + ".XFileE");
                team = JsonConvert.DeserializeObject<Equipa>(dados);
                //JToken jogador = joel["jogadores"][listBox1.SelectedItem];
                foreach (jogador jogador in team.Jogadores)
                {
                    if (jogador.nome == listBox1.SelectedItem.ToString())
                    {
                        jogadorperfilonze.Source = new BitmapImage(new Uri(jogador.imagem));
                        richTextBox.Document.Blocks.Clear();
                        richTextBox.AppendText("Nome: " + jogador.nome + Environment.NewLine + "Idade: " + jogador.idade.ToString() + Environment.NewLine + "Valor: " + jogador.pontuacao + Environment.NewLine + "Posicao: " + jogador.posicao);
                    }
                }
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ordenar(true);
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                jogador joao = new XFootBall.jogador();
                Equipa team = new Equipa();
                string dados = File.ReadAllText(pasta + "\\Equipas\\" + label.Content.ToString() + ".XFileE");
                team = JsonConvert.DeserializeObject<Equipa>(dados);
                foreach (jogador jogador in team.Jogadores)
                {
                    if (jogador.nome == listBox.SelectedItem.ToString())
                    {
                        jogadorperfilsubs.Source = new BitmapImage(new Uri(jogador.imagem));
                        richTextBox_Copy.Document.Blocks.Clear();
                        richTextBox_Copy.AppendText("Nome: " + jogador.nome + Environment.NewLine + "Idade: " + jogador.idade.ToString() + Environment.NewLine + "Valor: " + jogador.pontuacao + Environment.NewLine + "Posicao: " + jogador.posicao);
                    }
                }
            }
        }
    }
}
