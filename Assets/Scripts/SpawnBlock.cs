using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour {

	public GameObject a;
	public GameObject b;
	public GameObject c;
	public GameObject d;
	public GameObject e;
	public GameObject f;
	public GameObject g;
	public GameObject h;
    GameObject[] blocks = new GameObject[8];
    float next_spawn_time = Time.time+5.0f;
    //Physics.gravity = new Vector3(0, -1.0F, 0);



    // Use this for initialization
    void Start () {
        blocks[0] = a;
        blocks[1] = b;
        blocks[2] = c;
        blocks[3] = d;
        blocks[4] = e;
        blocks[5] = f;
        blocks[6] = g;
        blocks[7] = h;
    }

    // Update is called once per frame
    void Update () {
        if (Time.time > next_spawn_time) {
            int block_num = Random.Range(0, 8);
            GameObject clone = GameObject.Instantiate(blocks[block_num], new Vector3(-0.3f, 5, 5.3f), Quaternion.identity);
            clone.AddComponent<Rigidbody>();
           


           // clone.GetComponent<Rigidbody>().useGravity = false;
            //clone.GetComponent<Rigidbody>().velocity = new Vector3(0, -1.0f, 0);
            //clone.GetComponent<Rigidbody>().AddForce(new Vector3(0, 5f, 0));
            next_spawn_time += 5.0f;
            Physics.gravity = new Vector3(0, -0.5f, 0);

            
        }

    }
}
