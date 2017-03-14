using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace MarciniakRatajczak
{
    class Program
    {
        private static List<IEnumerator<float>> Lista= new List<IEnumerator<float>>(); 
        
        
        // static Agent[] Agents = new Agent[ThreadCount];
        public static List<Agent> Agents=new List<Agent>();
        static void GenerateRunnables()
        {

            for (int i = 1; i <31; i++) 
            {
                
                if (i % 3 == 0) Agents.Add(new ConstantCountingAgent());
                else if (i % 3 == 1) Agents.Add(new CountingAgent());
                else if (i % 3 == 2) Agents.Add(new SineGeneratingAgent());
               
                
            }
           
            
        }
        static void RunThreads()
        {
            List<Thread> Threads = new List<Thread>();
            
            foreach(Agent Agent in Agents)
            {
                Threads.Add(new Thread(Agent.Run));
                
            }
           foreach(Thread Thread in Threads)
            {
                Thread.Start();
            }

        }
        static void RunFibers()
        {
            
            foreach ( Agent Agent in Agents)
            {
                Lista.Add(Agent.CoroutineUpdate());
                

            }

            foreach(IEnumerator<float> j in Lista)
            {
                j.MoveNext();
                
                Thread.Sleep(100);
            }   
        }

        static void Main(string[] args)
        {
            
            GenerateRunnables();
            //RunThreads();
            RunFibers();
            Console.ReadKey();
        }
    }
}
