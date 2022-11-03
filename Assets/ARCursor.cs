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

    public bool useCursor = true;

    void Start()
    {
        cursorChildObject.SetActive(useCursor);
        minigunAnim.speed = 0;
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
                if (useCursor)
                {
                    //GameObject.Instantiate(objectToPlace, transform.position, transform.rotation);
                }
                else
                {
                    List<ARRaycastHit> hits = new List<ARRaycastHit>();
                    raycastManager.Raycast(Input.GetTouch(0).position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
                    if (hits.Count > 0)
                    {
                        //GameObject.Instantiate(objectToPlace, hits[0].pose.position, hits[0].pose.rotation);
                    }
                //change to delay
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
