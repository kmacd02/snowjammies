using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private float xMove = 0;
    private float yMove = 0;

    private float speed = 5;

    private Rigidbody2D rb;

    public string heldItem = "";

    [SerializeField] CombiningItems combiner;

    private GameObject collidedObject = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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

    private void OnPickUp(/*Collider2D collision*/)
    {
        if (collidedObject == null)
            return;

        BoxCollider2D collision = collidedObject.GetComponent<BoxCollider2D>();
        if(heldItem == "" && collision.gameObject.CompareTag("Item"))
        {
            //TODO: Display held item in UI

            //Set heldItem to Item's name
            heldItem = collision.gameObject.GetComponent<Item>().ItemName;
            //Destroy game object
            Destroy(collision.gameObject);

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

        if(heldItem != "" && collision.gameObject.CompareTag("TrashCan"))
        {
            heldItem = "";
            //TODO: Put item back where it was
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collidedObject = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collidedObject = null;
    }
}