using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum State
{
    NOT_EXECUTED,
    RUNNING,
    FAILURE,
    SUCCESS
}

public interface INode
{
    bool act(IAgent agent);
}
