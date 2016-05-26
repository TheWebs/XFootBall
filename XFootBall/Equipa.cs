using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFootBall
{
    public class Equipa
    {
        public string Nome { get; set; }
        public int Id { get; set; }
        public string Emblema { get; set; }
        public int Divisao { get; set; }
        public int Valor { get; set; }
        public int HabituacaoTatica { get; set; }
        public List<jogador> Jogadores = new List<jogador> { };

    }
}
