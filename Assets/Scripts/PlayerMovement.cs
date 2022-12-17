using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private float xMove = 0;
    private float yMove = 0;

    private float speed = 5;

    public string heldItem = "";
    private Vector3 heldItemPosition = Vector3.zero;

    [SerializeField] CombiningItems combiner;
    [SerializeField] GameObject blanket;
    [SerializeField] GameObject candle;
    [SerializeField] GameObject blowtorch;
    [SerializeField] GameObject laptop;
    [SerializeField] GameObject toaster;
    [SerializeField] GameObject fork;

    private GameObject collidedObject = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += (new Vector3(xMove, yMove, 0)) * Time.deltaTime * speed;
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        xMove = movementVector.x;
        yMove = movementVector.y;
    }

    private void OnPickUp()
    {
        if (collidedObject == null)
            return;

        BoxCollider2D collision = collidedObject.GetComponent<BoxCollider2D>();
        if(heldItem == "" && collision.gameObject.CompareTag("Item"))
        {
            //TODO: Display held item in UI

            //Set heldItem to Item's name
            heldItem = collision.gameObject.GetComponent<Item>().ItemName;
            // Save heldItem's location
            heldItemPosition = collision.gameObject.transform.position;
            //Destroy game object
            Destroy(collision.gameObject);
            collidedObject = null;

            Debug.Log(heldItem);
        }

        if(heldItem != "" && collision.gameObject.CompareTag("Workspace"))
        {
            //TODO: Create item game object in workspace — set off some flag!
            combiner.addItem(heldItem);
            //Reset heldItem
            heldItem = "";
        }
        else if (collision.gameObject.CompareTag("Workspace"))
        {
            combiner.reset();
        }
    }

    private void OnResetItem()
    {
        if (heldItem != "")
        {
            switch (heldItem)
            {
                case "blanket":
                    Instantiate(blanket, heldItemPosition, Quaternion.identity);
                    break;
                case "candle":
                    Instantiate(candle, heldItemPosition, Quaternion.identity);
                    break;
                case "blowtorch":
                    Instantiate(blowtorch, heldItemPosition, Quaternion.identity);
                    break;
                case "laptop":
                    Instantiate(laptop, heldItemPosition, Quaternion.identity);
                    break;
                case "toaster":
                    Instantiate(toaster, heldItemPosition, Quaternion.identity);
                    break;
                case "fork":
                    Instantiate(fork, heldItemPosition, Quaternion.identity);
                    break;
            }

            heldItem = "";
            heldItemPosition = Vector3.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collidedObject = collision.gameObject;
        Debug.Log("on trigger enter");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collidedObject = null;
        Debug.Log("on trigger exit");
    }
}