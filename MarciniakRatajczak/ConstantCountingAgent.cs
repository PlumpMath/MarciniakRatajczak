using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarciniakRatajczak
{
    class ConstantCountingAgent : Agent
    {
        private int ID;
        private int counter=0;
        public ConstantCountingAgent()
        {
            id++;
            ID = id;
            HasFinished = false;
        }
        public override void Update()
        {
            if (counter == 10)
            {
                Console.WriteLine("Constant Countig Agent ID={0}", ID);
                HasFinished = true;
            }
            else counter++;
            
        }
    }
}
