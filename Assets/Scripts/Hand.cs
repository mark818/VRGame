using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    public OVRInput.Controller controller;
    private float indexTriggerState = 0;
    private float handTriggerState = 0;
    private float oldIndexTriggerState = 0;
    private bool holdingBlock = false;
    private GameObject block = null;
    public Vector3 holdPosition = new Vector3(0, -0.025f, 0.03f);
    public Vector3 holdRotation = new Vector3(0, 180, 0);

    // Update is called once per frame
    void Update()
    {
        oldIndexTriggerState = indexTriggerState;
        indexTriggerState = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);
        handTriggerState = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);
        if (holdingBlock) {
            if (handTriggerState < 0.9f) {
                Release();
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("a")) {
            if (handTriggerState > 0.9f && !holdingBlock) {
                Grab(other.gameObject);
            }
        }
    }

    void Grab(GameObject obj)
    {
        holdingBlock = true;
        block = obj;
        block.transform.parent = transform;
        block.transform.localPosition = holdPosition;
        block.transform.localEulerAngles = holdRotation;
        block.GetComponent<Rigidbody>().useGravity = false;
        block.GetComponent<Rigidbody>().isKinematic = true;


    }

    void Release() {
        block.transform.parent = null;
        Rigidbody rigidbody = block.GetComponent<Rigidbody>();
        rigidbody.useGravity = true;
        rigidbody.isKinematic = false;
        rigidbody.velocity = OVRInput.GetLocalControllerVelocity(controller);
        holdingBlock = false;
        block = null;

    }
}
