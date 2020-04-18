using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBody : MonoBehaviour
{
    public GameObject obj;


    void Awake()
    {
        float randomScale = Random.Range(0.2f, 0.5f);
        obj.transform.localScale = new Vector3(randomScale, randomScale, 1);
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-20f,20f), Random.Range(-20f,20f));
    }

    
}
