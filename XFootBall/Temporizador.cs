using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XFootBall
{
    class Temporizador
    {
        private int segundos;
        private int minutos;
        private bool aContar = true;
        

        public bool isCounting()
        {
            return aContar;
        }

        public int getSegundos()
        {
            return segundos;
        }

        public void setSegundos(int novoSegundos)
        {
            segundos = novoSegundos;
        }

        public int getMinutos()
        {
            return segundos;
        }

        public void setMinutos(int novoMinutos)
        {
            minutos = novoMinutos;
        }

        public void start()
        {
            this.startTimer();
        }

        public void startTimer()
        {
            int i = 0;
            int oldI = 0;
            aContar = true;
            while(aContar == true)
            {
                i = DateTime.Now.Second;
                if(i != oldI)
                {
                    Console.WriteLine("{0} segundos", getSegundos());
                    setSegundos(getSegundos() + 1);
                    oldI = i;
                }
                if(segundos == 22)
                {
                    aContar = false;
                }
            }
        }

    }
}
