using UnityEngine;
using System.Collections;

public class AimCamera : MonoBehaviour
{
    Camera cam;
    public GameObject target;
    bool isActive;
    Vector3 worldPos;

    void Start ()
    {
        cam = GetComponent<Camera>();
    }

	void Update ()
    {        
        if (cam.enabled == true)
        {
            worldPos = ScreenToWorld(Input.mousePosition);
            
            if(Input.GetMouseButton(1))
            {
                target.transform.position = worldPos;
                Debug.DrawLine(transform.position, worldPos, Color.red);
            }                        
        }
        else
        {
            isActive = false;
        }
	}

    void SpawnTarget()
    {
        Instantiate(target, worldPos, transform.rotation);
        isActive = true;     
    }

    Vector3 ScreenToWorld(Vector2 screenPos)
    {
        // Create a ray going into the scene starting 
        // from the screen position provided 
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        RaycastHit hit;

        // ray hit an object, return intersection point
        if (Physics.Raycast(ray, out hit))
            return hit.point;

        // ray didn't hit any solid object, so return the 
        // intersection point between the ray and 
        // the Y=0 plane (horizontal plane)
        float t = -ray.origin.y / ray.direction.y;
        return ray.GetPoint(t);
    }
}
