using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarciniakRatajczak
{
    class SineGeneratingAgent : Agent
    {
        private double SinVal;
        private int ID;
        private int counter = 0;
        public SineGeneratingAgent()
        {
            id++;
            ID = id;
            HasFinished = false;
        }
        public override void Update()
        {
            SinVal = Math.Sin(counter);
            if (counter == ID % 10)
            {
                Console.WriteLine("Sin Output:{0}", SinVal);
                HasFinished = true;
            }
            else
            {
                counter++;

            }
           
        }
    }
}
