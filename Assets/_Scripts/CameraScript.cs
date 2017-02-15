using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

    public GameObject ball;
    private Vector3 offset;

    GolfBall gb;

	void Start ()
    {
        gb = GameObject.FindGameObjectWithTag("GolfBall").GetComponent<GolfBall>();

        offset = transform.position - ball.transform.position;
	}

	void Update ()
    {
        //if (gb.readyToHit)
        //{
        //    transform.LookAt(gb.target);

        //    // if ball has gone passed the pin
        //    // then reset the ball offset to the oppisite way
            

        //}
        //else
        //{
        //    transform.position = ball.transform.position + offset;
        //}
            
	}
}
