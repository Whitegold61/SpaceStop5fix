﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipValue : MonoBehaviour
{
    [SerializeField]
    private bool isLocked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeShipStatustoTixed()
    {
        isLocked = true;
    }
}
