using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script
{
    public class IAgent
    {
        public float viewRadius;
        [Range(0,180)]
        public float viewAngle;

        public void moveTo(Vector3 target)
        {

        }
        public bool Dectection() {

            return false;
        }
        public void Fire() {
            //play animation
        }

    }
}
