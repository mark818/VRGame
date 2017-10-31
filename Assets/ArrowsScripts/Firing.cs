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
        if (leftOrRight == hands.Left)
        {
            Vector3 LeftLocation = OVRInput.GetLocalControllerPosition(controllerLeft);
            Quaternion LeftRotation = OVRInput.GetLocalControllerRotation(controllerRight);

            GameObject bullet = Instantiate(bulletType) as GameObject;
            bullet.transform.position = LeftLocation;
            bullet.transform.rotation = LeftRotation;
            bullet.AddComponent<Rigidbody>();
            bulletrb = bullet.GetComponent<Rigidbody>();
            bulletrb.AddForce(transform.forward * firingSpeed);

        

        }

        if (leftOrRight == hands.Right)
        {
            Vector3 RightLocation = OVRInput.GetLocalControllerPosition(controllerRight);
            Quaternion RightRotation = OVRInput.GetLocalControllerRotation(controllerRight);

            GameObject bullet = Instantiate(bulletType) as GameObject;
            bullet.transform.position = RightLocation;
            bullet.transform.rotation = RightRotation;
            bullet.AddComponent<Rigidbody>();
            bulletrb = bullet.GetComponent<Rigidbody>();
            bulletrb.AddForce(transform.forward * firingSpeed);

        }
    }
}
