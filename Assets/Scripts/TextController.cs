using TMPro;
using UnityEngine;
using System;
using System.Collections.Generic;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI slot1;
    public TextMeshProUGUI slot2;
    public TextMeshProUGUI slot3;

    public PlayerCollect inventoryPlayer;

    public void updateInventory()
    {
        List<string> itens = inventoryPlayer.inventory;

        slot1.text = "";
        slot2.text = "";
        slot3.text = "";
        
        for (int i = 0; i < itens.Count && i < 3; i++)
        {
            
            string itemName = itens[i];
            switch (i)
            {
                case 0:
                    slot1.text = itemName;
                    break;
                case 1:
                    slot2.text = itemName;
                    break;
                case 2:
                    slot3.text = itemName;
                    break;
            }
        }
    }
}