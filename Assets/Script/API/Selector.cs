﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sequence = System.Collections.Generic.List<IAction>;

class Selector : IComparator
{
    bool act(IAgent agent) { return false; }
}
