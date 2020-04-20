using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeMixer : MonoBehaviour
{
    public GameObject Tab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Tab"))
        {
            ToggleTab();
        }
    }

    void ToggleTab()
    {
        Tab.SetActive(!Tab.activeSelf);
        GetComponent<Image>().enabled = !GetComponent<Image>().enabled;
    }
}
