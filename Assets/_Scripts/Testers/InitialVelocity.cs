using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialVelocity : MonoBehaviour
{
    public Vector3 initialVelocity, angularVelocity;

    public float magnusConstant = 1f;

    private Rigidbody _rigidbody;

    private Vector3 startPostition;
    private float startTime;

    public float shotDistance; // meters
    public float speed;

    private bool isHit;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        ShotReset();
    }

    /// <summary>
    /// A new shot
    /// </summary>
    private void ShotReset()
    {
        startPostition = transform.position;
    }

    /// <summary>
    /// When the ball is hit
    /// </summary>
    public void Hit()
    {
        Debug.Log("Shot Begin");

        startTime = Time.time;

        _rigidbody.velocity = initialVelocity;
        _rigidbody.angularVelocity = angularVelocity;

        isHit = true;
    }

    /// <summary>
    /// When the ball stop rolling
    /// </summary>
    private void ShotEnd()
    {
        Debug.Log("Shot End");
        isHit = false;
        ShotReset();
    }

    private void FixedUpdate()
    {
        if (isHit && _rigidbody.velocity.magnitude > 0.05f)
        {
            _rigidbody.AddForce(magnusConstant * Vector3.Cross(_rigidbody.angularVelocity, _rigidbody.velocity));

            shotDistance = Vector3.Distance(startPostition, transform.position);
            speed = shotDistance / (Time.time - startTime);
        }
        else if (isHit)
        {
            ShotEnd();
        }
    }
}