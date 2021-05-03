using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface INode
{
    public enum states
    {
        Not_Executed,
        Running,
        Failure,
        Success

    };

    public bool act(IAgent agent);
}
