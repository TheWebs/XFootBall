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

namespace XFootBall
{
    /// <summary>
    /// Interaction logic for SortearEquipas.xaml
    /// </summary>
    public partial class SortearEquipas : UserControl
    {
        Random rnd = new Random();
        string pasta = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball";

        List<Equipa> lista = new List<Equipa> { };


        public SortearEquipas()
        {
            InitializeComponent();
            if(XFootBall.Properties.Settings.Default.NumeroDeJogadores == 1)
            {
                TerceiraCarta.Visibility = Visibility.Visible;
                TerceiraCarta.nome_label.Content = "Nome: " +  ObtemNomePlayer(1);
                TerceiraCarta.idade_label.Content = "Idade: " + ObtemIdadePlayer(1);
            }
            else if (XFootBall.Properties.Settings.Default.NumeroDeJogadores == 2)
                {
                SegundaCarta.Visibility = Visibility.Visible;
                SegundaCarta.nome_label.Content = "Nome: " + ObtemNomePlayer(1);
                SegundaCarta.idade_label.Content = "Idade: " + ObtemIdadePlayer(1);
                QuartaCarta.Visibility = Visibility.Visible;
                QuartaCarta.nome_label.Content = "Nome: " + ObtemNomePlayer(2);
                QuartaCarta.idade_label.Content = "Idade: " + ObtemIdadePlayer(2);

            }
            else if (XFootBall.Properties.Settings.Default.NumeroDeJogadores == 3)
            {
                PrimeiraCarta.Visibility = Visibility.Visible;
                PrimeiraCarta.nome_label.Content = "Nome: " + ObtemNomePlayer(1);
                PrimeiraCarta.idade_label.Content = "Idade: " + ObtemIdadePlayer(1);
                TerceiraCarta.Visibility = Visibility.Visible;
                TerceiraCarta.nome_label.Content = "Nome: " + ObtemNomePlayer(2);
                TerceiraCarta.idade_label.Content = "Idade: " + ObtemIdadePlayer(2);
                QuintaCarta.Visibility = Visibility.Visible;
                QuintaCarta.nome_label.Content = "Nome: " + ObtemNomePlayer(3);
                QuintaCarta.idade_label.Content = "Idade: " + ObtemIdadePlayer(3);
            }
            else if(XFootBall.Properties.Settings.Default.NumeroDeJogadores == 4)
            {
                PrimeiraCarta.Visibility = Visibility.Visible;
                PrimeiraCarta.nome_label.Content = "Nome: " + ObtemNomePlayer(1);
                PrimeiraCarta.idade_label.Content = "Idade: " + ObtemIdadePlayer(1);
                SegundaCarta.Visibility = Visibility.Visible;
                SegundaCarta.nome_label.Content = "Nome: " + ObtemNomePlayer(2);
                SegundaCarta.idade_label.Content = "Idade: " + ObtemIdadePlayer(2);
                QuintaCarta.Visibility = Visibility.Visible;
                QuintaCarta.nome_label.Content = "Nome: " + ObtemNomePlayer(4);
                QuintaCarta.idade_label.Content = "Idade: " + ObtemIdadePlayer(4);
                QuartaCarta.Visibility = Visibility.Visible;
                QuartaCarta.nome_label.Content = "Nome: " + ObtemNomePlayer(3);
                QuartaCarta.idade_label.Content = "Idade: " + ObtemIdadePlayer(3);
            }
            ObtemEquipasParaSorteio();

            
        }





        bool UltimaDivisao(Equipa equipa) //verifica se uma determindada equipa e da ultima divisao
        {
            if(equipa.Divisao == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private void ObtemEquipasParaSorteio() // Faz uma lista das equipas da 4ta divisao
        {
            string[] equipas = Directory.GetFiles(pasta + "\\Equipas\\");
            foreach (string equipa in equipas)
            {
                FileInfo info = new FileInfo(equipa);
                if(UltimaDivisao(PegaDados(File.ReadAllText(info.FullName))) == true)
                {
                    lista.Add(PegaDados(File.ReadAllText(info.FullName)));
                }
                else
                {
                    //do nothing
                }
                
                
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

        public string ObtemNomePlayer(int numero)
        {
            string dados = File.ReadAllText(Directory.GetCurrentDirectory() + "\\" + numero + ".XFile");
            Player temp = new Player();
            temp = JsonConvert.DeserializeObject<Player>(dados);
            return temp.nome;
        }

        public string ObtemIdadePlayer(int numero)
        {
            string dados = File.ReadAllText(Directory.GetCurrentDirectory() + "\\" + numero + ".XFile");
            Player temp = new Player();
            temp = JsonConvert.DeserializeObject<Player>(dados);
            return temp.idade.ToString();
        }

        public void CriaPlayer(int numero, string equipa)
        {
            Player jonas = new Player();
            jonas.nome = ObtemNomePlayer(numero);
            jonas.idade = (short)Int32.Parse(ObtemIdadePlayer(numero));
            jonas.equipa = equipa;
            string dados = JsonConvert.SerializeObject(jonas);
            File.WriteAllText(Directory.GetCurrentDirectory() + "\\" + numero + ".XFile", dados);
        }

        private void button_Click(object sender, RoutedEventArgs e) //RANDOMIZAR EQUIPAS E MOSTRA LAS (NOME E IMAGEM)
        {
            // int month = rnd.Next(1, 13); // creates a number between 1 and 12
           if (XFootBall.Properties.Settings.Default.NumeroDeJogadores == 1) //RANDOMIZAR PARA 1 JOGADORES
            {
                int um = rnd.Next(0, lista.Count);
                TerceiraCarta.equipa_label.Visibility = Visibility.Visible;
                TerceiraCarta.equipa_label.Content = "Equipa: " + lista[um].Nome;
                TerceiraCarta.imagem.Source = new BitmapImage(new Uri(PegaDados(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\Equipas\\" + lista[um].Nome + ".XFileE")).Emblema));
            }
           else if(XFootBall.Properties.Settings.Default.NumeroDeJogadores == 2) //RANDOMIZAR PARA 2 JOGADORES
            {
                int um = rnd.Next(0, lista.Count);
                SegundaCarta.equipa_label.Visibility = Visibility.Visible;
                SegundaCarta.equipa_label.Content = "Equipa: " + lista[um].Nome;
                SegundaCarta.imagem.Source = new BitmapImage(new Uri(PegaDados(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\Equipas\\" + lista[um].Nome + ".XFileE")).Emblema));
                int dois = rnd.Next(0, lista.Count);
                while (dois == um) //impede que saiam equipas iguais
                {
                    dois = rnd.Next(0, lista.Count);
                }
                QuartaCarta.equipa_label.Visibility = Visibility.Visible;
                QuartaCarta.equipa_label.Content = "Equipa: " + lista[dois].Nome;
                QuartaCarta.imagem.Source = new BitmapImage(new Uri(PegaDados(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\Equipas\\" + lista[dois].Nome + ".XFileE")).Emblema));
            }
            else if (XFootBall.Properties.Settings.Default.NumeroDeJogadores == 3) //RANDOMIZAR PARA 3 JOGADORES
            {
                int um = rnd.Next(0, lista.Count);
                PrimeiraCarta.equipa_label.Visibility = Visibility.Visible;
                PrimeiraCarta.equipa_label.Content = "Equipa: " + lista[um].Nome;
                PrimeiraCarta.imagem.Source = new BitmapImage(new Uri(PegaDados(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\Equipas\\" + lista[um].Nome + ".XFileE")).Emblema));
                int dois = rnd.Next(0, lista.Count);
                while (dois == um) //impede que saiam equipas iguais
                {
                    dois = rnd.Next(0, lista.Count);
                }
                TerceiraCarta.equipa_label.Visibility = Visibility.Visible;
                TerceiraCarta.equipa_label.Content = "Equipa: " + lista[dois].Nome;
                TerceiraCarta.imagem.Source = new BitmapImage(new Uri(PegaDados(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\Equipas\\" + lista[dois].Nome + ".XFileE")).Emblema));
                int tres = rnd.Next(0, lista.Count);
                while (tres == um || tres == dois) //impede que saiam equipas iguais
                {
                    tres = rnd.Next(0, lista.Count);
                }
                QuintaCarta.equipa_label.Visibility = Visibility.Visible;
                QuintaCarta.equipa_label.Content = "Equipa: " + lista[tres].Nome;
                QuintaCarta.imagem.Source = new BitmapImage(new Uri(PegaDados(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\Equipas\\" + lista[tres].Nome + ".XFileE")).Emblema));
            }
            else if (XFootBall.Properties.Settings.Default.NumeroDeJogadores == 4) //RANDOMIZAR PARA 4 JOGADORES
            {
                int um = rnd.Next(0, lista.Count);
                PrimeiraCarta.equipa_label.Visibility = Visibility.Visible;
                PrimeiraCarta.equipa_label.Content = "Equipa: " + lista[um].Nome;
                PrimeiraCarta.imagem.Source = new BitmapImage(new Uri(PegaDados(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\Equipas\\" + lista[um].Nome + ".XFileE")).Emblema));
                int dois = rnd.Next(0, lista.Count);
                while (dois == um) //impede que saiam equipas iguais
                {
                    dois = rnd.Next(0, lista.Count);
                }
                SegundaCarta.equipa_label.Visibility = Visibility.Visible;
                SegundaCarta.equipa_label.Content = "Equipa: " + lista[dois].Nome;
                SegundaCarta.imagem.Source = new BitmapImage(new Uri(PegaDados(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\Equipas\\" + lista[dois].Nome + ".XFileE")).Emblema));
                int tres = rnd.Next(0, lista.Count);
                while (tres == um || tres == dois) //impede que saiam equipas iguais
                {
                    tres = rnd.Next(0, lista.Count);
                }
                QuartaCarta.equipa_label.Visibility = Visibility.Visible;
                QuartaCarta.equipa_label.Content = "Equipa: " + lista[tres].Nome;
                QuartaCarta.imagem.Source = new BitmapImage(new Uri(PegaDados(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\Equipas\\" + lista[tres].Nome + ".XFileE")).Emblema));
                int quatro = rnd.Next(0, lista.Count);
                while (quatro == um || quatro == dois || quatro == tres) //impede que saiam equipas iguais
                {
                    quatro = rnd.Next(0, lista.Count);
                }
                QuintaCarta.equipa_label.Visibility = Visibility.Visible;
                QuintaCarta.equipa_label.Content = "Equipa: " + lista[quatro].Nome;
                QuintaCarta.imagem.Source = new BitmapImage(new Uri(PegaDados(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\Equipas\\" + lista[quatro].Nome + ".XFileE")).Emblema));
            }

            button1.IsEnabled = true;
        }

        private void button1_Click_1(object sender, RoutedEventArgs e) //atualiza ficheiro dos players com as equipas
        {
            if (XFootBall.Properties.Settings.Default.NumeroDeJogadores == 1)
            {
                CriaPlayer(1, TerceiraCarta.equipa_label.Content.ToString().Replace("Equipa: ", ""));
            }
            else if(XFootBall.Properties.Settings.Default.NumeroDeJogadores == 2)
            {
                CriaPlayer(1, SegundaCarta.equipa_label.Content.ToString().Replace("Equipa: ", ""));
                CriaPlayer(2, QuartaCarta.equipa_label.Content.ToString().Replace("Equipa: ", ""));
            }
            else if (XFootBall.Properties.Settings.Default.NumeroDeJogadores == 3)
            {
                CriaPlayer(1, PrimeiraCarta.equipa_label.Content.ToString().Replace("Equipa: ", ""));
                CriaPlayer(2, TerceiraCarta.equipa_label.Content.ToString().Replace("Equipa: ", ""));
                CriaPlayer(3, QuintaCarta.equipa_label.Content.ToString().Replace("Equipa: ", ""));
            }
            else if (XFootBall.Properties.Settings.Default.NumeroDeJogadores == 4)
            {
                CriaPlayer(1, PrimeiraCarta.equipa_label.Content.ToString().Replace("Equipa: ", ""));
                CriaPlayer(2, SegundaCarta.equipa_label.Content.ToString().Replace("Equipa: ", ""));
                CriaPlayer(3, QuartaCarta.equipa_label.Content.ToString().Replace("Equipa: ", ""));
                CriaPlayer(4, QuintaCarta.equipa_label.Content.ToString().Replace("Equipa: ", ""));
            }
            Switcher.Switch(new TeamViewPage());

        }
    }
}
