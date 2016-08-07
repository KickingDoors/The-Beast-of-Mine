using UnityEngine;
using System.Collections;

public class TimerEvent : MonoBehaviour {

    public int Seconds;
    public MsgManager MsgToReturnTo;
    public int MsgNumber;
    private bool HasRun = false;

	public void StartTimer()
    {
        if (HasRun == false)
        {
            GameObject.Find("GameManager").GetComponent<TimerManager>().StartTimer(Seconds, MsgToReturnTo, MsgNumber);
            HasRun = true;
        }
    }
}
