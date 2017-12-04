using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteCollider : MonoBehaviour {
    public GameObject gameControl;

    private void OnTriggerEnter(Collider other)
    {
        gameControl.GetComponent<Firing>().EnemyHit();
    }
}
