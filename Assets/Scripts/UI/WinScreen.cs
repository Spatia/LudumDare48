using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public GameObject winScreen;
    public Text scoreText;
    int score;
    bool isWinScreenShowing = false;
    public int No_Modules;
    public void ShowGOMenu()
    {
        isWinScreenShowing = true;
        score = GetComponent<Ressources>().score;
        Time.timeScale = 0f;
        scoreText.GetComponent<Text>().text = "Score: " + score + " points";
        winScreen.SetActive(true);
    }
    void Update()
    {
        No_Modules = 0;

        ToucheTruc[] ModuleList = FindObjectsOfType<ToucheTruc>();

        foreach (ToucheTruc check in ModuleList)
        {
            No_Modules += 1;
        }

        if (No_Modules == 0)
        {
            ShowGOMenu();
        }

        if (!isWinScreenShowing)
        {
            winScreen.SetActive(false);
        }
    }
}