﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void _onPlayButton(){
        SceneManager.LoadScene("GamePlay");
    }
}
