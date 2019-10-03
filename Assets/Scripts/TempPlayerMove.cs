using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerMove : MonoBehaviour
{
    [SerializeField] private int playerNumber;
    [SerializeField] private float  movementSpeed;
    [SerializeField] private float interactRange;
    public bool isHolding,isSeated;

    public Transform carryPoint;
    public GameObject heldItem;


    private Animator anime;

    private Camera mainCam;
    private Vector3 camForward, camRight, movement;
    private Vector3 groundNormal = Vector3.up;
    private float moveV, moveH;
    private bool isBeingCarried;
    private GameObject carrier;


    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        //mainCam = Camera.main;//GameObject.Find("Main Camera")
    }

    // Update is called once per frame
    void Update()
    {

        BackOnPosition();

        if (!isSeated)
        {
            if (isBeingCarried == false)
            {
                //Player Movement
                Vector3 movement = new Vector3(Input.GetAxisRaw(playerNumber + "Horizontal"), 0f, Input.GetAxisRaw(playerNumber + "Vertical"));
                movement.Normalize();
                this.transform.position += movement * Time.deltaTime * movementSpeed * SessionManager.speedMultiplier;
                //playerMovement();


                Vector3 lookDirection = new Vector3(Input.GetAxisRaw(playerNumber + "Horizontal"), 0, Input.GetAxisRaw(playerNumber + "Vertical"));
                if (lookDirection != new Vector3(0, 0, 0))
                {
                    transform.rotation = Quaternion.LookRotation(lookDirection);

                }
            }
            
            if (Input.GetButtonDown(playerNumber + "Interact"))
            {
                //make the carrier drop you if you press interact
                if (isBeingCarried == true)
                {
                    this.transform.parent = null;
                    this.GetComponent<MeshCollider>().enabled = true;
                    this.GetComponent<Rigidbody>().isKinematic = false;
                    carrier.GetComponent<TempPlayerMove>().isHolding = false;
                    carrier.GetComponent<TempPlayerMove>().heldItem = null;
                    isBeingCarried = false;
                }
                //if not holding, interact with stuff, else drop what you're holding
                if (!isHolding)
                {
                    InteractWith();
                    
                }
                else if(isHolding)
                {
                    
                    heldItem.transform.parent = null;
                    if (heldItem.CompareTag("Player")==true){
                        heldItem.GetComponent<MeshCollider>().enabled = true;
                        heldItem.GetComponent<Rigidbody>().isKinematic = false;
                        heldItem.GetComponent<TempPlayerMove>().isBeingCarried = false;
                    }
                    else
                    {
                        heldItem.GetComponent<BoxCollider>().enabled = true;
                        heldItem.GetComponent<Rigidbody>().isKinematic = false;
                    }
                    
                    heldItem = null;
                    isHolding = false;
                }
            }
        }
    }

    private void BackOnPosition()
    {
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(0, 0.65f, 0);
        }
    }

    public void InteractWith()
    {
        if (Physics.Raycast(new Vector3(this.transform.position.x, this.transform.position.y - .3f, this.transform.position.z), this.transform.forward, out hit, interactRange))
        {
            if(hit.transform.gameObject.GetComponent<ShipGateSwitch>() != null)
            {
                hit.transform.gameObject.GetComponent<ShipGateSwitch>().ShipGateSwitchOn();
            }
            
            if (hit.transform.gameObject.GetComponent<Item>() != null)
            {
                hit.transform.gameObject.GetComponent<Item>().PickUp(this.gameObject);
                heldItem.transform.rotation = this.transform.rotation;
                isHolding = true;
            }

            if (hit.transform.gameObject.GetComponent<Microwave>() != null)
            {
                if (hit.transform.gameObject.GetComponent<Microwave>().isBroken == false)
                {
                    hit.transform.gameObject.GetComponent<Microwave>().Dispence();
                }
                else
                {
                    hit.transform.gameObject.GetComponent<Microwave>().Repair();
                }
            }

            if (hit.transform.gameObject.GetComponent<ItemBin>() != null)
            {

                Debug.Log("DETECTED");
                hit.transform.gameObject.GetComponent<ItemBin>().GiveItem(this.gameObject);
            }

            if (hit.transform.gameObject.CompareTag("Player") == true)
            {
                //Debug.Log("made it this far");
                GameObject foundPlayer = hit.transform.gameObject;
                heldItem = foundPlayer;
                //set found player to being carried by this object
                foundPlayer.GetComponent<TempPlayerMove>().carrier = this.gameObject;
                foundPlayer.GetComponent<TempPlayerMove>().isBeingCarried = true;

                foundPlayer.transform.position = this.gameObject.GetComponent<TempPlayerMove>().carryPoint.position + new Vector3(0, 0.2f,0);
                foundPlayer.transform.parent = this.gameObject.transform;
                foundPlayer.transform.rotation = this.transform.rotation;
                foundPlayer.GetComponent<Rigidbody>().isKinematic = true;
                foundPlayer.GetComponent<MeshCollider>().enabled = false;
                
                isHolding = true;
                


            }

        }
    }
/*
    void playerMovement(){

        groundNormal = GameObject.Find("Ground").transform.up;

        moveV = Input.GetAxisRaw(playerNumber + "Vertical");
        moveH = Input.GetAxisRaw(playerNumber + "Horizontal");

        camForward = mainCam.transform.forward;
        camRight = mainCam.transform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        movement = moveH*camRight + moveV*camForward;
        movement = mainCam.transform.InverseTransformDirection(movement);
        movement = Vector3.ProjectOnPlane(movement, groundNormal);
        movement.Normalize();

        
        this.transform.Translate(movement * Time.deltaTime * movementSpeed, Space.World);
        //this.transform.position += movement * Time.deltaTime * movementSpeed;// * SessionManager.speedMultiplier;

        //this.transform.Rotate(0,Mathf.Atan2(movement.x,movement.z),0);
        transform.rotation = Quaternion.LookRotation(movement);
       
        Debug.Log(movement);
    }
    */
}
