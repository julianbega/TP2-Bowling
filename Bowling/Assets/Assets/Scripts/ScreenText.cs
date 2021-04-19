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
    // Start is called before the first frame update
    void Start()
    {
       
    }
        



// Update is called once per frame
void Update()
    {
        Points = BowllingInfo.points;
        RemainingKegels = BowllingInfo.kegelsStanding;
        RemaingingShoots = BowllingInfo.totalShoots - BowllingInfo.shootsCount;
        Score.text = "Score: " + Points;
        Kegels.text = "Remaining Kegels: " + RemainingKegels;
        Shoots.text = "Remaining Shoots: " + RemaingingShoots;
    }
}
