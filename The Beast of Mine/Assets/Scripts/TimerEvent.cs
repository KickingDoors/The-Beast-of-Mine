using UnityEngine;
using System.Collections;

public class TimerEvent : MonoBehaviour {

    public int Seconds;
    private bool HasRun = false;

	public void StartTimer()
    {
        if (HasRun == false)
        {
            GameObject.Find("GameManager").GetComponent<TimerManager>().StartTimer(Seconds);
            HasRun = true;
        }
    }
}
