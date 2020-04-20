using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        if ((player.position - this.transform.position).x > 57.6 || (player.position - this.transform.position).x < -57.6)
        {
            float deltaX = player.position.x - this.transform.position.x;
            if (deltaX < 0)
            {
                this.transform.position = new Vector3(this.transform.position.x - 115.2f, this.transform.position.y, 1);
            }
            else
            {
                this.transform.position = new Vector3(this.transform.position.x + 115.2f, this.transform.position.y, 1);
            }
        }
        if ((player.position - this.transform.position).y > 32.4 || (player.position - this.transform.position).y < -32.4)
        {
            float deltaY = player.position.y - this.transform.position.y;
            if (deltaY < 0)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 64.8f, 1);
            }
            else
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 64.8f, 1);
            }
        }
    }
}
