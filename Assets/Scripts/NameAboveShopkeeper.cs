﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameAboveShopkeeper : MonoBehaviour
{
    public GUISkin guiSkin; // choose a guiStyle (Important!)

    public string text = "Shopkeeper"; // choose your name

    public Color color = Color.white;   // choose font color/size
    public float fontSize = 10;
    public float offsetX = 0;
    public float offsetY = 0.5f;

    float boxW = 150f;
    float boxH = 20f;

    public bool messagePermanent = true;

    public float messageDuration { get; set; }

    Vector2 boxPosition;
    void Start()
    {
        if (messagePermanent)
        {
            messageDuration = 1;
        }
    }
    void OnGUI()
    {
        if (messageDuration > 0)
        {
            if (!messagePermanent) 
            {
                messageDuration -= Time.deltaTime;
            }

            GUI.skin = guiSkin;
            boxPosition = Camera.main.WorldToScreenPoint(transform.position);
            boxPosition.y = Screen.height - boxPosition.y;
            boxPosition.x -= boxW * 0.1f;
            boxPosition.y -= boxH * 0.5f;
            guiSkin.box.fontSize = 10;

            GUI.contentColor = color;

            Vector2 content = guiSkin.box.CalcSize(new GUIContent(text));

            GUI.Box(new Rect(boxPosition.x - content.x / 2 * offsetX, boxPosition.y + offsetY, content.x, content.y), text);
        }
    }
}
