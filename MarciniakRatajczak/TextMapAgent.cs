using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarciniakRatajczak
{
    class TextMapAgent : Agent
    {

        int ID;
        List<string[]> Strings = new List<string[]>();

        public TextMapAgent()
        {
            ID = ++id;

        }
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
