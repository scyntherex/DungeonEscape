using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public GameObject shopPanel;

    //variable for current item selected.
    public int itemSelected;
    public int selectedCost;

    private Player player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            player = other.GetComponent<Player>();
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
            UIManager.UIinstance.UpdateGemCount(player.Gems);
        }
    }

    public void SelectItem(int item)
    {
        //switch between item
        switch(item)
        {
            case 0: //0 = flame sword
                UIManager.UIinstance.UpdateShopSelection(62);
                itemSelected = 0;
                selectedCost = 200;
                break;
            case 1: //1 = boots of flight
                UIManager.UIinstance.UpdateShopSelection(-38);
                itemSelected = 1;
                selectedCost = 400;
                break;
            case 2: //2 = castle key
                UIManager.UIinstance.UpdateShopSelection(-153);
                itemSelected = 2;
                selectedCost = 100;
                break;
        }
    }

    //BuyItem  method

    
    
    public void BuyItem()
    {
        //check if player gems is >= item cost.
        if (player.Gems >= selectedCost)
        {
            if(itemSelected == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }
            //if it is, award item (subtract cost from player's gems.
            player.Gems -= selectedCost;
            //Debug.Log("Purcahsed: " + itemSelected + ". " + player.Gems 
            //    + " remaining.");
            UIManager.UIinstance.UpdateGemCount(player.Gems);
            shopPanel.SetActive(false);
        }
        else
        {
            //else close shop
            Debug.Log("Not enough gems!");
            shopPanel.SetActive(false);
        }
    }
}
