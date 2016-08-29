using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    public bool Paused = false;
    public Canvas PauseMenu;

	public void Die()
    {
        SceneManager.LoadScene("LoadingScreen");
        //LoadLast Checkpoint
    }

    public void OpenMenu()
    {
        PauseMenu.enabled = true;
        Time.timeScale = 0;
    }

    public void CloseMenu()
    {
        PauseMenu.enabled = false;
        Time.timeScale = 1;
    }
}