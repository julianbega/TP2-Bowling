using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDeleteOnTime : MonoBehaviour
{
    public float timeToDelete;
    void Update()
    {
        timeToDelete -= Time.deltaTime;
        if (timeToDelete <= 0) Destroy(this.gameObject);
    }

}
