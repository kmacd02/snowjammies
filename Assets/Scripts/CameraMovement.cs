using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    private float xMove = 0;
    private float yMove = 0;

    private float speed = 5;

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
}
