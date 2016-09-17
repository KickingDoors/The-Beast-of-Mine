using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using SmartLocalization;

public class GameManager : MonoBehaviour {

    public bool Paused = false;
    public Canvas PauseMenu;
    public Text LanguageBtn_Txt;

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


    public void ChangeLanguage()
    {
        if (LanguageManager.Instance.LoadedLanguage == "pt-BR")
        {
            LanguageManager.Instance.ChangeLanguage("en-US");
            PlayerPrefs.SetString("Language", "en-US");
            LanguageBtn_Txt.text = "EN";
        }
        else
        {
            LanguageManager.Instance.ChangeLanguage("pt-BR");
            PlayerPrefs.SetString("Language", "pt-BR");
            LanguageBtn_Txt.text = "PT";
        }

        PlayerPrefs.Save();
    }


    void Start()
    {

        string Lang = PlayerPrefs.GetString("Language");

        if (Lang == "en-US")
        {
            LanguageManager.Instance.ChangeLanguage("en-US");
            LanguageBtn_Txt.text = "EN";
        }
        else if (Lang == "pt-BR")
        {
            LanguageManager.Instance.ChangeLanguage("pt-BR");
            LanguageBtn_Txt.text = "PT";
        }
    }
}