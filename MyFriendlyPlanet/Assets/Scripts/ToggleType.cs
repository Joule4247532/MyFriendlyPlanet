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
