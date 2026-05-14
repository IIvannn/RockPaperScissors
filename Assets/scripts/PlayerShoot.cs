using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    float nextBulletTime;

    [Header("Values")]
    public float damage = 25f;
    public float range = 100f;
    

    public float shakeDuration = 0.1f;
    public float shakeMagnitude = 2f;
    Vector3 originalPosition;

    [Header("Components")]
    
    public Camera fpsCamera;

    //public TextMeshProUGUI magazine;
    public GameObject cameraShaker;

    private int weapon = 1;

    private Vector2 scroll;


    public GameObject[] weapons;

    void Start()
    {
        originalPosition = cameraShaker.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        scroll = Mouse.current.scroll.ReadValue();


        
        
        if (scroll.y >0)
        {
            weapon++;
            if (weapon >= weapons.Length)
            {
                weapon = 0;
            }
            SelectWeapon(weapon);
        }
        if (scroll.y < 0)
        {
            weapon--;
            if (weapon<0)
            {
                weapon = weapons.Length-1;
            }
            SelectWeapon(weapon);
        }

        //Debug.Log(weapon);
        CheckProj();
    }

    void SelectWeapon(int weapon)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i==weapon);
        }
    }

    void CheckProj()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, 3f))
        {
            
            if (hit.transform.CompareTag("proj"))
            {
                Debug.Log("proj detected");

                enemyProj script = hit.transform.GetComponent<enemyProj>();

                if (script != null)
                {
                    if (Mouse.current.leftButton.isPressed)
                    {

                        Destroy(hit.transform.gameObject);

                    }
                }
            }


        }
    }


    IEnumerator shake()
    {
        float elapsed = 0f;
        while (elapsed < shakeDuration)
        {
            float x = UnityEngine.Random.Range(-1f, 1f) * shakeMagnitude;
            float y = UnityEngine.Random.Range(-1f, 1f) * shakeMagnitude;

            cameraShaker.transform.localPosition = originalPosition + new Vector3(x, y, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        cameraShaker.transform.localPosition = originalPosition;


    }


    
}
