﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
   public void OnPlay()
    {
        SceneManager.LoadScene("Game");
    }
    public void OnSettings()
    {
        Settings.i.Show();
    }
}