using UnityEngine;


public class enemyProj : MonoBehaviour
{
    public int type = 1;
    public GameObject rock;
    public GameObject paper;
    public GameObject scissors;
    public bool randomtype = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log(type);
        if (randomtype)
        {
            type = Random.Range(1, 4);
            
        }

        if (type == 1)
        {
            rock.SetActive(true);
        }
        else if (type == 2)
        {
            paper.SetActive(true);
        }
        else if (type == 3)
        {
            scissors.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
