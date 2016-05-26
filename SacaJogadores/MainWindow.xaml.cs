using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SacaJogadores
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<jogador> jogadores = new List<jogador> { };
        bool jatao11 = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            jogadores.Clear();
            jatao11 = false;
            WebClient net = new WebClient();
            string Texto = net.DownloadString(URL.Text);
            var contentType = net.ResponseHeaders["Content-Type"];
            var charset = Regex.Match(contentType, "charset=([^;]+)").Groups[1].Value;
            net.Encoding = Encoding.GetEncoding(charset);
            Texto = net.DownloadString(URL.Text);

            //ENCONTRA E RETIRA TEXTO DA TABELA

            HtmlDocument pagina = new HtmlDocument();
            pagina.LoadHtml(Texto);
            HtmlAgilityPack.HtmlNode bodyNode = pagina.DocumentNode.SelectSingleNode("//body//table//tbody");
            int i = 0;
            int a = 0;
            foreach(HtmlNode linha in bodyNode.ChildNodes)
            {
                if (i%2 != 0)
                {
                    if(a == 11 )
                    {
                        jatao11 = true;
                    }
                    //MessageBox.Show(linha.InnerHtml);

                    jogadores.Add(ObtemInfo(linha));
                    a++;
                }
                i++;
            }

            //cria ficheiro de equipa
           foreach(jogador jogador in jogadores)
            {
                string compacto = JsonConvert.SerializeObject(jogador);
                string json = JsonConvert.SerializeObject(new { jogadores = jogadores, Nome = nome.Text, Divisao = divisao.Text, Emblema = (Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\Emblemas\\" + nome.Text + ".png"), Valor = "1", HT = "1" });
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\Equipas\\" + nome.Text + ".XFileE", json);
            }


            
        }

        public jogador ObtemInfo(HtmlNode htmlnode)
        {
            int o = 0;
            WebClient ze = new WebClient();
            jogador temp = new jogador();
            foreach ( HtmlNode linha in htmlnode.ChildNodes)
            {
               
                if (o == 5) //IMAGEM
                {
                    string[] pedacos = linha.InnerHtml.Split('"');
                    //File.WriteAllText(Directory.GetCurrentDirectory() + "\\" + o + ".txt", pedacos[3]);
                    try
                    {
                        ze.DownloadFile(pedacos[3], Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\imagens\\temp.png");
                    }
                    catch(WebException ex)
                    {
                        ze.DownloadFile(pedacos[9], Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\imagens\\temp.png");
                    }
                    
                }
                else if (o == 7) //NOME
                {
                    string[] pedacos = linha.InnerHtml.Split('"');
                    //File.WriteAllText(Directory.GetCurrentDirectory() + "\\" + o + ".txt", pedacos[3]);
                    temp.nome = pedacos[3];
                    if(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\imagens\\" + pedacos[3] + ".png"))
                    {
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\imagens\\" + pedacos[3] + ".png");
                    }
                    File.Move(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\imagens\\temp.png", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\imagens\\" + pedacos[3] + ".png");
                    temp.imagem = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\imagens\\" + pedacos[3] + ".png";
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\imagens\\temp.png");
                    ze.DownloadFile(textBox.Text, (Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xfootball\\Emblemas\\" + nome.Text + ".png"));
                }
                else if(o == 9) //PONTUACAO
                {
                    string[] pedacos = linha.InnerHtml.Split('>');
                    File.WriteAllText(Directory.GetCurrentDirectory() + "\\" + o + ".txt", pedacos[1].Replace("</span>              ", "").Replace("</span", ""));
                    temp.pontuacao = Int32.Parse(pedacos[1].Replace("</span>              ", "").Replace("</span", ""));
                }
                else if (o == 13) //IDADE
                {
                    File.WriteAllText(Directory.GetCurrentDirectory() + "\\" + o + ".txt", linha.InnerHtml);
                    temp.idade = Int32.Parse(linha.InnerHtml);
                    //</span></a>  
                }
                else if(o == 15) //POSICAO
                {
                    string[] pedacos = linha.InnerHtml.Split('>');
                    File.WriteAllText(Directory.GetCurrentDirectory() + "\\" + o + ".txt", pedacos[2].Replace("</span></a>  ", "").Replace("</span", ""));
                    temp.posicao = pedacos[2].Replace("</span></a>  ", "").Replace("</span", "");
                    //</span></a>  
                }
                else if(o == 2)
                {
                    if(jatao11 == false)
                    {
                        temp.banco = false;
                    }
                    else
                    {
                        temp.banco = true;
                    }
                }
                o++;
                
            }
            return temp;
        }
    }
}
