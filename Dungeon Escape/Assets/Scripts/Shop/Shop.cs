using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public GameObject shopPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                UIManager.UIinstance.OpenShop(player.Gems);
            }

            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        //switch between item
        switch(item)
        {
            case 0: //0 = flame sword
                UIManager.UIinstance.UpdateShopSelection(62);
                break;
            case 1: //1 = boots of flight
                UIManager.UIinstance.UpdateShopSelection(-38);
                break;
            case 2: //2 = castle key
                UIManager.UIinstance.UpdateShopSelection(-153);
                break;
        }
    }
}
