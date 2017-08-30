using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

    public GameObject ball;
    public bool followBall;

    private Vector3 offsetPosition;

	void Start ()
    {
        offsetPosition = transform.position - ball.transform.position;
	}

	void FixedUpdate ()
    {
        transform.LookAt(ball.transform);
        
        if(followBall)
            transform.position = ball.transform.position + offsetPosition;
    }
}
