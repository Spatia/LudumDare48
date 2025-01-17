using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    bool paused = false;
    public GameObject menuObject;
    public AudioSource audio;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
                paused = false;
            }
            else
            {
                Time.timeScale = 0f;
                paused = true;
            }
        }
        if (paused)
        {
            menuObject.SetActive(true);
        }
        else
        {
            menuObject.SetActive(false);
        }
    }

    public void CloseMenu()
    {
        Time.timeScale = 1f;
        paused = false;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        paused = false;
        audio.Play();
        SceneManager.LoadScene("MainMenu");
    }
}
