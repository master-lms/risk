using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public bool Network = false;
    public bool FPS = false;

    private GameObject gui;
    StartGame startGame = null;
    public void Start()
    {
        gui = GameObject.Find("GUI");
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(gui);

        startGame = new StartGame();
        startGame.Init();

        GameStateParam gameStateParam = new GameStateParam();
        gameStateParam.sceneName = "Battle";
        startGame.ChangeState("loading", gameStateParam);
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame != null)
        {
            startGame.Update(Time.deltaTime);
        }
    }
}
