using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

    public GameObject ball;
    private Vector3 offset;

	void Start ()
    {
        offset = transform.position - ball.transform.position;
	}

	void FixedUpdate ()
    {
        transform.LookAt(ball.transform);
        transform.position = ball.transform.position + offset;
        // if ball has gone passed the pin
        // then reset the ball offset to the oppisite way
    }
}
