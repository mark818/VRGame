using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFiring : MonoBehaviour {

    public OVRInput.Controller controllerLeft;
    public OVRInput.Controller controllerRight;

    private float [] indexTriggerState = { 0, 0 };
    private float [] handTriggerState = { 0, 0 };
    private float [] oldIndexTriggerState = { 0, 0 };

    

    // Use this for initialization
    void Start () {
		
        

	}
	
	// Update is called once per frame
	void Update () {

        updateTriggers();

        checkFiring();



    }

    void updateTriggers()
    {
        oldIndexTriggerState[0] = indexTriggerState[0];
        indexTriggerState[0] = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controllerLeft);
        handTriggerState[0] = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controllerLeft);

        oldIndexTriggerState[1] = indexTriggerState[1];
        indexTriggerState[1] = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controllerRight);
        handTriggerState[1] = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controllerRight);
    }

    void checkFiring()
    {
        if (indexTriggerState[0] > 0.9f && oldIndexTriggerState[0] < 0.9f)
        {
            //Insert Firing Here
        }

        if (indexTriggerState[1] > 0.9f && oldIndexTriggerState[1] < 0.9f)
        {
            //Insert Firing Here
        }



    }
}
