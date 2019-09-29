using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipReguest : MonoBehaviour
{
    public int food;
    public int gas;
    public int water;

    void Start()
    {
        int food = Random.Range(0, 2);
        int gas = Random.Range(0, 2);
        int water = Random.Range(0, 2);

       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (food == 1)
        {
            //other.tag = good read
            //score = +100
            //Destroy Function 

        } else if (gas == 1)
        {
         
            //other.tag = good read
            //score = +100
            //Destroy Function 
        } else if (water == 1)
        {
            //other.tag = good read
            //score = +100
            //Destroy Function 
        }
    }

    private void Update()
    {
        if (food == 1)
        {
            
        }
    }


}
