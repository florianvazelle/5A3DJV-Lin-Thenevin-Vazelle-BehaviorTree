using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Delay<T> : INode
    where T : INode
{
    private T instance;

    public DateTime StartAt;

    public Delay(T instance)
    {
        StartAt = DateTime.Now;
        this.instance = instance;
    }

    public State act()
    {
        DateTime EndAt = DateTime.Now;

        TimeSpan tmElapsed = EndAt - StartAt;
        float elapsedTime = (float)Math.Round(tmElapsed.TotalSeconds, 0, MidpointRounding.ToEven);
        Debug.Log(elapsedTime);
        if (elapsedTime < 2) {
            return State.SUCCESS;
        } else {
            StartAt = DateTime.Now;
            return instance.act(); ;
        }
    }
}

