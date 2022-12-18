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
<<<<<<< HEAD
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
                
=======
                Debug.Log("F burn the house down");
                mover.status = 1;
            }
            else if (item1 == "blowtorch" || item2 == "blowtorch")
            {
                Debug.Log("F burn the house down");
                mover.status = 1;
>>>>>>> parent of 6501abe (Merge branch 'main' of https://github.com/kmacd02/snowjammies)
            }
            else if (item1 == "laptop" || item2 == "laptop")
            {
                Debug.Log("W");
<<<<<<< HEAD
                GameOverManager.bgNum = 0;
                mover.flavorTextNum = 2;
=======
>>>>>>> parent of 6501abe (Merge branch 'main' of https://github.com/kmacd02/snowjammies)
                mover.status = 1;
                
            }
            else if (item1 == "toaster" || item2 == "toaster")
            {
                Debug.Log("N");
<<<<<<< HEAD
                mover.flavorTextNum = 3;
                mover.status = 2;
                
=======
                mover.status = 0;
>>>>>>> parent of 6501abe (Merge branch 'main' of https://github.com/kmacd02/snowjammies)
            }
            else if (item1 == "fork" || item2 == "fork")
            {
                Debug.Log("N");
<<<<<<< HEAD
                mover.flavorTextNum = 4;
                mover.status = 2;
                
=======
                mover.status = 0;
>>>>>>> parent of 6501abe (Merge branch 'main' of https://github.com/kmacd02/snowjammies)
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
<<<<<<< HEAD
                GameOverManager.bgNum = 2;
                mover.flavorTextNum = 5;
=======
>>>>>>> parent of 6501abe (Merge branch 'main' of https://github.com/kmacd02/snowjammies)
                mover.status = 1;
                
            }
            else if (item1 == "laptop" || item2 == "laptop")
            {
                Debug.Log("W");
<<<<<<< HEAD
                GameOverManager.bgNum = 0;
                mover.flavorTextNum = 6;
=======
>>>>>>> parent of 6501abe (Merge branch 'main' of https://github.com/kmacd02/snowjammies)
                mover.status = 1;
                
            }
            else if (item1 == "toaster" || item2 == "toaster")
            {
                Debug.Log("W");
<<<<<<< HEAD
                GameOverManager.bgNum = 0;
                mover.flavorTextNum = 7;
=======
>>>>>>> parent of 6501abe (Merge branch 'main' of https://github.com/kmacd02/snowjammies)
                mover.status = 1;
                
            }
            else if (item1 == "fork" || item2 == "fork")
            {
                Debug.Log("N");
<<<<<<< HEAD
                mover.flavorTextNum = 8;
                mover.status = 2;
                
=======
                mover.status = 0;
>>>>>>> parent of 6501abe (Merge branch 'main' of https://github.com/kmacd02/snowjammies)
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
<<<<<<< HEAD
                GameOverManager.bgNum = 3;
                mover.flavorTextNum = 9;
=======
>>>>>>> parent of 6501abe (Merge branch 'main' of https://github.com/kmacd02/snowjammies)
                mover.status = 1;
            }
            else if (item1 == "toaster" || item2 == "toaster")
            {
                Debug.Log("N toaster melts - burnt toast reference?");
<<<<<<< HEAD
                mover.flavorTextNum = 10;
                mover.status = 2;
=======
                mover.status = 0;
>>>>>>> parent of 6501abe (Merge branch 'main' of https://github.com/kmacd02/snowjammies)
            }
            else if (item1 == "fork" || item2 == "fork")
            {
                Debug.Log("W");
<<<<<<< HEAD
                GameOverManager.bgNum = 6;
                mover.flavorTextNum = 11;
=======
>>>>>>> parent of 6501abe (Merge branch 'main' of https://github.com/kmacd02/snowjammies)
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
<<<<<<< HEAD
                GameOverManager.bgNum = 4;
                mover.flavorTextNum = 12;
=======
>>>>>>> parent of 6501abe (Merge branch 'main' of https://github.com/kmacd02/snowjammies)
                mover.status = 1;
            }
            else if (item1 == "fork" || item2 == "fork")
            {
                Debug.Log("N Stab the screen with the fork. Laptop breaks.");
<<<<<<< HEAD
                mover.flavorTextNum = 13;
                mover.status = 2;
=======
                mover.status = 0;
>>>>>>> parent of 6501abe (Merge branch 'main' of https://github.com/kmacd02/snowjammies)
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
<<<<<<< HEAD
                GameOverManager.bgNum = 5;
                mover.flavorTextNum = 14;
=======
>>>>>>> parent of 6501abe (Merge branch 'main' of https://github.com/kmacd02/snowjammies)
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
