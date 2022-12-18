using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkspaceItemDisplayer : MonoBehaviour
{
    public string itemName = "";
    public string oldItem = "";

    [SerializeField] private Sprite[] items;
    [SerializeField] SpriteRenderer renderer;

    void Update()
    {
        if (itemName != oldItem)
        {
            if (itemName == "")
            {
                renderer.sprite = null;
            }
            else if (itemName == "blanket")
            {
                renderer.sprite = items[0];
            }
            else if (itemName == "candle")
            {
                renderer.sprite = items[1];
            }
            else if (itemName == "blowtorch")
            {
                renderer.sprite = items[2];
            }
            else if (itemName == "laptop")
            {
                renderer.sprite = items[3];
            }
            else if (itemName == "toaster")
            {
                renderer.sprite = items[4];
            }            
            else if(itemName == "fork")
            {
                renderer.sprite = items[5];
            }
            else
            {
                Debug.Log("unrecognized item: " + itemName);
            }
            oldItem = itemName;
        }        
    }
}
