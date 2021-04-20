using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sooting : MonoBehaviour
{
    public Camera cam;
    public float rayDistance = 10;
    public LayerMask rayCastLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = cam.ScreenPointToRay(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayDistance, rayCastLayer))
            {
                string layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

                if (layerHitted == "Kegels")
                {
                    Debug.Log("pinos");
                }
            }
        }
    }
}
