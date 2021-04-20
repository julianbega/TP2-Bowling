using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    private GameManager gm;
    void Start()
    {
        gm = GameManager.Instance;
    }
    public void GoToGame() 
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToCredits() 
    {
        SceneManager.LoadScene("Credits");
    }

    public void setNewMode(int mode)
    {
        gm.SetGameMode(mode);
    }

}
