using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateParam : StateParameter
{
    public string sceneName;
    public string nextState;
}

public class GameStateBase : StateBase
{
    public GameStateBase(string name) : base(name)
    {

    }
}
