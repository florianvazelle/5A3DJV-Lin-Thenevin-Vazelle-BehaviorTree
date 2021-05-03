using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.API
{
    class AlwaysFalse : IAction
    {
        public bool verify(IAgent agent)
        {
            return false;
        }

        public void update(IAgent agent)
        {
            
        }

    }
}
