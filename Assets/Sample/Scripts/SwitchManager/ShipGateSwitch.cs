using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGateSwitch : MonoBehaviour
{
    private MoveShip _moveShip;

    public Light light;
    public bool isShipGateSwitch = false;

    public float waitBeforeGamesWillClose = 4f;

    

    private void Start()
    {
        _moveShip = GameObject.Find("SHIP").GetComponent<MoveShip>();
    }

    void Update(){

        if(isShipGateSwitch == true){


            light.color = Color.green;

            StartCoroutine(timerSwithOFF());
        }else{
            light.color = Color.red;
        }

        if (_moveShip.isGoingHome == true)
        {
            swithesToOFF();
        }
    }
    public void ShipGateSwitchOn()
    {
        isShipGateSwitch = true;
    }

    public void swithesToOFF()
    {
        isShipGateSwitch = false;
    }

    IEnumerator timerSwithOFF()
    {
        yield return new WaitForSeconds(waitBeforeGamesWillClose);
        swithesToOFF();
        Debug.Log("SWITCH OFF");
    }

}
