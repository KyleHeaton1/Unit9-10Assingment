using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARCursor : MonoBehaviour
{
    public GameObject cursorChildObject;
    public Animator minigunAnim;
    public GameObject objectToPlace;
    public ARRaycastManager raycastManager;
    public GameObject firePoint;

    //FUCK YOU
    public GameObject line;

    
    public int ammo;
    public float gunDelay;
    [HideInInspector] public float timer;
    [HideInInspector] public bool canShoot;

    public bool useCursor = true;

    public LayerMask damageable;
    public int damage;
    Camera mainCam;

    public GameObject particleEffect;



    void Start()
    {
        minigunAnim.speed = 0;
        canShoot = true;
        timer = 0;
        mainCam = Camera.main;

    }

    void Update()
    {
        //shit code
        Vector3 ray = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        line.transform.position = transform.position;

        Debug.DrawRay(ray, Vector3.forward, Color.blue);

        //Need to include shooting minigun 

        if (Input.touchCount > 0 )
        {
            Touch touch = Input.GetTouch(0);
            minigunAnim.speed = 1;
            
            if(touch.phase == TouchPhase.Stationary)
            {
                timer -= Time.deltaTime;
                if(timer <= 0)
                {
                    canShoot = true;
                }else
                {
                    canShoot = false;
                }


                if(canShoot)
                {
                    timer = gunDelay;
                    ammo -=1;
                    Debug.DrawRay(ray, Vector3.forward, Color.green);
                    particleEffect.SetActive(true);

                    RaycastHit hit;

                    if(Physics.Raycast(ray, transform.TransformDirection(Vector3.forward), out hit, 100, damageable))
                    {
                        if(hit.transform.tag == "enemy")
                        {
                            Debug.Log("HIT ENEMY");
                            hit.collider.GetComponent<EnemyHealth>().takeDamage(damage);
                        }
                        else{
                            Debug.Log("MISSED ENEMY");
                        }
                    }
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                minigunAnim.speed = 0;
                particleEffect.SetActive(false);
            }
        }

        line.transform.position = ray + (Camera.main.transform.forward * 100);


    }
}
