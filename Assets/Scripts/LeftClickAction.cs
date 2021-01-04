using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftClickAction : MonoBehaviour
{

    public HealthBar PlayerHP;
    public Camera FPSCam;
    public float range = 100f;

    void Awake()
    {
        PlayerHP = GameObject.Find("HealthBar").GetComponent<HealthBar>();
    }

    [System.Obsolete("Use Shoot() instead")]
    void OldShoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, fwd, out hit))
            {
                hit.collider.gameObject.SetActive(false);
                print("There is something in front of the object!");
                Debug.DrawRay(transform.position, fwd * 15, Color.green);
            }

        }
        
       
    } 

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if (Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit, range))
            {
                Debug.Log("You hit to "+hit.transform.name);
                Debug.DrawLine(FPSCam.transform.position, hit.point);

                if (hit.transform.name.Contains("Cube") == true)
                {
                    hit.collider.gameObject.SetActive(false);
                    PlayerHP.PlayerTakeDamage(5.0f);
                }
            }
        }
    }


    void FixedUpdate()
    {
       // OldShoot();
        Shoot();
    }

}
