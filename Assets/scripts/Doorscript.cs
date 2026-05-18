using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Doorscript : MonoBehaviour
{
    public int enemiesToKill = 1;
    public static int playerKills = 0;
    public Animator anim;
    public GameObject block;
    bool opened = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (enemiesToKill==playerKills && opened == false)
        {
            Debug.Log("opened");
            anim.SetTrigger("Open");
            block.SetActive(false);
            opened = true;
        }
        else if (enemiesToKill != playerKills && opened == true)
        {
            Debug.Log("closed");
            anim.SetTrigger("Close");
            block.SetActive(true);
            opened = false;
        }
    }
}
