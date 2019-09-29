using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwitchManager : MonoBehaviour
{

    public GameObject _switch1;
    public GameObject _switch2;

    public bool isShipLocked;


    private void Update()
    {
        if (_switch1.GetComponent<ShipGateSwitch>().isShipGateSwitch == true && _switch2.GetComponent<ShipGateSwitch>().isShipGateSwitch == true)
        {
            Debug.Log("ShipIsLocked");
            isShipLocked = true;
        }
    }






}
