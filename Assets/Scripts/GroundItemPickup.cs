using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySamples.Items;

public class GroundItemPickup : MonoBehaviour
{

   // public HealthBar Can;
    public ItemBase item;
    public Camera FPSCam;
    private bool IsTriggered = false;
    private bool ShowMessage = false;

    /* void Shoot()
     {
         if (Input.GetKeyDown(KeyCode.Mouse0))
         {
             RaycastHit hit;
             if (Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit, 5f))
             {
                 string textt = hit.transform.name;
             }
         }
     }

     void FixedUpdate()
     {
         Shoot();
     } */
  /*  public float timeLeft = 3.0f;

    void Update()
    {
        timeLeft -= Time.deltaTime;   
        if (timeLeft < 0)
        {
            ShowMessage = false;
        }
    }*/

    void OnGUI()
    {
        if (ShowMessage == true && IsTriggered)
        {
            GUI.color = Color.white;
            GUI.backgroundColor = Color.black;

            string Text = null;

            switch (item.IType)
            {
                case itemType.HEALTH:
                    {
                        Text = "Press \"E\" to heal yourself, \"F\" to pickup item";
                        break;
                    }
                case itemType.ARMOR:
                    {
                        Text = "Press \"E\" to equip armor, \"F\" to pickup item";
                        break;
                    }
                case itemType.POTION:
                    {
                        Text = "Press \"E\" to use potion, \"F\" to pickup item";
                        break;
                    }
                case itemType.WEAPON:
                    {
                        Text = "Press \"E\" to equip weapon, \"F\" to pickup item";
                        break;
                    }
            }

            GUI.Box(new Rect(140, Screen.height - 50, Screen.width - 300, 120), Text);
        }
    }

    //private RaycastHit hit;

    private void OnTriggerEnter(Collider other)
    {
        ShowMessage = true;   

        if (other.gameObject.tag == "Player" && !IsTriggered)
        {
            IsTriggered = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.tag == "Item" && Input.GetKeyDown(KeyCode.E) && IsTriggered)
        {
            Debug.Log(gameObject.name);
            IsTriggered = false;
            item.GetGameObjectName(gameObject.name);
            item.Use();
        }
        if (gameObject.tag == "Item" && Input.GetKeyDown(KeyCode.F) && IsTriggered)
        {
            //Add to Inventory codes

            Debug.Log(System.DateTime.Now+"---"+gameObject.name);
            IsTriggered = false;
            //item.GetGameObjectName(gameObject.name);
            //item.Use();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        ShowMessage = false;
        IsTriggered = false;
    }
}
