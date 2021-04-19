﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void GoToGame() 
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToCredits() 
    {
        SceneManager.LoadScene("Credits");
    }

}
