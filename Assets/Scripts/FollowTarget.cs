using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject targetObject;
    private Vector3 initialPosition;

    public GameObject ground;
    private Vector3 groundPosition;

    public float easing = 0.05f; 

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = this.transform.position;
        groundPosition = ground.transform.position;
    }

    // Update is called once per frame
    // FixedUpdate to sync with physics
    void FixedUpdate()
    {
        Vector3 targetPosition;

        if (targetObject != null &&
            targetObject.GetComponent<Rigidbody>().velocity.magnitude < 0.01)
            targetObject = null;

        if (targetObject == null)
            targetPosition = initialPosition;
        else
            targetPosition = targetObject.transform.position;

        Vector3 followPosition = Vector3.Lerp(this.transform.position, targetPosition, easing);

        //limit x & y position of the camera
        if (followPosition.x < initialPosition.x)
            followPosition.x = initialPosition.x;

        if (followPosition.y < initialPosition.y)
            followPosition.y = initialPosition.y;

        followPosition.z = initialPosition.z;

        this.transform.position = followPosition;
        //zoom camera to follow cannonball
        this.GetComponent<Camera>().orthographicSize = followPosition.y - groundPosition.y; 
    }
}
