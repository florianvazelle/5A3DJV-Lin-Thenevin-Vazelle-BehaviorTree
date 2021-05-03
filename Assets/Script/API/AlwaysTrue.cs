using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.API
{
    class AlwaysTrue : IAction
    {
        public bool verify(IAgent)
        {
            return true;

        }
    }
}
