using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody BallRigidbody;
    const int totalShoots = 3;
    public int shootsCount = 0;
    public float Force = 0;
    public float BaseForce = 5000;
    public bool allreadyShoot = false;
    public float timeToShoot = 2;
    public float maxTimeToNextShoot = 20;
    public BowlingController KegelsChecker;

    private float leftLimit = -8.5f;
    private float rightLimit = 10.3f;

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
            

        if (allreadyShoot == true )
        {
            timeToShoot = timeToShoot - Time.deltaTime;
        }
        if ((timeToShoot <= -maxTimeToNextShoot && allreadyShoot == true) )
        {
            this.transform.rotation = Quaternion.identity;
            this.transform.position = new Vector3(1.0f, 0.0f, 0.0f);
            BallRigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            BallRigidbody.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
            allreadyShoot = false;
        }
        

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
            if (this.transform.position.x > leftLimit)
            { 
            this.transform.Translate(Vector3.left * Time.deltaTime, Space.World);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) & allreadyShoot == false)
        {

            if (this.transform.position.x < rightLimit)
            {
                this.transform.Translate(Vector3.right * Time.deltaTime, Space.World);
            }
        }
    }
}
