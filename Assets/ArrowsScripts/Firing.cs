using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour {

    public enum hands {Left, Right};
    public GameObject controllerLeft;
    public GameObject controllerRight;

    public Rigidbody bulletrb;
    public float firingSpeed;
    public GameObject bulletType;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Fire(hands hand)
    {
        Vector3 location;
        Quaternion rotation;

        if (hand == hands.Left)
        {
            location = controllerLeft.transform.position;
            rotation = controllerLeft.transform.rotation;
        }
        else
        {
            location = controllerRight.transform.position;
            rotation = controllerRight.transform.rotation;
        }

        GameObject bullet = Instantiate(bulletType) as GameObject;
        bullet.transform.SetPositionAndRotation(location, rotation);
        bulletrb = bullet.GetComponent<Rigidbody>();
        bulletrb.AddForce(bullet.transform.forward * firingSpeed);
    }
}
