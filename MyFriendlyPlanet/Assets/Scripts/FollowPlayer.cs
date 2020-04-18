using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 15f;
    public Vector3 deltaPosition;
    public float lookUp = 2f;
    public float Y = 0.5f;
    private float amount = 0.0f;

    // Update is called once per frame
    void FixedUpdate ()
    {
        Vector3 playerV = new Vector3(player.position.x, player.position.y + lookUp, player.position.z);
        Vector3 desiredPos = player.position + deltaPosition;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        smoothedPos = new Vector3(smoothedPos.x, desiredPos.y, desiredPos.z);
        transform.position = smoothedPos;
        transform.Translate(0, amount, amount);

        transform.LookAt(playerV);
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && amount <= 1)
        {
            amount += Y;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && amount >= -2)
        {
            amount -= Y;
        }
    }
}
