using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour {

    public void ShowRewardedAd()
    {
        Debug.Log("Showing Rewarded Ad.");

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
                //award 100 diamonds
                GameManager.Instance.Player.AddGems(100);
                UIManager.UIinstance.OpenShop(GameManager.Instance.
                    Player.Gems);
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
