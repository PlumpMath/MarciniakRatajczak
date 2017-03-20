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
        private static int ID;
        public SumAgent(int range)
        {
            id++;
            ID = id;
            zakres = range;

        }
        public override void Update()
        {
            while (!HasFinished)
            {

            }
        }
    }
}
