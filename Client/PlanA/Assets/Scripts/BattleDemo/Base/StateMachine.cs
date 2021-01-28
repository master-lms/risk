using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateType
{
    public const string EEEEEEEEEEE = "";
}

public class StateParameter
{
    public string id = "";
}

public abstract class StateMachine
{
    private StateBase curState;
    private string nextStateName;
    private StateParameter nextParameters;
    Dictionary<string, StateBase> states = new Dictionary<string, StateBase>();

    public virtual void Init() { }

    public virtual void Update(float dt)
    {
        if (!string.IsNullOrEmpty(nextStateName))
        {
            DoChangeState(nextStateName, nextParameters);
            nextStateName = null;
            nextParameters = null;
        }

        if (curState != null)
        {
            curState.OnUpdate(dt);
        }
    } 

    /// <summary>
    /// 立即切换根据当前状态是否切换成功
    /// </summary>
    /// <param name="name"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public bool ChangeStateImmediate(string name, StateParameter parameters)
    {
        if (ChangeState(name, parameters))
        {
            return DoChangeState(name, parameters);
        }
        return false;
    }

    public virtual bool ChangeState(string name, StateParameter parameters)
    {
        bool isChange = true;
        if (curState != null)
            isChange = curState.CanChangeTo(name, parameters);
    
        if (isChange)
        {
            nextParameters = parameters;
            nextStateName = name;
        }

        return isChange;
    }

    public virtual bool DoChangeState(string name, StateParameter parameters)
    {
        if (string.IsNullOrEmpty(name) || !states.ContainsKey(name))
        {
            Debug.LogError("Error : C# StataMachine, states is exist， state name = " + name);
            return false;
        }

        StateBase stateBase = states[name];
    
        // 退出
        if (curState != null)
            curState.OnExit(name);

        curState = stateBase;
        curState.OnEnter(parameters);
        return true;
    }


    public StateBase GetCurState()
    {
        return curState;
    }

    public string GetNextState()
    {
        return nextStateName;
    }

    public void StateInstant(string name, StateBase stateBase)
    {
        states.Add(name, stateBase);
    }
}
