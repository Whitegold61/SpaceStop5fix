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
    private shipSpawn shipSpawn;
    public bool CanLaunchWave;

    private SessionManager _sm;
    public int _localscore;

    private bool isFoodLoaded = false;
    private bool isFluidLoaded = false;
    private bool isWaterLoaded = false;

    public bool isGoingHome = false;
   

    public int checkShipsOut;
    public enum shipStatus
    
    

    {
        Waiting,
        readyToLaunch,
        goingToStation,
        locked,
        waitingOnLoad,
        headHome

    }

    public shipStatus currentShipStatus;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        startPosition = transform.position;
        Debug.Log(startPosition);
        //currentShipStatus = shipStatus.goingToStation;
       // shipSpawn = GameObject.FindGameObjectWithTag("WallScript").GetComponent<shipSpawn>();
        //checkShipsOut = GameObject.Find("SHIP").GetComponent<shipSpawn>().shipsOut;
       //checkShipsOut = shipSpawn.shipsOut;
      

    }

    private void Start()
    {
        _sm = GameObject.Find("SessionManager").GetComponent<SessionManager>();
        currentShipStatus = shipStatus.Waiting;
        StartCoroutine(RandomTimeArrival());
    }

    // Update is called once per frame
    void Update()
    {


        //checkShipsOut = shipSpawn.shipsOut;
        RaycastHit hit;

        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up * -1) * 50, Color.red);

        //if (Physics.Raycast(this.transform.position, this.transform.up * -1, out hit, .5f) && currentShipStatus != shipStatus.headHome)


        

        if (Physics.SphereCast(this.transform.position, 0.5f, this.transform.up * -1, out hit, .3f) && currentShipStatus != shipStatus.headHome)
        {

            if (hit.collider.gameObject.tag == "Wall" ^ hit.collider.gameObject.tag =="WallScript")
            {

                currentShipStatus = shipStatus.waitingOnLoad;
                isGoingHome = false;
                //Debug.Log("HIT WALL");

            }
        }
        else
        {
            if (currentShipStatus == shipStatus.goingToStation)
            {
                transform.position = Vector3.MoveTowards(transform.position, center, shipSpeed);
            }
        }

        if (currentShipStatus == shipStatus.headHome)
        {
            isGoingHome = true;

            if (transform.position != startPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, 0.5f);
                Debug.Log("Going Home");
            }
            else
            {
               // shipSpawn.degrementValue();
                //currentShipStatus = shipStatus.goingToStation; 
            }
        }
//!!! DON'T FORGET TO CHANGE FROM || to &&
        if (isFoodLoaded == true || isWaterLoaded == true|| isFluidLoaded == true)
        {
            currentShipStatus = shipStatus.headHome;
            StartCoroutine(ReturnForLoad());
            isFluidLoaded = false;
            isWaterLoaded = false;
            isFoodLoaded = false;

            isGoingHome = true;

        }
        /*
        if (checkShipsOut < 1)
        {
            shipSpawn.waveLaunch();
        }
        */
    }
    public void goingHome()
    {
        currentShipStatus = shipStatus.headHome;
        Debug.Log("going home");
        isGoingHome = true;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "WaterReady")
        {
            Debug.Log("WaterOnBoard");
            Destroy(other.gameObject);
            _localscore += 49;
            _sm.IncreaseScore(_localscore);
            isWaterLoaded = true;
        }
        else if (other.tag == "FluidReady")
        {
            Debug.Log("FluidOnBoard");
            Destroy(other.gameObject);
            _localscore += 123;
            _sm.IncreaseScore(_localscore);
            isFluidLoaded = true;
        }
        else if (other.tag == "FoodReady")
        {
            Debug.Log("FoodOnBoard");
            Destroy(other.gameObject);
            _localscore += 114;
            _sm.IncreaseScore(_localscore);
            isFoodLoaded = true;
        }
    }

    IEnumerator ReturnForLoad()
    {
        yield return new WaitForSeconds(3f);
        currentShipStatus = shipStatus.goingToStation;
    }

    IEnumerator RandomTimeArrival()
    {
        yield return new WaitForSeconds(Random.Range(0, 4));
        currentShipStatus = shipStatus.goingToStation;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(this.transform.position, this.transform.up * -1);
        Gizmos.DrawSphere(this.transform.position + this.transform.up * -1 * .5f, 10f);
    }
}
