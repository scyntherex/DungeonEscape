using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour {
    public void ShowRewardedAd()
    {
        Debug.Log("Showing Rewarded Ad.");

        //Check if ad is ready
        //Show(rewardedVideo)

        if(Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions {
                resultCallback = HandleShowResult
            };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    void HandleShowResult(ShowResult result)
    {
        switch(result)
        {
            case ShowResult.Finished:
                //award 100 gems
                break;
            case ShowResult.Skipped:
                Debug.Log("Skipped ad yields no reward.");
                break;
            case ShowResult.Failed:
                Debug.Log("Video no ready");
                break;
        }
    }
}
