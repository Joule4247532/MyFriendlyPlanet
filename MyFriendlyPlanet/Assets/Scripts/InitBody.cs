using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBody : MonoBehaviour
{
    public Rigidbody2D rb;


    void Awake()
    {
        rb.velocity = new Vector2(Random.Range(-20f,20f), Random.Range(-20f,20f));
    }

    
}
