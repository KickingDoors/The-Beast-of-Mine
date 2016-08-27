using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CheckPoint_Event : MonoBehaviour {

    public int MsgNumberToSave;

    public void SaveGame()
    {
        PlayerPrefs.SetString("Saved_Level", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetString("Saved_Msg_Obj", this.transform.name);
        PlayerPrefs.SetInt("Saved_Msg_Number", MsgNumberToSave);
        print("Saved Game");
        PlayerPrefs.Save();
    }
}
