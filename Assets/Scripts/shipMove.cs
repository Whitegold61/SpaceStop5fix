using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMove : MonoBehaviour
{
    public bool hasCollided = false;
    public Transform gatepos;
    private shipSpawn _shipSpawn;
    //public Vector3 ShipReturnPoint = new Vector3;

    // Start is called before the first frame update
    void Start()
    {

        //distancetoDoor = 
        /*  for(int i = 0; i < 4; i++)
        {
            ShipReturnPoint[i] = _shipSpawn.transform.position ;
        }
        _shipSpawn = GameObject.Find("Ship").GetComponent<shipSpawn>();
        if (_shipSpawn == null)
        {
            Debug.Log("ShipSpawn was not found!");
        }
        

    */

    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 5.0f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
            Debug.Log("Did not Hit");
            hasCollided = false;
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, .1f);
        }
    }
 
     /*
        if (!hasCollided)
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, .1f);
      //  else if (hasCollided)
        //    transform.position = Vector3.MoveTowards(transform.position, ShipReturnPoint[], .1f);
       */
    
    



    void OnCollisionEnter(Collision other)
    {
        /*
        hasCollided = true;
        _shipSpawn = GameObject.Find("Ship").GetComponent<shipSpawn>();

        //canSpawn = true;
        _shipSpawn.SetCanSpawn();*/
    }
        
}
