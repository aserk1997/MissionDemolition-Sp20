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
    // Update is called once per frame
    void Update()
    {
        
    }
}
