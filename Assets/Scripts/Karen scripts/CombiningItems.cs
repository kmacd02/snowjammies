using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombiningItems : MonoBehaviour
{
    public string item1 = "";
    public string item2 = "";
    [SerializeField] GameManager mover;


    //**************************************************
    //resets items (trash items, may need to replace items at their locations)
    //**************************************************
    //TODO: put items back
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
                Debug.Log("N");
                //GameOverManager.bgNum = 1;
                mover.flavorTextNum = 0;
                mover.status = 2;
                
            }
            else if (item1 == "blowtorch" || item2 == "blowtorch")
            {
                Debug.Log("F - burn the house down");
                GameOverManager.bgNum = 1;
                mover.flavorTextNum = 1;
                mover.status = 1;
                
            }
            else if (item1 == "laptop" || item2 == "laptop")
            {
                Debug.Log("W");
                GameOverManager.bgNum = 0;
                mover.flavorTextNum = 2;
                mover.status = 1;
                
            }
            else if (item1 == "toaster" || item2 == "toaster")
            {
                Debug.Log("N");
                mover.flavorTextNum = 3;
                mover.status = 2;
                
            }
            else if (item1 == "fork" || item2 == "fork")
            {
                Debug.Log("N");
                mover.flavorTextNum = 4;
                mover.status = 2;
                
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
                Debug.Log("F raise the chicken from the dead");
                GameOverManager.bgNum = 2;
                mover.flavorTextNum = 5;
                mover.status = 1;
                
            }
            else if (item1 == "laptop" || item2 == "laptop")
            {
                Debug.Log("W");
                GameOverManager.bgNum = 0;
                mover.flavorTextNum = 6;
                mover.status = 1;
                
            }
            else if (item1 == "toaster" || item2 == "toaster")
            {
                Debug.Log("W");
                GameOverManager.bgNum = 0;
                mover.flavorTextNum = 7;
                mover.status = 1;
                
            }
            else if (item1 == "fork" || item2 == "fork")
            {
                Debug.Log("N");
                mover.flavorTextNum = 8;
                mover.status = 2;
                
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
                GameOverManager.bgNum = 3;
                mover.flavorTextNum = 9;
                mover.status = 1;
            }
            else if (item1 == "toaster" || item2 == "toaster")
            {
                Debug.Log("N toaster melts - burnt toast reference?");
                mover.flavorTextNum = 10;
                mover.status = 2;
            }
            else if (item1 == "fork" || item2 == "fork")
            {
                Debug.Log("W");
                GameOverManager.bgNum = 6;
                mover.flavorTextNum = 11;
                mover.status = 1;
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
                GameOverManager.bgNum = 4;
                mover.flavorTextNum = 12;
                mover.status = 1;
            }
            else if (item1 == "fork" || item2 == "fork")
            {
                Debug.Log("N Stab the screen with the fork. Laptop breaks.");
                mover.flavorTextNum = 13;
                mover.status = 2;
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
                GameOverManager.bgNum = 5;
                mover.flavorTextNum = 14;
                mover.status = 1;
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
