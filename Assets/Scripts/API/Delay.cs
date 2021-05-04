using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/**
 * @brief Utilisé pour attendre avant de refaire une action
 */
class Delay<T> : INode
    where T : INode
{
    private T instance;

    public DateTime StartAt;
    public int delay;

    public Delay(T instance, int delay)
    {
        StartAt = DateTime.Now;
        this.instance = instance;
        this.delay = delay; // delay en millisecondes
    }

    public State act()
    {
        DateTime EndAt = DateTime.Now;

        TimeSpan tmElapsed = EndAt - StartAt;
        float elapsedTime = (float)Math.Round(tmElapsed.TotalSeconds, 0, MidpointRounding.ToEven);
        if (elapsedTime < delay) {
            return State.SUCCESS;
        } else {
            StartAt = DateTime.Now;
            return instance.act(); ;
        }
    }
}

