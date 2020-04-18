using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public Rigidbody2D rb;
    private float mass;
    public bool isPlayer;

    private void FixedUpdate()
    {
        Attractor[] attractors = FindObjectsOfType<Attractor>();

        foreach (Attractor attractor in attractors)
        {
            if (attractor != this && !attractor.isPlayer)
                Attract(attractor);
        }
    }

    void Attract (Attractor objToAttract)
    {
        if (isPlayer)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                mass = rb.mass * 10;
            }
            else
            {
                mass = rb.mass;
            }
        }
        else
        {
            mass = rb.mass;
        }

        Rigidbody2D rbToAttract = objToAttract.rb;

        Vector2 dir = rb.position - rbToAttract.position;
        float dist = dir.magnitude * 150.24f;

        float forceMag = (mass * rbToAttract.mass) / Mathf.Pow(dist, 2);
        Vector2 force = dir.normalized * forceMag * 20;
        rbToAttract.AddForce(force);
    }
}
