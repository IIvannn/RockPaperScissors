using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class collisionCheck : MonoBehaviour
{
    public bool end = false;
    bool triggered = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && triggered == false)
        {
            Doorscript.playerKills = 0;
            triggered = true;
            if (end) 
            {
                SceneManager.LoadScene("WinMenu");
            }
        }
    }
}
