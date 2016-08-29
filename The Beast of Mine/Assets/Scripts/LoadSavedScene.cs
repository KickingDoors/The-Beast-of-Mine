using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSavedScene : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (PlayerPrefs.HasKey("Saved_Level"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("Saved_Level"));
        }
        else
        {
            SceneManager.LoadScene("Chapter1");
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "LoadingScreen")
        {

            if (PlayerPrefs.HasKey("Saved_Msg_Obj"))
            {
                MsgManager[] AllMsgManagers = Object.FindObjectsOfType<MsgManager>();
                string SavedMsg = PlayerPrefs.GetString("Saved_Msg_Obj");

                for (int i = 0; i < AllMsgManagers.Length; i++)
                {
                    if (AllMsgManagers[i].transform.name == SavedMsg)
                    {
                        AllMsgManagers[i].enabled = true;
                        AllMsgManagers[i].curMsg = PlayerPrefs.GetInt("Saved_Msg_Number");
                    }
                    else
                    {
                        AllMsgManagers[i].enabled = false;
                        AllMsgManagers[i].StopCoroutine("WriteMsg");
                    }
                }

                Destroy(this.gameObject);
            }
        }
    }
}