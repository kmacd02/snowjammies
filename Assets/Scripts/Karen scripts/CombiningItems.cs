using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombiningItems : MonoBehaviour
{
    [SerializeField] private string item1 = "";
    [SerializeField] private string item2 = "";



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
    // if its the second item, combines it with the first item
    //**************************************************
    public void addItem(string itemName)
    {
        List<string> list = new List<string> { "blanket", "candle", "blowtorch", "laptop", "toaster", "fork"};
        if (!list.Contains(itemName))
        {
            Debug.Log("itemName is not a valid item");
        }
        else
        {
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
    }


    //************************************
    //returns true if item is at workstation
    //************************************
    public bool itemIsUsed(string itemName)
    {
        if (itemName == item1 || itemName == item2)
        {
            return true;
        }
        return false;
    }


    //**************************************************
    //combines items (after adding both items via addItem)
    //**************************************************
    private void combineItems()
    {
        if (item1 == "blanket" || item2 == "blanket")
        {
            if (item1 == "candle" || item2 == "candle")
            {
                Debug.Log("F burn the house down");
            }
            else if (item1 == "blowtorch" || item2 == "blowtorch")
            {
                Debug.Log("F burn the house down");
            }
            else if (item1 == "laptop" || item2 == "laptop")
            {
                Debug.Log("W");
            }
            else if (item1 == "toaster" || item2 == "toaster")
            {
                Debug.Log("N");
            }
            else if (item1 == "fork" || item2 == "fork")
            {
                Debug.Log("N");
            }
            else
            {
                Debug.Log(item1 + " and " + item2 + " are an invalid combination");
            }
        }
        else if (item1 == "candle" || item2 == "candle")
        {
            if (item1 == "blowtorch" || item2 == "blowtorch")
            {
                Debug.Log("raise the chicken from the dead");
            }
            else if (item1 == "laptop" || item2 == "laptop")
            {
                Debug.Log("W");
            }
            else if (item1 == "toaster" || item2 == "toaster")
            {
                Debug.Log("W");
            }
            else if (item1 == "fork" || item2 == "fork")
            {
                Debug.Log("N");
            }
            else
            {
                Debug.Log(item1 + " and " + item2 + " are an invalid combination");
            }
        }
        else if (item1 == "blowtorch" || item2 == "blowtorch")
        {
            if (item1 == "laptop" || item2 == "laptop")
            {
                Debug.Log("F summons CS bro who tells you heat is bad for laptop performance (rants and you run out of time)");
            }
            else if (item1 == "toaster" || item2 == "toaster")
            {
                Debug.Log("N toaster melts - burnt toast reference?");
            }
            else if (item1 == "fork" || item2 == "fork")
            {
                Debug.Log("W");
            }
            else
            {
                Debug.Log(item1 + " and " + item2 + " are an invalid combination");
            }
        }
        else if (item1 == "laptop" || item2 == "laptop")
        {
            if (item1 == "toaster" || item2 == "toaster")
            {
                Debug.Log("F Start playing Burnt ToaSt");
            }
            else if (item1 == "fork" || item2 == "fork")
            {
                Debug.Log("N Stab the screen with the fork. Laptop breaks.");
            }
            else
            {
                Debug.Log(item1 + " and " + item2 + " are an invalid combination");
            }
        }
        else if (item1 == "toaster" || item2 == "toaster")
        {
            if (item1 == "fork" || item2 == "fork")
            {
                Debug.Log("F - Atomic bomb - mushroom cloud gif");
            }
            else
            {
                Debug.Log(item1 + " and " + item2 + " are an invalid combination");
            }
        }
        else
        {
            Debug.Log(item1 + " and " + item2 + " are an invalid combination");
        }
        //Todo: check combinations
        reset();
    }
}
