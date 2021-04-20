using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenText : MonoBehaviour
{
    public BowlingController BowllingInfo;

    private int RemaingingShoots;
    private int RemainingKegels;
    private int Points;

    public Text Score;
    public Text Kegels;
    public Text Shoots;

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
        if (isActive)
        {
            Points = BowllingInfo.points;
            RemainingKegels = BowllingInfo.kegelsStanding;
            RemaingingShoots = BowllingInfo.totalShoots - BowllingInfo.shootsCount;
            Score.text = "Score: " + Points;
            Kegels.text = "Remaining Kegels: " + RemainingKegels;
            Shoots.text = "Remaining Shoots: " + RemaingingShoots;
        }
        if (!isActive)
        {
            Points = gm.GetPoints(); ;
            RemainingKegels = gm.GetKegels();
            Score.text = "Score: " + Points;
            Kegels.text = "Remaining Kegels: " + RemainingKegels;
            Shoots.text = "  " ;
        }
    }

}
