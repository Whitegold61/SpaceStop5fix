using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGateSwitch : MonoBehaviour
{ 

    public Light light;
    public bool isShipGateSwitch = false;


    void Update(){

        if(isShipGateSwitch == true){


            light.color = Color.green;
        }else{
            light.color = Color.red;
        }
    }
    public void ShipGateSwitchOn()
    {
        isShipGateSwitch = true;
    }

}
