using UnityEngine;

public class RaioVfxManager : MonoBehaviour, ObserverPattern.Observer  {

    private const float MIN_LIGHTNING_SOUND_TIME = 4;
    private const float MAX_LIGHTNING_SOUND_TIME = 8;
    private float nextLightningSoundTime;
    private float currentTime = 0;
    private const string RAIN_VFX = "rain";
    private const string LIGHTNING_TRIGGER_NAME = "Raio";
    private GameObject raio;
    private Animator raioAnimator;
    private bool isEnabled = false;
    public void OnNotify(string eventName)
    {
        if (eventName == RAIN_VFX)
        {
            if (!raio)
            {
                raio = (GameObject)Instantiate(Resources.Load("prefabs/Raio/Raio", typeof(GameObject)));
                raio.transform.SetParent(GameObject.Find("Canvas").transform, false);
                raioAnimator = raio.GetComponent<Animator>();
            }
            generateNextLightningSoundTime(); // generate next time we must trigger the lightning sound
            isEnabled = true;
        } else
        {
            isEnabled = false;
            raioAnimator.ResetTrigger(LIGHTNING_TRIGGER_NAME); // avoid triggering lightning sound if the rain VFX is not currently displayed
        }
    }

    /**
     * Trigger a lightning sound if the current VFX is Rain and if we reached the lightning sound  time
     */
    public void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        if (isEnabled && currentTime >= nextLightningSoundTime)
        {
            raioAnimator.SetTrigger(LIGHTNING_TRIGGER_NAME);
            generateNextLightningSoundTime();
        }
    }

    /**
     * Compute when we must trigger the next lightning sound
     */
    private void generateNextLightningSoundTime()
    {
        currentTime = 0;
        nextLightningSoundTime = Random.Range(MIN_LIGHTNING_SOUND_TIME, MAX_LIGHTNING_SOUND_TIME);
    }
}
