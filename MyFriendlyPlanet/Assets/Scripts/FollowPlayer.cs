using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform Player;
    public Camera cam;
    public float smoothSpeed = 0.3f;
    public float zoom = 20f;
    private float step = 2f;

    private void FixedUpdate()
    {
        transform.position = Player.position + new Vector3(0,0,-1);
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && zoom <= 30f)
        {
            zoom += step;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && zoom >= 10f)
        {
            zoom -= step;
        }

        cam.orthographicSize = zoom;
    }
}
