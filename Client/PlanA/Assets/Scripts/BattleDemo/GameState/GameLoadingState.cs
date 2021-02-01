using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoadingState : GameStateBase
{
    private AsyncOperation asyncOperation;
    private GameStateParam param;
    public GameLoadingState(string name) : base(name)
    {

    }

    public override void OnEnter(StateParameter parameters)
    {
        base.OnEnter(parameters);
        param = (GameStateParam)parameters;
        if (!string.IsNullOrEmpty(param.sceneName))
        {
            asyncOperation = SceneManager.LoadSceneAsync(param.sceneName);
        }
    }

    public override void OnUpdate(float dt)
    {
        base.OnUpdate(dt);
        if (asyncOperation!= null && asyncOperation.isDone && !string.IsNullOrEmpty(param.nextState))
        {
            object[] obj = new object[] { param.nextState, param };
            EventListenerManager.Instance.Fire(EventListernerEnum.EVENT_CHANGE_STATE, obj);
        }
    }

    public override void OnExit(string name)
    {

    }
}
