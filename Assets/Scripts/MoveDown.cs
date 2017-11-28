using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour {
    public bool isMoving = true;
    private float time;
    public GameObject previous = null;
    public float current = 0.0f;
    public OVRInput.Controller controller;

    void Start()
    {
        time = Time.time;
    }


    // Update is called once per frame
    void Update () {
        if ((OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp)) && this.transform.position.z < 5.317f)
        {
            this.transform.Translate(0f, 0f, .1f);
        }

        if ((OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown)) && this.transform.position.z > 4.917f)
        {
            this.transform.Translate(0f, 0f, -.1f);
        }

        if ((OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft)) && this.transform.position.x > 0.622f)
        {
            this.transform.Translate(-.1f, 0f, 0f);
        }

        if ((OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight)) && this.transform.position.x < 1.022)
        {
            this.transform.Translate(.1f, 0f, 0f);
        }

        if (Time.time >= time + 1f && isMoving == true)
        {
            this.transform.Translate(0f, -.1f, 0f);
            time = Time.time;
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {


        isMoving = false;
        //if ((previous.Equals(collision.gameObject))) //&& ((Time.time - current) >= 1))
       // {
       //     isMoving = false;
       //     previous = null;
      //      current = 0.0f;
      //  }
      //  current = Time.time;
      //  previous = collision.gameObject;
      //  isMoving = true;
    }
}
