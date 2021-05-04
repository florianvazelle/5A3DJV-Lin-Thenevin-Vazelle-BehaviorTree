using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Différent état que l'on peut rencontrer pour une INode
/// </summary>
public enum State
{
    NOT_EXECUTED,
    RUNNING,
    FAILURE,
    SUCCESS
}

/// <summary>
/// Interface INode qui permet de représenter toute les actions du BehaviorTree
/// </summary>
public interface INode
{
    /// <summary>
    /// Action de notre INode
    /// </summary>
    /// <returns>
    /// Retorune l'état de l'INode
    /// </returns>
    State act();
}
