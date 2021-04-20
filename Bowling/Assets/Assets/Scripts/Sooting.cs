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
                    }
                    else 
                    {
                        gm.SetKegels(10);
                        SceneManager.LoadScene("Credits");
                    }
                }
            }
        }
    }
}
