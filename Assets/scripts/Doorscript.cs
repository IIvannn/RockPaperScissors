using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Doorscript : MonoBehaviour
{
    public int enemiesToKill = 1;
    public static int playerKills = 0;
    public Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesToKill==playerKills)
        {
            anim.SetTrigger("open");
        }
        else
        {
            anim.SetTrigger("close");
        }
    }
}
