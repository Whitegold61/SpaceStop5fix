using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 center = new Vector3(0,0,0);
    public float targetDistance = 1000f;
    public bool isMoving;
    public float shipSpeed = .2f;
    public enum shipStatus
    {
        readyToLaunch,
        goingToStation,
        locked,
        waitingOnLoad,
        headHome

    }

    public shipStatus currentShipStatus;
    int checkShipsOut = GameObject.Find("SHIP").GetComponent<shipSpawn>().shipsOut;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        Debug.Log(startPosition);
        currentShipStatus = shipStatus.goingToStation;
      

    }

    // Update is called once per frame
    void Update()
    {
        


        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up *-1) * 50, Color.red);
        if (Physics.Raycast(this.transform.position, this.transform.up *-1, out hit, 3 ) && currentShipStatus != shipStatus.headHome)
        {
           
            if (hit.collider.gameObject.tag == "Wall")
            {
               
                currentShipStatus = shipStatus.waitingOnLoad;

             } 
         } else
        {
            if (currentShipStatus == shipStatus.goingToStation)
            {

                transform.position = Vector3.MoveTowards(transform.position, center, shipSpeed);
            }
        }

        if (currentShipStatus == shipStatus.headHome)
        {
            if (transform.position != startPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, 0.5f);
                Debug.Log("Going Home");
            }
            else
            {
                checkShipsOut--;
                currentShipStatus = shipStatus.readyToLaunch;
            }
        }

    }

    public void goingHome()
    {
        currentShipStatus = shipStatus.headHome;
    }
}
