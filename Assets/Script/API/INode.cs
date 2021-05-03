using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


interface INode
{
    public enum states
    {
        Not_Executed,
        Running,
        Failure,
        Success

    };

    bool act(IAgent agent);
}
