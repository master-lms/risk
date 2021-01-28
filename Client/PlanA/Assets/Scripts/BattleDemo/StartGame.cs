using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : StateMachine
{
    public override void Init()
    {
        base.Init();
        InitState();
    }

    public override void Update(float dt)
    {
        base.Update(dt);
    }

    private void InitState()
    {
        StateInstant("enter", new GameLoadingState("enter"));
        StateInstant("loading", new GameLoadingState("loading"));
    }
}
