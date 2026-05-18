using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class collisionCheck : MonoBehaviour
{
    public bool end = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Doorscript.playerKills = 0;
            if (end) 
            {
                SceneManager.LoadScene("WinMenu");
            }
        }
    }
}
