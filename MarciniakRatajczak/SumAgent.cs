using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarciniakRatajczak
{
    class SumAgent : Agent
    {
        private int ID;
        public int Sum;
        private int range;
        private int iterator;
        private List<int> numbers;
        public SumAgent( int _start, int _range)
        {
            id++;
            ID = id;
            iterator = _start;
            range = _range;


            numbers = Program._RandomNumbers;
        }
        public override void Update()
        {
            Sum += numbers[iterator];
            iterator++;
            if (iterator == range - 1)
            {
                HasFinished = true;
                Console.WriteLine("SumAgent:{0}={1}",ID, Sum);
            }
        }
    }
}
