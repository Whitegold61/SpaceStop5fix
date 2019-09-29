using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyManager : MonoBehaviour
{
    private ShipValue _shipValue;


    

    private void Start()
    {
        _shipValue = GameObject.Find("SpaceShip").GetComponent<ShipValue>();

    
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("Fire2"))
            {

                _shipValue.changeShipStatustoTixed();
                Debug.Log("Fire!!!!!");

            }
        }
    }

    
}
