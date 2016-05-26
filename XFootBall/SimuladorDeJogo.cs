using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFootBall
{
    class SimuladorDeJogo
    {
        
        public Equipa SimularJogo(Equipa equipa1, Equipa equipa2) // 
        {
            //CALCULO DO VALOR DE CADA EQUIPA --------------------
            foreach(jogador jogador in equipa1.Jogadores)
            {
                if(jogador.banco != true)
                {
                    equipa1.Valor += jogador.pontuacao;
                }
            }
            foreach(jogador jogador in equipa2.Jogadores)
            {
                if(jogador.banco != true)
                {
                    equipa2.Valor += jogador.pontuacao;
                }
            }
            //FIM CALCULO DO VALOR DE CADA EQUIPA

            if (equipa1.Valor > equipa2.Valor)
            {
                return equipa1;
                
            }
            else if (equipa1.Valor < equipa2.Valor)
            {
                return equipa2;
            }
            else if (equipa1.Valor == equipa2.Valor)
            {
                Equipa temp = new Equipa();
                temp.Nome = "EMPATE";
                return temp;
                    }

            else
            {
                return new Equipa();
            }
          }

    }
}
