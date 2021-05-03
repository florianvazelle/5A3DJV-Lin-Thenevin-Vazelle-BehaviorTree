using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script
{
    interface IAgent
    {
        void moveTo(Vector3 target);
        bool Dectection();
        void Fire();
    }
}
