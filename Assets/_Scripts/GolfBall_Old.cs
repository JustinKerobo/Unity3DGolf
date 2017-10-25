using UnityEngine;
using System.Collections;

public class GolfBall_Old : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Variables")]
    public float launchSpeed = 160;
    public float laynchAngleV = 20;
    public float launchAngleH = 0;
    public float altitude = 30;
    public float backSpin = 3000;
    public float sideSpin = 0;

    [Header("Results")]
    public float totalDistance;
    public float carryDistance;
    public float height;
    public float total_backSpin;
    public float total_sideSpin;
    public float time;

    public Vector3 landingZone;

    [Header("Real Time")]
    public Vector3 startPos;
    public float curSpeed;

	void Awake ()
    {
        rb = GetComponent<Rigidbody>();

        float y = rb.mass;

        rb.AddRelativeForce(0, 10, 10, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //if (shotInProcess && ballSpeed < 0.009)
        //{
        //    // stop ball from rolling
        //    rb.angularDrag = 100f;
        //    endPosDist = transform.position;
        //    shotDist = (startPosDist - endPosDist).magnitude;

        //    shotComplete = true;
        //    shotInProcess = false;
        //}

        curSpeed = rb.velocity.magnitude;

        if (curSpeed < 1.5f && curSpeed > 0)
            rb.isKinematic = true;


        totalDistance = Vector3.Distance(startPos, transform.position);

    }
}
