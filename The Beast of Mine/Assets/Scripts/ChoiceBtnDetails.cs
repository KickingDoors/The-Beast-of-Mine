using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;

public class ChoiceBtnDetails : MonoBehaviour {

    private string jsonString;
	public string VarToActivate;
    private JsonData ActionData;
    public bool ShouldStopTimer = false;
    private TimerManager Tm;

    void Awake()
    {

        Tm = GameObject.Find("GameManager").GetComponent<TimerManager>();
    }

	public void UpdateActionTracker (){

        if (VarToActivate != "")
        {
            jsonString = File.ReadAllText(Application.dataPath + "/Resources/ActionTracker.json");
            ActionData = JsonMapper.ToObject(jsonString);

            ActionData[VarToActivate] = true;
        }

        if(ShouldStopTimer == true)
            Tm.StopTimer();
    }
}