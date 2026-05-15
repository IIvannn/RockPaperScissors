using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Play()
    {
        
        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;
        SceneManager.LoadScene("TESTLEVEL");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
