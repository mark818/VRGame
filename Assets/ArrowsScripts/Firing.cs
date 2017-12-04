using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Firing : MonoBehaviour {

    public enum hands {Left, Right};
    public GameObject controllerLeft;
    public GameObject controllerRight;

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
        //dumb.Vibrate(HapticsAreDumb.VibrationForce.Hard);
    }

    void UpdateScores()
    {
        scores.text = "My HP : " + myHealth + "\n     Enemy HP : " + enemyHealth; 
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
        }
    }

    [PunRPC]
    void RemoteFire(Vector3 position, Quaternion rotation)
    {
        GameObject bullet = Instantiate(bulletType) as GameObject;
        bullet.transform.SetPositionAndRotation(position, rotation);
        bulletrb = bullet.GetComponent<Rigidbody>();
        bulletrb.AddForce(bullet.transform.forward * firingSpeed);
    }

    [PunRPC]
    void RemoteHit()
    {
        myHealth--;
    }

    public void EnemyHit()
    {
        enemyHealth--;
        UpdateScores();
    }
}
