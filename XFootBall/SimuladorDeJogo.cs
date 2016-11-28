using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFootBall
{
    class SimuladorDeJogo
    {
        
        public Resultado SimularJogo(Equipa equipa1, Equipa equipa2) // 
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
                Resultado temp = new Resultado();
                temp.vencedor = equipa1;
                temp.perdedor = equipa2;
                temp.golosVencedor = new Random().Next(2, 10);
                temp.golosPerdedor = new Random().Next(1, temp.golosVencedor);
                return temp;
                
            }
            else if (equipa1.Valor < equipa2.Valor)
            {
                Resultado temp = new Resultado();
                temp.vencedor = equipa2;
                temp.perdedor = equipa1;
                temp.golosVencedor = new Random().Next(2, 10);
                temp.golosPerdedor = new Random().Next(1, temp.golosVencedor);
                return temp;
            }
            else if (equipa1.Valor == equipa2.Valor)
            {
                Resultado temp = new Resultado();
                temp.vencedor = null;
                temp.perdedor = null;
                temp.golosVencedor = new Random().Next(10);
                temp.golosPerdedor = temp.golosVencedor;
                return temp;
            }

            else
            {
                return new Resultado();
            }
          }

    }
}
