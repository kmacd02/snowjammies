using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    private float xMove = 0;
    private float yMove = 0;

    private float speed = 5;

    private bool infoOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        this.infoOpen = gameObject.transform.parent.GetChild(1).GetComponent<PlayerMovement>().infoOpen;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.infoOpen = gameObject.transform.parent.GetChild(1).GetComponent<PlayerMovement>().infoOpen;

        if (!infoOpen)
        {
            transform.position = new Vector3(gameObject.transform.parent.GetChild(1).transform.position.x, gameObject.transform.parent.GetChild(1).transform.position.y, -10);
        }
    }

    /*
    private void OnMove(InputValue movementValue)
    {
        if (infoOpen)
            return;

        Vector2 movementVector = movementValue.Get<Vector2>();

        xMove = movementVector.x;
        yMove = movementVector.y;
    }
    */
}
