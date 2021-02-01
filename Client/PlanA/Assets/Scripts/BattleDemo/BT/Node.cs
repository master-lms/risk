using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatesBT 
{
    /// <summary>
    ///  成功
    /// </summary>
    SUCCESS = 1,

    /// <summary>
    /// 失败
    /// </summary>
    FAIURE = 2,

    /// <summary>
    /// 执行中
    /// </summary>
    RUNNING = 3,
}


public abstract class Node
{
    public string name;
    public StatesBT states;

    public virtual void SetContext(string name)
    {
        this.name = name;
    }

    public virtual void Destroy()
    {

    }

    public virtual void Reset()
    {

    }

    public virtual StatesBT Update(float dt, int steps)
    {
        return this.states;
    }

    public virtual bool IsCondition()
    {
        return false;
    }

    public virtual bool IsAction()
    {
        return false;
    }

    public virtual bool IsComposite()
    {
        return false;
    }
}
