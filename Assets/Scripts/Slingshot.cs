using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject launcher;

    private bool isAiming;
    private float sphereRadius;

    public GameObject prefabCannonball;
    public GameObject activeCannonball;
    public float speedMultiplier = 10.0f; 
    // Start is called before the first frame update
    void Start()
    {
        launcher.SetActive(false);
        isAiming = false;
        sphereRadius = this.GetComponent<SphereCollider>().radius;
        activeCannonball = null;
    }

    private void OnMouseEnter()
    {
        launcher.SetActive(true);
    }

    private void OnMouseExit()
    {
        launcher.SetActive(false);
    }

    private void OnMouseDown()
    {
        isAiming = true;
        activeCannonball = Instantiate(prefabCannonball) as GameObject;
        activeCannonball.transform.position = launcher.transform.position;
        activeCannonball.GetComponent<Rigidbody>().isKinematic = true; 
    }
    // Update is called once per frame
    void Update()
    {
        if (!isAiming)
            return;

        Vector3 mousePositionScreen = Input.mousePosition;
        mousePositionScreen.z = -Camera.main.transform.position.z;
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);
        Vector3 dragVector = mousePositionWorld - launcher.transform.position;

        if (dragVector.magnitude > sphereRadius)
        {
            dragVector.Normalize();
            dragVector *= sphereRadius;
        }

        activeCannonball.transform.position = launcher.transform.position + dragVector;

        if (Input.GetMouseButtonUp(0))
        {
            isAiming = false;
            Rigidbody rb = activeCannonball.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.velocity = -dragVector * speedMultiplier;

            GameObject cam = GameObject.Find("Main Camera");
            cam.GetComponent<FollowTarget>().targetObject = activeCannonball;
        }
    }
}
