using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    private static int score = 0;
    private int remainingKegels = 10;

    public enum gameModes {Bowling, Shooting }

    public static int actualGamemode = 0;

    public int actualGamemodeToDebug = 0;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Update()
    {
        GoToMenu();
        actualGamemodeToDebug = actualGamemode;
    }

    public int GetPoints()
    {
        return score;
    }
    public void SetPoints(int points)
    {
        score = points;
    }
    public int GetKegels()
    {
        return remainingKegels;
    }
    public void SetKegels(int actualKegels)
    {
        remainingKegels = actualKegels;
    }

    public int GetGameMode()
    {
        return actualGamemode;
    }
    public void SetGameMode(int mode)
    {
        Debug.Log("entra");
        actualGamemode = mode;
    }

    public void GoToMenu()
    {
        if (Input.GetKey(KeyCode.Escape) )
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
