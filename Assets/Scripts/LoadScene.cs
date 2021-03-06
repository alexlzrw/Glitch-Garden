﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] int timeForWait = 3;
    int currentIndex;


    void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }

    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeForWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentIndex + 1);
    }

    public void RestartScene() {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentIndex);
    }

    public void LoadMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start menu");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
