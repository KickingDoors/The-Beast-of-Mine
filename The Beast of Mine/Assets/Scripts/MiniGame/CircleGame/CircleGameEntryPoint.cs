using UnityEngine;

public class CircleGameEntryPoint : MonoBehaviour {

    private GameObject miniGameManager;
    void Start () {
        miniGameManager = new GameObject("miniGameManager");
        miniGameManager.AddComponent<CircleGame.GameManager>();
        miniGameManager.AddComponent<CircleGame.CircleGenerator>();
        // set the mini game manager as child of the mini game so that it will be removed also when destroying the mini game
        miniGameManager.transform.SetParent(GameObject.Find("miniGame").transform);
    }
	
	void Update () {
		
	}
}
