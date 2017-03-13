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
        private static List<IEnumerator<float>> Lista; 
        public const int ThreadCount = 30;
        public static int Iterator;
        // static Agent[] Agents = new Agent[ThreadCount];
        public static List<Agent> Agents;
        static void GenerateRunnables()
        {

            for (int i = 0; i <=ThreadCount; i++) 
            {
                
                if (i % 3 == 0) Agents.Add(new ConstantCountingAgent());
                else if (i % 3 == 1) Agents.Add(new CountingAgent());
                else if (i % 3 == 2) Agents.Add(new SineGeneratingAgent());
               
                
            }
            
        }
        static void RunThreads()
        {
            Thread[] Threads = new Thread[ThreadCount];
            for(int i = 0; i < ThreadCount; i++)
            {
                Threads[i] = new Thread(Agents[i].Run);
                Threads[i].Start();
            }

        }
        static void RunFibers()
        {
            foreach ( Agent i in Agents)
            {
                Lista.Add( i.CoroutineUpdate());
                

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
