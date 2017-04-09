using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace MarciniakRatajczak
{
    class HigherLevelSumAgent : Agent
    {
        private int ID;
        private int Sum;
        private List<IRunnable> Agents;
        public HigherLevelSumAgent()
        {
            id++;
            ID = id;
            Agents = Program._Agents;
        }
        public override void Update()
        {
            
            Thread.Sleep(Program.sleepTime*300);
            
            if (Agents.Where(a=>a.GetType()==typeof(SumAgent)).All (a => a.HasFinished))
            {
                
                
                foreach (  SumAgent Agent in Agents.Where(a=>a.GetType()==typeof(SumAgent)) )
                {
                    
                    Sum += Agent.Sum;
                    
                }
                HasFinished = true;
                Console.WriteLine("HigherLevelSumAgent ID:{0}={1}", ID, Sum);
            }
        }
    }
}
