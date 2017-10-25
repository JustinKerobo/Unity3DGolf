using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSimulation : MonoBehaviour
{
    public Transform landing;
    public Transform vertexObject;
    public Transform projectile;
    
    public Vector3 startPos;

    [Header("Variables")]
    [Tooltip("Degrees")]
    public float angle = 45.0f;
    [Tooltip("KM/H")]
    public float speed = 300;
    private const float gravity = -9.8f;


    [Header("Results")]
    public float distance;
    public float time;

    private float Vx, Vy;
    public Vector2 vertex;

    //private void Awake()
    //{
    //    float Sv = speed * Mathf.Sin(angle);
    //    float Sh = speed * Mathf.Cos(angle);

    //    vertexObject.position = new Vector3(0, Sh, Sv);

    //    time = (2 * Sv) / gravity;
    //    distance = Sh * time;

    //    landing.position = new Vector3(0, 0, distance);
    //}


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(SimulateProjectile());
            StartCoroutine(SimulateProjectile());
        }

        float Sv = speed * Mathf.Sin(angle);
        float Sh = speed * Mathf.Cos(angle);

        time = (2 * Sv) / Sh;
        distance = Sh * time;

        // Calculate distance to target
        //targetDistance = Vector3.Distance(startPos, target.position);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        //velocity = distance / (Mathf.Sin(2 * angle * Mathf.Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity
        //Vx = Mathf.Sqrt(velocity) * Mathf.Cos(angle * Mathf.Deg2Rad);
        //Vy = Mathf.Sqrt(velocity) * Mathf.Sin(angle * Mathf.Deg2Rad);
        Vx = Sv;
        Vy = Sh;
        vertex = new Vector2(Vx, Vy);

        vertexObject.position = new Vector3(0, Vx, Vy);
        landing.position = new Vector3(0, 0, distance);


        // Calculate flight time.
        //time = distance / Vx;

        // Rotate projectile to face the target.
        projectile.rotation = Quaternion.LookRotation(landing.position - projectile.position);
    }

    IEnumerator SimulateProjectile()
    {
        float elapse_time = 0;

        // Move projectile to the position of throwing object + add some offset if needed.
        projectile.position = Vector3.zero;

        while (elapse_time < time)
        {
            projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;
            yield return null;
        }
    }
}
