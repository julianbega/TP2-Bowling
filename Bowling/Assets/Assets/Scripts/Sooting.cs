using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sooting : MonoBehaviour
{
    public Camera cam;
    public float rayDistance = 10;
    public LayerMask rayCastLayer;

    private bool isActive;

    public int numberOfKegelsPerExplosion;
    public float minForceInExplosion;
    public float maxForceInExplosion;
    public GameObject miniKegelPrefab;

    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        if (gm.GetGameMode() == 0)
            isActive = true;
        else
            isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
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
                        hit.transform.gameObject.SetActive(false);
                        gm.SetKegels(gm.GetKegels() - 1);
                        gm.SetPoints(gm.GetPoints() + 10);
                        Explosion(hit.transform.position);
                    }
                    else 
                    {
                        gm.SetKegels(10);
                        gm.GoToCredits();
                    }
                }
            }
        }
        if (gm.GetKegels() == 0)
        {
            gm.GoToCredits();
        }
    }

    public void Explosion(Vector3 explosionPos)
    {
        Debug.Log("Explota");
        for (int i = 0; i < numberOfKegelsPerExplosion; i++)
        {
            GameObject miniKegel;
            Rigidbody miniKegelRigidbody;
            float explosionForce = Random.Range(minForceInExplosion, maxForceInExplosion);
            Quaternion rotation = Quaternion.identity;
            rotation.x = Random.Range(-40, 40);
            rotation.y = 0;
            rotation.z = Random.Range(-40, 40);
            miniKegel = Instantiate(miniKegelPrefab, explosionPos, rotation);
            miniKegelRigidbody = miniKegel.GetComponent<Rigidbody>();
            miniKegelRigidbody.AddForce(transform.up * explosionForce);
        }
        
    }
}
