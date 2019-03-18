using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private static UIManager _instance;
    public static UIManager UIinstance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UI manager is null");
            }
            return _instance;
        }
    }

    public Text playerGemCountText;

    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = "" + gemCount + "G";
    }

    private void Awake()
    {
        _instance = this;
    }
}
