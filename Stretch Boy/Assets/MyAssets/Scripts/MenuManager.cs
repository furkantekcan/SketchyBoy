﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject scorePanel;

    public void Play()
    {
        //int currentLevelNo = PlayerPrefs.GetInt("LevelNo", 1);

        SceneManager.LoadScene(1);
    }

    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }
    public void OpenScoresPanel()
    {
        scorePanel.SetActive(true);
    }

    public void VibrationMode()
    {

    }

    public void VoiceMode()
    {

    }

    public void BackToMenu()
    {
        settingsPanel.SetActive(false);
        scorePanel.SetActive(false);
    }

    public void MoreGames()
    {
        Application.OpenURL("https://www.sellmyapp.com/downloads/fall-heroes-knockout-3d-game-unity-source-code/");
    }

    public void RateUs()
    {
        Application.OpenURL("https://www.sellmyapp.com/downloads/fall-heroes-knockout-3d-game-unity-source-code/");
    }

    public void PrivacyPolicy()
    {
        Application.OpenURL("https://www.sellmyapp.com/downloads/fall-heroes-knockout-3d-game-unity-source-code/");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
