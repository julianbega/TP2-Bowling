using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody BallRigidbody;
    const int totalShoots = 3;
    public int shootsCount = 0;
    public float Force = 500f;
    private bool allreadyShoot = false;
    float timeToShoot = 2;
    public BowlingController KegelsChecker;
    // Start is called before the first frame update
    void Start()
    {
        BallRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && allreadyShoot == false && shootsCount< totalShoots && KegelsChecker.kegelsStanding >=1)
        {
            shootsCount++;
            BallRigidbody.AddForce(transform.forward * Force);
            timeToShoot = 2;
            allreadyShoot = true;
        }
        if (allreadyShoot == true && BallRigidbody.velocity.magnitude < 0.01)
        {
            timeToShoot = timeToShoot - Time.deltaTime;

        }
        if (timeToShoot <= 0 && BallRigidbody.velocity.magnitude < 0.01)
        {
            allreadyShoot = false;
        }
        /* if (allreadyShoot == true && BallRigidbody.velocity.magnitude < 0.01)
         {
             if (this.transform.position.x < -7.5 || this.transform.position.x > 8.1)
             { 
             this.transform.rotation = Quaternion.identity;
             BallRigidbody.AddForce(transform.forward * -Force);
             }
         }*/

        if (Input.GetKey(KeyCode.UpArrow) & allreadyShoot == false)
        {
            Force = Force + 1;
        }
        if (Input.GetKey(KeyCode.DownArrow) & allreadyShoot == false)
        {
            Force = Force - 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow) & allreadyShoot == false)
        {
            if (this.transform.position.x > -8.5)
            { 
            this.transform.Translate(Vector3.left * Time.deltaTime, Space.World);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) & allreadyShoot == false)
        {

            if (this.transform.position.x < 10.3)
            {
                this.transform.Translate(Vector3.right * Time.deltaTime, Space.World);
            }
        }
    }
}
