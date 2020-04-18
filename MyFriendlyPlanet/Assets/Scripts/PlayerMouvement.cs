using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public Rigidbody2D rb;
    float moveH;
    float moveV;
    public float speed;
    public float terminalVel;
    private Vector2 force;

    // Update is called once per frame
    void FixedUpdate()
    {
        moveH = Input.GetAxis("Horizontal") * speed;
        moveV = Input.GetAxis("Vertical") * speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveH = 2 * moveH;
            moveV = 2 * moveV;
        }

        force = new Vector2(moveH, moveV);
        force = force + (-terminalVel * rb.velocity);

        rb.AddForce(force);
    }
}
