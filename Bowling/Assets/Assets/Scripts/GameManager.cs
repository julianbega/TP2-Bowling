using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    private static int score;

    public enum gameModes {Bowling, Shooting }

    private static int actualGamemode = 0;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Update()
    {
        goToMenu();
    }

    public static int getPoints()
    {
        return score;
    }
    public static void setPoints(int points)
    {
        score = points;
    }

    public static int getGameMode()
    {
        return actualGamemode;
    }
    public static void setGameMode(int mode)
    {
        actualGamemode = mode;
    }

    public static void goToMenu()
    {
        if (Input.GetKey(KeyCode.Escape) )
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
