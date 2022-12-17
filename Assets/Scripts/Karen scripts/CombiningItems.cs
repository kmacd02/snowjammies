using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombiningItems : MonoBehaviour
{
    [SerializeField] private string item1 = "";
    [SerializeField] private string item2 = "";

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }


    //**************************************************
    //resets items (trash items, may need to replace items at their locations)
    //**************************************************
    public void reset()
    {
        item1 = "";
        item2 = "";
    }

    //TODO: change if items are updated
    //**************************************************
    //adds itemName item to whichever item is free
    //also checks if it is a valid itemName
    //**************************************************
    public void addItem(string itemName)
    {
        List<string> list = new List<string> { "blanket", "candle", "blowtorch", "laptop", "toaster", "fork"};
        if (!list.Contains(itemName))
        {
            Debug.Log("itemName is not a valid item");
        }
        if(item1 == "")
        {
            item1 = itemName;
        }
        else
        {
            item2 = itemName;
        }
        if(item1 != "" && item2 != "")
        {
            combineItems();
        }
    }


    //**************************************************
    //combines items (after adding both items via addItem)
    //**************************************************
    private void combineItems()
    {
        //Todo: check combinations
        reset();
    }
}
