using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Firing : MonoBehaviour {

    public enum hands {Left, Right};
    public GameObject controllerLeft;
    public GameObject controllerRight;

    public GameObject enemyControllerLeft;
    public GameObject enemyControllerRight;

    public Rigidbody bulletrb;
    public float firingSpeed;
    public GameObject bulletType;

    public double reloadTime;

    public int initialHealth;

    public GameObject text;
    Text scores;

    int myHealth;
    int enemyHealth;

    HapticsAreDumb leftDumb;
    HapticsAreDumb rightDumb;

    bool leftFireable = true;
    bool rightFireable = true;

    // Use this for initialization
    void Start () {
        myHealth = initialHealth;
        enemyHealth = initialHealth;
        leftDumb = controllerLeft.GetComponent<HapticsAreDumb>();
        rightDumb = controllerRight.GetComponent<HapticsAreDumb>();
        scores = text.GetComponent<Text>();
        UpdateScores();

    }

    // Update is called once per frame
    void Update () {
    }

    void UpdateScores()
    {
        if (myHealth == 0)
        {
            scores.text = "You lose. Get rekt.";
        }
        else if (enemyHealth == 0)
        {
            scores.text = "You win. He got rekt.";
        }
        else
            scores.text = "My HP : " + myHealth + "\nEnemy HP : " + enemyHealth; 
    }

    public void Fire(hands hand)
    {
        Vector3 location;
        Quaternion rotation;

        if (hand == hands.Left && leftFireable)
        {
            location = controllerLeft.transform.position;
            rotation = controllerLeft.transform.rotation;

            Timer timer = new Timer(reloadTime);
            timer.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) =>
            {
                timer.Stop();
                leftFireable = true;
                leftDumb.Vibrate(HapticsAreDumb.VibrationForce.Hard);
            };
            timer.Start();
            leftFireable = false;

            GameObject bullet = Instantiate(bulletType) as GameObject;
            bullet.transform.SetPositionAndRotation(location, rotation);
            bulletrb = bullet.GetComponent<Rigidbody>();
            bulletrb.AddForce(bullet.transform.forward * firingSpeed);
            PhotonView v = PhotonView.Get(this);
            System.Object[] arr = { hand };
            v.RPC("RemoteFire", PhotonTargets.Others, arr);
        }
        else if (hand  == hands.Right && rightFireable)
        {
            location = controllerRight.transform.position;
            rotation = controllerRight.transform.rotation;

            Timer timer = new Timer(reloadTime);
            timer.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) =>
            {
                timer.Stop();
                rightFireable = true;
                rightDumb.Vibrate(HapticsAreDumb.VibrationForce.Hard);
            };
            timer.Start();
            rightFireable = false;

            GameObject bullet = Instantiate(bulletType) as GameObject;
            bullet.transform.SetPositionAndRotation(location, rotation);
            bulletrb = bullet.GetComponent<Rigidbody>();
            bulletrb.AddForce(bullet.transform.forward * firingSpeed);
            PhotonView v = PhotonView.Get(this);
            System.Object[] arr = { hand };
            v.RPC("RemoteFire", PhotonTargets.Others, arr);
        }
    }

    [PunRPC]
    void RemoteFire(hands hand)
    {
        if (hand == hands.Left)
        {
            var position = enemyControllerLeft.transform.position;
            var rotation = enemyControllerLeft.transform.rotation;
            GameObject bullet = Instantiate(bulletType) as GameObject;
            bullet.transform.SetPositionAndRotation(position, rotation);
            bulletrb = bullet.GetComponent<Rigidbody>();
            bulletrb.AddForce(bullet.transform.forward * firingSpeed);
        }
        else
        {
            var position = enemyControllerRight.transform.position;
            var rotation = enemyControllerRight.transform.rotation;
            GameObject bullet = Instantiate(bulletType) as GameObject;
            bullet.transform.SetPositionAndRotation(position, rotation);
            bulletrb = bullet.GetComponent<Rigidbody>();
            bulletrb.AddForce(bullet.transform.forward * firingSpeed);
        }
    }

    [PunRPC]
    void RemoteHit()
    {
        if (myHealth > 0)
        {
            myHealth--;
            UpdateScores();
        }
    }

    public void EnemyHit()
    {
        if (enemyHealth > 0 && myHealth > 0)
        {
            enemyHealth--;
            UpdateScores();
        }
        PhotonView v = PhotonView.Get(this);
        System.Object[] arr = new Object[0];
        v.RPC("RemoteHit", PhotonTargets.Others, arr);
    }
}
