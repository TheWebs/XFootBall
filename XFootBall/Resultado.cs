using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFootBall
{
    class Resultado
    {
        public int golosVencedor { get; set; } //mais a frente vira lista com nomes de jogadores autores de golos
        public int golosPerdedor { get; set; }
        public Equipa vencedor { get; set; }
        public Equipa perdedor { get; set; }

        
    }
}
