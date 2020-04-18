using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleType : MonoBehaviour
{
    public GameObject sun;
    public GameObject blackHole;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            sun.SetActive(false);
            blackHole.SetActive(true);
        }
        else
        {
            sun.SetActive(true);
            blackHole.SetActive(false);
        }
    }
}
