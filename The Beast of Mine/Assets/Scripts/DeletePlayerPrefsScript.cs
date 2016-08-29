using UnityEngine;
using System.Collections;

public class DeletePlayerPrefsScript : MonoBehaviour {

    public void DeleteLocalFiles()
    {

        PlayerPrefs.DeleteAll();
    }
}
