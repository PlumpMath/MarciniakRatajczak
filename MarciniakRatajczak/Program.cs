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
        private static bool AllFinished=false;
        private static int IloscAgentow = 30;
        private static List<IEnumerator<float>> Lista= new List<IEnumerator<float>>(); 
        private static List<IRunnable> Agents=new List<IRunnable>();
        static void GenerateRunnables()
        {
            for (int i = 0; i <IloscAgentow/3; i++) 
            {
                Agents.Add(new ConstantCountingAgent());
                Agents.Add(new CountingAgent());
                Agents.Add(new SineGeneratingAgent());
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
            while (!Agents.All(a => a.HasFinished))
            {
                
                foreach (IEnumerator<float> Enumerator in Lista)
                {
                    Enumerator.MoveNext();
                    
                }
               
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
