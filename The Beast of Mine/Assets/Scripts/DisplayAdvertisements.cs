using UnityEngine;
using UnityEngine.Advertisements;

public class DisplayAdvertisements : MonoBehaviour
{

    private bool HasShownAds = false;

    public void Update()
    {
        if(HasShownAds == false)
            ShowAd();
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
            HasShownAds = true;
        }
    }
}