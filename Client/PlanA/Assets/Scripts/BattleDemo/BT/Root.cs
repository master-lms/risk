using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Root : Node
{
    private Node childNode; 
    public StatesBT Enter()
    {
        childNode = null;
        return StatesBT.SUCCESS;
    }

    public Node SetChild(Node node)
    {
        this.childNode = node;
        return this;
    }

    public override void SetContext(string name)
    {
        base.SetContext(name);
        if (childNode != null)
        {
            childNode.SetContext(name);
        }
    }

    public override void Reset()
    {
        base.Reset();
        childNode.Reset();
    }

    public override void Destroy()
    {
        base.Destroy();
    }

    public override StatesBT Update(float dt, int steps)
    {
        if (childNode != null)
        {
            return StatesBT.FAIURE;
        }

        return states;
    }
}
