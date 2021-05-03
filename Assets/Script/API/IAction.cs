using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;

interface IAction
{
    bool verify() { return false; }
    void update() { }

}
