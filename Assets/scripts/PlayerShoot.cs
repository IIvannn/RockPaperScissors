using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using Polyperfect.Universal;

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
    public Animator weaponAnimator;
    public GameObject croshair;
    public Camera fpsCamera;

    //public TextMeshProUGUI magazine;
    public GameObject cameraShaker;

    private int weapon = 1;

    private Vector2 scroll;


    public GameObject[] weapons;
    public GameObject[] uiweapons;

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
            weapon--;
            if (weapon <0)
            {
                weapon = weapons.Length - 1;
            }
            SelectWeapon(weapon);
        }
        if (scroll.y < 0)
        {
            weapon++;
            if (weapon >= weapons.Length)
            {
                weapon = 0;
            }
            SelectWeapon(weapon);
        }

        if (Mouse.current.leftButton.isPressed)
        {
            weaponAnimator.SetBool("attacking", true);
        }
        else
        {
            weaponAnimator.SetBool("attacking", false);
        }

        if (weapon == 0)
        {
            weaponAnimator.SetBool("rock", true);
            weaponAnimator.SetBool("paper", false);
            weaponAnimator.SetBool("scissors", false);
        }
        if (weapon == 1)
        {
            weaponAnimator.SetBool("rock", false);
            weaponAnimator.SetBool("paper", true);
            weaponAnimator.SetBool("scissors", false);
        }
        if (weapon == 2)
        {
            weaponAnimator.SetBool("rock", false);
            weaponAnimator.SetBool("paper", false);
            weaponAnimator.SetBool("scissors", true);
        }


        CheckProj();
    }

    void SelectWeapon(int weapon)
    {
        Debug.Log("weapon:  "+(weapon+1));
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i == weapon);
            uiweapons[i].SetActive(i == weapon);

        }
    }

    void CheckProj()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, 5f))
        {
            
            if (hit.transform.CompareTag("proj"))
            {
                croshair.SetActive(true);
                //Debug.Log("proj detected");

                enemyProj script = hit.transform.GetComponent<enemyProj>();

                if (script != null)
                {
                    
                    if (Mouse.current.leftButton.isPressed)
                    {
                        
                        if (script.type == 1 && weapon == 1)
                        {
                            script.source.GetComponent<EnemyFollow>().hp -= 10;
                            Destroy(hit.transform.gameObject);
                            Debug.Log("rock");
                        }
                        else if (script.type == 2 && weapon == 2)
                        {
                            script.source.GetComponent<EnemyFollow>().hp -= 10;
                            Destroy(hit.transform.gameObject);
                            Debug.Log("paper");
                        }
                        else if (script.type == 3 && weapon == 0)
                        {
                            script.source.GetComponent<EnemyFollow>().hp -= 10;
                            Destroy(hit.transform.gameObject);
                            Debug.Log("scissors");
                        }
                        else
                        {
                            PlayerMovementScript.currenthp -= 10;
                            Destroy(hit.transform.gameObject);
                            Debug.Log("miss");
                        }

                    }
                }

            }
            else
            {
                croshair.SetActive(false);
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
