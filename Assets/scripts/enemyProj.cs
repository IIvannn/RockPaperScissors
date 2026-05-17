using UnityEngine;


public class enemyProj : MonoBehaviour
{
    public int type = 1;
    public GameObject rock;
    public GameObject paper;
    public GameObject scissors;
    public bool randomtype = false;
    public float moveSpeed = 10f;
    public float rotateSpeed = 10f;
    public GameObject source;

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
        moveToPlayer();
        RotateToPlayer();
        if (source == null)
        {
            destroyProj();
        }
    }

    void moveToPlayer()
    {
        Vector3 dir = (fpsController.player.transform.position - transform.position).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }
    void RotateToPlayer()
    {
        Vector3 dir = fpsController.player.transform.position - transform.position;
        dir.y = 0f;

        Quaternion targetRot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);
    }

    void destroyProj()
    {
        Destroy(gameObject);
    }

}
