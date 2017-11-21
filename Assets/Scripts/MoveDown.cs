using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour {
    public bool isMoving = true;
    private float time;

    void Start()
    {
        time = Time.time;
    }


    // Update is called once per frame
    void Update () {
        
        if (Time.time >= time + 1f && isMoving == true)
        {
            this.transform.Translate(0f, -.1f, 0f);
            time = Time.time;
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        isMoving = false;
    }
}
