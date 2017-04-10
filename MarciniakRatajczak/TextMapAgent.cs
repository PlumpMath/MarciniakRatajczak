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
        int iterator=0;
        List<string> Strings;
        int textLength;
        Dictionary<string, int> Dict = new Dictionary<string, int>();
        public TextMapAgent(int nr)
        {
            
            ID = ++id;
            Strings = SplitAgent._Strings;
            textLength = SplitAgent.textLength;
            iterator = nr * textLength / Program.iAgents;
           
        }
        public override void Update()
        {

            if (Dict.ContainsKey(Strings[iterator]) == true)
            {
                Dict[Strings[iterator]]++;

            }
            else
            {
                Dict.Add(Strings[iterator], 1);
            }
            iterator++;
        }
    }
}
