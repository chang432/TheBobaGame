﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decorationsMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject shopManager;

    [SerializeField]
    public GM GameManager;

    [SerializeField]
    public GameObject decorationsMeanu;

   
    void OnMouseDown()
    {
        decorationsMeanu.SetActive(true);
        GameManager.LoadLoginScene();
    }
}
