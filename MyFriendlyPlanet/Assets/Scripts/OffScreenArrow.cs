using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffScreenArrow : MonoBehaviour
{
    public Transform Planet;
    public Transform Player;
    public Transform pointer;
    private float angle;
    bool isOffScreen = false;
    private Vector3 CappedPos;

    private void Update()
    {
        Vector3 dir = (Planet.position - (Camera.main.transform.position - new Vector3(0, 0, Camera.main.transform.position.z))).normalized;
        if (dir.x >= 0)
        {
            if (dir.y >= 0)
            {
                angle = Mathf.Rad2Deg * Mathf.Atan(dir.y / dir.x);
            }
            else
            {
                angle = (Mathf.Rad2Deg * Mathf.Atan(dir.y / dir.x));
            }
        }
        else
        {
            if (dir.y >= 0)
            {
                angle = 180 + (Mathf.Rad2Deg * Mathf.Atan(dir.y / dir.x));
            }
            else
            {
                angle = 180 + (Mathf.Rad2Deg * Mathf.Atan(dir.y / dir.x));
            }
        }

        pointer.localEulerAngles = new Vector3(0, 0, angle - 90);

        isOffScreen = Camera.main.WorldToScreenPoint(Planet.transform.position).x <= 0 || Camera.main.WorldToScreenPoint(Planet.transform.position).x >= Screen.width || Camera.main.WorldToScreenPoint(Planet.transform.position).y <= 0 || Camera.main.WorldToScreenPoint(Planet.transform.position).y >= Screen.height;

        if (isOffScreen)
        {
            pointer.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            pointer.position = ReturnPos();
        }
        else
        {
            pointer.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        
    }

    private Vector3 ReturnPos()
    {
        Vector3 pointerPos = Player.position - Planet.position;
        pointerPos = pointerPos * -1;
        float zoom = FindObjectOfType<FollowPlayer>().zoom;

        return new Vector3(Mathf.Clamp(pointerPos.x, -49 * (zoom / 30), 49 * (zoom / 30)), Mathf.Clamp(pointerPos.y, -27 * (zoom / 30), 27 * (zoom / 30)),1) + Player.position;
    }
}
