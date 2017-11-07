using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour {

    public enum hands {Left, Right};
    public OVRInput.Controller controllerLeft;
    public OVRInput.Controller controllerRight;

    public Rigidbody bulletrb;
    public float firingSpeed;
    public GameObject bulletType;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Fire(hands leftOrRight)
    {
        Vector3 location;
        Quaternion rotation;

        if (leftOrRight == hands.Left)
        {
            location = OVRInput.GetLocalControllerPosition(controllerLeft);
            rotation = OVRInput.GetLocalControllerRotation(controllerRight);
        }
        else
        {
            location = OVRInput.GetLocalControllerPosition(controllerRight);
            rotation = OVRInput.GetLocalControllerRotation(controllerRight);
        }

        GameObject bullet = Instantiate(bulletType) as GameObject;
        bullet.transform.position = location;
        bullet.transform.rotation = rotation;
        bulletrb = bullet.GetComponent<Rigidbody>();
        bulletrb.AddForce(transform.forward * firingSpeed);
    }
}
