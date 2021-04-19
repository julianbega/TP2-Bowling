using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingController : MonoBehaviour
{
    const int totalShoots = 3;
    public int shootsCount = 0;
    bool allreadyShoot = false;
    public int points = 0;
    public int kegelsStanding = 10;
    float timeToShoot = 2;
    Rigidbody BallRigidbody;
    public GameObject Ball;
    public Kegel[] Kegels;


    // Start is called before the first frame update
    void Start()
    {
        BallRigidbody = Ball.GetComponent<Rigidbody>();
   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && allreadyShoot == false && shootsCount < totalShoots && kegelsStanding >= 1 && BallRigidbody.velocity.magnitude < 0.01 )
        {
            allreadyShoot = true;
            shootsCount++;
        }
        if (allreadyShoot == true && BallRigidbody.velocity.magnitude < 0.01)
        {
            timeToShoot = timeToShoot - Time.deltaTime;
        }
        if (allreadyShoot == true && BallRigidbody.velocity.magnitude < 0.01 && timeToShoot <= 0)
        {
            for (int i = 0; i < Kegels.Length; i++)
            {
               
                 if (Kegels[i].KegelHasDrop == true && Kegels[i].isActiveAndEnabled)
                 {                    
                     Kegels[i].gameObject.SetActive(false);
                    points += 10;
                    kegelsStanding--;
                 }
            }
            Ball.transform.rotation = Quaternion.identity;
            Ball.transform.position = new Vector3(1.0f, 0.0f, 0.0f);
            allreadyShoot = false;
            timeToShoot = 2;
        }
    }
}
