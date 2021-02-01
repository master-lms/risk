using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoadingState : GameStateBase
{
    public GameLoadingState(string name) : base(name)
    {

    }

    public override void OnEnter(StateParameter parameters)
    {
        GameStateParam param = (GameStateParam)parameters;
        SceneManager.LoadSceneAsync(param.sceneName);
    }
    public override void OnExit(string name)
    {

    }
}
