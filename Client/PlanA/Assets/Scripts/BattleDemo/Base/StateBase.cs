using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase
{
    protected string name;

    public StateBase(string name)
    {
        this.name = name;
    }

    public virtual void OnEnter(StateParameter parameters)
    {
        Debug.Log("STETE BASE =" + name);
    }

    public virtual bool CanChangeTo(string nextName, StateParameter parameters)
    {
        return true;
    }

    public virtual void OnUpdate(float dt)
    {

    }

    public virtual void OnExit(string nextName)
    {

    }
}
