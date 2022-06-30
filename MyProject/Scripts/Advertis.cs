using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Advertis : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    private static int NumberDeath=-1;


    private void Start()
    {
        NumberDeath++;
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("4791147", false);
           
            if (Advertisement.IsReady("Interstitial_Android")&& NumberDeath%5==0)
            {
                ShowAd();
            }
            else {

                Debug.Log("Not Ready");
            }

        }
        else {

            Debug.Log(" No supported! ");


        }


    }

    public void ShowAd()
    {
        Advertisement.Show("Interstitial_Android");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        print("Реклама загружена ");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        print("Реклама не загружена "+ error.ToString());
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        print("Реклама  не показвывается "+error.ToString());
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Advertisement.Load("Interstitial_Android");
    }
}