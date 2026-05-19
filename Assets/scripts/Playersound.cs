using UnityEngine;

public class Playersound : MonoBehaviour
{
    [Header("Sounds")]
    public AudioSource rocksnd;
    public AudioSource papersnd;
    public AudioSource scissorssnd;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void weaponsnd()
    {

        if (PlayerShoot.weapon == 0)
        {
            rocksnd.Play();
        }
        if (PlayerShoot.weapon == 1)
        {
            papersnd.Play();
        }
        if (PlayerShoot.weapon == 2)
        {
            scissorssnd.Play();
        }
    }
}
