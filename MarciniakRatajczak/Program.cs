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
        public const int sleepTime = 0;
        private static int iAgents = 4;
        static int iRandoms = 1000;
        private static Random rnd = new Random();
        private static List<IEnumerator<float>> Lista = new List<IEnumerator<float>>();
        

        private readonly static List<IRunnable> Agents = new List<IRunnable>();
        public static List<IRunnable> _Agents { get { return Agents; } }

        private readonly static List<int> RandomNumbers = new List<int>();
        public static List<int> _RandomNumbers { get { return RandomNumbers; } }
        
        
        static void GenerateRunnables()
        {

            //Agents to count words in text
            Agents.Add(new SplitAgent());
            

            /*  //Agents to add numbers in list
            for (int i = 0; i < iRandoms; i++)
            {
                RandomNumbers.Add(rnd.Next(0, 100));
            }

            for (int i = 0; i < iAgents; i++)
            {
                Agents.Add(new SumAgent( i * iRandoms/iAgents, i * iRandoms/iAgents + iRandoms/iAgents));
            }

            Agents.Add(new HigherLevelSumAgent());
            */

            /*// Agents to test threads and coroutines
            for (int i = 0; i <IloscAgentow/3; i++) 
            {
                Agents.Add(new ConstantCountingAgent());
                Agents.Add(new CountingAgent());
                Agents.Add(new SineGeneratingAgent());
            }
            */
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
               
                Thread.Sleep(Program.sleepTime);
              
                    
                
            }
        }
    
        static void Main(string[] args)
        {
            
            GenerateRunnables();
            
            RunThreads();
            
           
            //RunFibers();
            Console.ReadKey();
        }
    }
}
