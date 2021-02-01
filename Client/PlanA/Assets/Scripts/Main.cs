using UnityEngine;

public class Main : MonoBehaviour
{
    public bool Network = false;
    public bool FPS = false;

    private GameObject gui;
    private StartGame startGame = null;
    public void Start()
    {
        gui = GameObject.Find("GUI");
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(gui);

        startGame = new StartGame();
        startGame.Init();

        EventListenerManager.Instance.Subscribe(EventListernerEnum.EVENT_CHANGE_STATE, ChangeGameState);

        GameStateParam gameStateParam = new GameStateParam();
        gameStateParam.sceneName = "Battle";
        gameStateParam.nextState = GameStateEnum.Battle;
        startGame.ChangeState(GameStateEnum.Loading, gameStateParam);
    }

    private void Update()
    {
        if (startGame != null)
        {
            startGame.Update(Time.deltaTime);
        }
    }

    public void ChangeGameState(object o)
    {
        object[] objs = o as object[];
        string name = objs[0] as string;
        GameStateParam gameState = objs[0] as GameStateParam;
        if (!string.IsNullOrEmpty(name))
        {
            startGame.ChangeState(name, gameState);
        }
    }
}
