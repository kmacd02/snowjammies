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

    private void OnPickUp(Collider2D collision)
    {
        if(heldItem == "" && collision.gameObject.CompareTag("Item"))
        {
            //TODO: Display held item in UI

            //Set heldItem to Item's name
            heldItem = collision.gameObject.name;
            //Destroy game object
            Destroy(collision.gameObject);
        }

        if(heldItem != "" && collision.gameObject.CompareTag("Workspace"))
        {
            //Reset heldItem
            heldItem = "";
            //TODO: Create item game object in workspace

        }
    }
}
