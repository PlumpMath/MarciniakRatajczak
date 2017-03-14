using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace MarciniakRatajczak
{
    abstract class Agent : IRunnable<Agent>
    {
        public IEnumerator<float> a;
        public static int id;
        public void Run()
        {
            while(!HasFinished)
            {
                Update();
                Thread.Sleep(100);
            }
        }
        public abstract void Update(); 
        
        public IEnumerator <float> CoroutineUpdate()
        {
            while (!HasFinished)
            {
                Update();
                yield return 0;
            }
                     
        }

       
        public bool HasFinished { get; protected set; }
    }
}
