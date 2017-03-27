using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarciniakRatajczak
{
    class SumAgent : Agent
    {
        protected long Sum;
        private int zakres;
        private int ID;
        int i;
        public int poziom;
        List<int> Lista = new List<int>();
        public SumAgent(List<int> lista, int start, int range, int level)
        {
            id++;
            ID = id;
            Lista = lista;
            zakres = range;
            i = start;
            poziom = level;
        }
        public override void Update()
        {
            switch (poziom)
            {
                case 1:
                    Sum += Lista[i];
                    i++;
                    if (i == zakres - 1)
                    {
                    HasFinished = true;
                    Console.WriteLine(Sum);
                    }
                    break;
                case 2:
                    
                    
                    break;
            }
        }
    }
}
