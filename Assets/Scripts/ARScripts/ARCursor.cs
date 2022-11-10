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

    public int ammo;
    public float gunDelay;
    [HideInInspector] public float timer;
    [HideInInspector] public bool canShoot;

    public bool useCursor = true;

    public LayerMask damageable;
    public int damage;



    void Start()
    {
        cursorChildObject.SetActive(useCursor);
        minigunAnim.speed = 0;
        canShoot = true;
        timer = 0;

    }

    void Update()
    {





        if (useCursor)
        {
            UpdateCursor();
        }

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
                    if (useCursor)
                    {
                        //GameObject.Instantiate(objectToPlace, transform.position, transform.rotation);
                        timer = gunDelay;
                        ammo -=1;
                        Vector3 forward = firePoint.transform.TransformDirection(Vector3.forward) * 10;
                        Debug.DrawRay(firePoint.transform.position, forward, Color.green);

                        RaycastHit hit;
                        if(Physics.Raycast(firePoint.transform.position, transform.TransformDirection(Vector3.forward), out hit, 100, damageable))
                        {

                            hit.collider.GetComponent<EnemyHealth>().takeDamage(damage);
                            
                        }

                    }
                    else
                    {
                        List<ARRaycastHit> hits = new List<ARRaycastHit>();
                        raycastManager.Raycast(Input.GetTouch(0).position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
                        if (hits.Count > 0)
                        {
                            //GameObject.Instantiate(objectToPlace, hits[0].pose.position, hits[0].pose.rotation);
                        }
                    }
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                minigunAnim.speed = 0;
            }
        }


    }

    void UpdateCursor()
    {
        Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }

        //pointless
    }
}
