using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;

namespace Assets.Script.API
{
    interface IAction
    {
        bool verify(IAgent agent);
        void update(IAgent agent);
    }
}