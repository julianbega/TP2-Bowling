using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kegel : MonoBehaviour
{
    Rigidbody KegelRigidbody;
    public bool KegelHasDrop = false;
    // Start is called before the first frame update
    void Start()
    {
        KegelRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.transform.rotation != Quaternion.identity)
        {
            KegelHasDrop = true;
        }
    }
}
