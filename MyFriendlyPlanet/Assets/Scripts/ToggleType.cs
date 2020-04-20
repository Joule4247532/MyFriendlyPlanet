using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleType : MonoBehaviour
{
    public GameObject sun;
    public GameObject blackHole;
    public bool activeBH = false;

    private void FixedUpdate()
    {
        if (!FindObjectOfType<GameManager>().gameOver)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                sun.SetActive(false);
                blackHole.SetActive(true);
                activeBH = true;
            }
            else
            {
                sun.SetActive(true);
                blackHole.SetActive(false);
                activeBH = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Planet")
        {
            
            FindObjectOfType<GameManager>().gameOver = true;
            if (activeBH)
            {
                FindObjectOfType<AudioManager>().Play("BH");
                FindObjectOfType<GameManager>().causeOfGG = "A black hole has\neaten the planet";
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("Burn");
                FindObjectOfType<GameManager>().causeOfGG = "The sun is a\ntraitor!";
            }
            Destroy(collision.gameObject);
        }
    }
}
