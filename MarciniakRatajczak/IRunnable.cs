﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace MarciniakRatajczak
{
    interface IRunnable
    {
        void Run();
        IEnumerator <float> CoroutineUpdate();
        bool HasFinished { get;  }

    }

    
}
