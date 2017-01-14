using System;
using UnityEngine;

public class MiniGameState : StateMachineBehaviour {
    public string miniGameScriptName;
    private GameObject miniGame;
    void OnStateEnter()
    {
        miniGame = new GameObject("miniGame");
        miniGame.AddComponent(Type.GetType(miniGameScriptName));
    }

    void OnStateExit()
    {
        Destroy(miniGame);
    }
}
