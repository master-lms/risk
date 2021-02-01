using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateEnum
{
    public const string Enter = "Enter";
    public const string Loading = "Loading";
    public const string Empty = "Empty";
    public const string Battle = "Battle";
}

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
        StateInstant(GameStateEnum.Enter, new GameEnterState(GameStateEnum.Enter));         // 进入
        StateInstant(GameStateEnum.Loading, new GameLoadingState(GameStateEnum.Loading));   // 加载
        StateInstant(GameStateEnum.Empty, new GameEmptyState(GameStateEnum.Empty));         // 空
        StateInstant(GameStateEnum.Battle, new GameBattleState(GameStateEnum.Battle));      // 战斗
    }
}
