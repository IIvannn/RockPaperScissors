using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{

    bool paused = false;
    public GameObject pausemenu;

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (paused)
        {
            Time.timeScale = 1.0f;
            paused = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pausemenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0.0f;
            paused = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pausemenu.SetActive(true);
        }
    }

    public void Quit()
    {
        Pause();
        SceneManager.LoadScene("MainMenu");
    }
       

    public void Resume()
    {
        Pause();
    }
}
