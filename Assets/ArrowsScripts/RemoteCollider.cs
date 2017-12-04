using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteCollider : MonoBehaviour {
    public GameObject gameControl;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        gameControl.GetComponent<Firing>().EnemyHit();
    }
}
