using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarciniakRatajczak
{
    class CountingAgent : Agent
    {
        private int ID;
        private int counter=0;
        public CountingAgent()
        {
            id++;
            ID = id;
            HasFinished = false;
        }
        public override void Update()
        {
            if (counter == ID)
            {
                Console.WriteLine("Counting Agent ID={0}", ID);
                HasFinished = true;
            }

            else counter++;
        }
    }
}
