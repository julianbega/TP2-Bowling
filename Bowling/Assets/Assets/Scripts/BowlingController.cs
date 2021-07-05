using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingController : MonoBehaviour
{
    public int totalShoots = 3;
    public int shootsCount = 0;
    bool allreadyShoot = false;
    public int points = 0;
    public int kegelsStanding = 10;
    float timeToShoot = 2;
    Rigidbody BallRigidbody;
    public GameObject Ball;
    public Kegel[] Kegels;

    private bool isActive;

    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        BallRigidbody = Ball.GetComponent<Rigidbody>();
        if (gm.GetGameMode() == 0)
            isActive = true;
        else
            isActive = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (Input.GetKeyUp(KeyCode.Space) && allreadyShoot == false && totalShoots <= 1 && kegelsStanding >= 1 && BallRigidbody.velocity.magnitude < 0.01)
            {
                allreadyShoot = true;
                totalShoots--;
            }
            if (allreadyShoot == true && BallRigidbody.velocity.magnitude < 0.01)
            {
                timeToShoot = timeToShoot - Time.deltaTime;
            }
            if (BallRigidbody.velocity.magnitude < 0.01)
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
            }
        }

        if (kegelsStanding <= 0)
        {

        }
    }
}
