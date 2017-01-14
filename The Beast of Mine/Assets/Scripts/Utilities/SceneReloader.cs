using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader {

    public const string SCENE_RELOADED = "Scene_Reloaded";
    public static void loadScene(string sceneName)
    {
        PlayerPrefs.SetInt(SCENE_RELOADED, 1);
        SceneManager.LoadScene(sceneName);
    }
}
