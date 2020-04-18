using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = new Vector2(0f, 9f);
    }

    
}
