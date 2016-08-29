using UnityEngine;
using System.Collections;

public class TimerManager : MonoBehaviour {

    private IEnumerator Co;

    public void StartTimer(int Time)
    {
        Co = Timer(Time);
        StartCoroutine(Co);
    }

    public void StopTimer()
    {
        StopCoroutine(Co);
        print("Stopped Timer");
    }

    IEnumerator Timer ( int Time )
    {
        for( int i = Time; i >= 0; i--)
        {
            yield return new WaitForSeconds(1);
            print("Timer : " + i);
        }

        GameObject.Find("GameManager").GetComponent<GameManager>().Die();
    }
}
