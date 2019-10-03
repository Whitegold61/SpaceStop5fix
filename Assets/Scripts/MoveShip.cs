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
    private int scoreMultiplier;

    public bool isFoodLoaded = false;
    public bool isFluidLoaded = false;
    public bool isWaterLoaded = false;

    public bool isGoingHome = false;
    private bool hasDocked = false;
    

    private GameObject led1;
    private GameObject led2;
    private GameObject led3;
    private Material red;
    private Material blue;
    private Material yellow;
    private Material black;

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

        red = Resources.Load("LedRed", typeof(Material)) as Material;
        blue = Resources.Load("LedBlue", typeof(Material)) as Material;
        yellow = Resources.Load("LedYellow", typeof(Material)) as Material;
        black = Resources.Load("LedBlack", typeof(Material)) as Material;
}

    // Update is called once per frame
    void Update()
    {


        //checkShipsOut = shipSpawn.shipsOut;
        RaycastHit hit;

        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up * -1) * 50, Color.red);

        //if (Physics.Raycast(this.transform.position, this.transform.up * -1, out hit, .5f) && currentShipStatus != shipStatus.headHome)

        if (Physics.SphereCast(this.transform.position, 0.3f, this.transform.up * -1, out hit, .3f) && currentShipStatus != shipStatus.headHome)
        {
            //Debug.Log(this.gameObject.name + " DETECT WALL");
            if (hit.collider.gameObject.tag == "Wall" ^ hit.collider.gameObject.tag =="WallScript")
            {  
                //DO THIS ONCE ON WALL HIT
                if (!hasDocked)
                {
                    createShipNeeds();
                    currentShipStatus = shipStatus.waitingOnLoad;
                    isGoingHome = false;
                    hasDocked = true;
                }
                

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
                //Debug.Log("Going Home");
            }
            else
            {
               // shipSpawn.degrementValue();
                //currentShipStatus = shipStatus.goingToStation; 
            }
        }

        //!!! DON'T FORGET TO CHANGE FROM || to &&
        if (isFoodLoaded == true && isWaterLoaded == true && isFluidLoaded == true && hasDocked == true)
        {
            currentShipStatus = shipStatus.headHome;
            StartCoroutine(ReturnForLoad());
            isFluidLoaded = false;
            isWaterLoaded = false;
            isFoodLoaded = false;

            _localscore += (50 * scoreMultiplier);
            _sm.IncreaseScore(_localscore);

            scoreMultiplier = 0;
            isGoingHome = true;
            hasDocked = false;
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
        //Debug.Log("going home");
        isGoingHome = true;
    }

    private void createShipNeeds()
    {
        do
        {
            isFoodLoaded = Random.value > 0.5f;
            isFluidLoaded = Random.value > 0.5f;
            isWaterLoaded = Random.value > 0.5f;
        }
        while ((isWaterLoaded == true && isFoodLoaded == true && isFluidLoaded == true));

        //UPDATE LEDS
        led1 = GameObject.Find("LED1_"+this.gameObject.name);
        led2 = GameObject.Find("LED2_"+this.gameObject.name);
        led3 = GameObject.Find("LED3_"+this.gameObject.name);

        if (!isFluidLoaded) led1.GetComponent<MeshRenderer>().material = red;
        if (!isFoodLoaded) led2.GetComponent<MeshRenderer>().material = yellow;
        if (!isWaterLoaded) led3.GetComponent<MeshRenderer>().material = blue;

        scoreMultiplier = 0;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "WaterReady" && !isWaterLoaded)
        {
            led3.GetComponent<Renderer>().material = black;
            Debug.Log("WaterOnBoard");
            Destroy(other.gameObject);
            scoreMultiplier++;

            isWaterLoaded = true;

            


        }
        else if (other.tag == "FluidReady" && !isFluidLoaded)
        {
            led1.GetComponent<Renderer>().material = black;
            Debug.Log("FluidOnBoard");
            Destroy(other.gameObject);
            scoreMultiplier++;


            isFluidLoaded = true;
            
        }
        else if (other.tag == "FoodReady" && !isFoodLoaded)
        {
            led2.GetComponent<Renderer>().material = black;
            Debug.Log("FoodOnBoard");
            Destroy(other.gameObject);
            scoreMultiplier++;

            isFoodLoaded = true;
            
        }
    }

    IEnumerator ReturnForLoad()
    {
        yield return new WaitForSeconds(Random.Range(20f,50f));
        currentShipStatus = shipStatus.goingToStation;
    }

    IEnumerator RandomTimeArrival()
    {
        yield return new WaitForSeconds(Random.Range(0f,10f));
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
