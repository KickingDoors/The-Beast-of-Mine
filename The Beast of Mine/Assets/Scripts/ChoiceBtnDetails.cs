using UnityEngine;
using System.Collections;

public class ChoiceBtnDetails : MonoBehaviour {

	public string VarToActivate;
    public bool ShouldStopTimer = false;
    private TimerManager Tm;

    void Awake()
    {

        Tm = GameObject.Find("GameManager").GetComponent<TimerManager>();
    }

	public void UpdateActionTracker (){

        PlayerPrefs.SetInt(VarToActivate, 1);
        PlayerPrefs.Save();

        if(ShouldStopTimer == true)
            Tm.StopTimer();
    }
}