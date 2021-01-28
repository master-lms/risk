using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoadingState : StateBase
{
    public GameLoadingState(string name) : base(name)
    {

    }

    public override void OnEnter(StateParameter parameters)
    {
        SceneManager.LoadSceneAsync("Battle");
    }
    public override void OnExit(string name)
    {

    }
}
