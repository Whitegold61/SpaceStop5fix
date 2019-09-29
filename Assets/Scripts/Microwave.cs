using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : MonoBehaviour
{
    public float cookTime, explodeTime, currentTime, explosiveForce, explosiveRadius, upForce;
    public string itemName;

    public bool overcooked;
    public bool isCooking;
    public bool isBroken;
    public Transform dispensePoint;

    private float currentRepair = 0f, repairRate = 10, degradeRate = 1;

    public float maxIntensity;
    public Light myLight;
    private bool lightUp;
    private float lightSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooking && !isBroken)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= explodeTime && overcooked)
            {
                Explode();
            }
            if(currentTime > cookTime)
            {
                overcooked = true;
                myLight.color = Color.Lerp(Color.green, Color.red , currentTime/explodeTime);
                lightSpeed += Time.deltaTime*5;
            }
            if (myLight.intensity < maxIntensity && lightUp)
            {
                myLight.intensity += Time.deltaTime * lightSpeed;
            }
            else if (myLight.intensity > 0)
            {
                lightUp = false;
                myLight.intensity -= Time.deltaTime * lightSpeed;
            }
            else
            {
                lightUp = true;
            }
        }
        else if (isBroken)
        {
            if(currentRepair >= 100)
            {
                isBroken = false;
            }
            else
            {
                currentRepair -= degradeRate * Time.deltaTime;
                currentTime = 0f;
                lightSpeed = 1f;
            }
        }
        else
        {
            currentTime = 0f;
            lightSpeed = 1f;
            myLight.intensity = Mathf.Clamp(myLight.intensity - (Time.deltaTime * 3), 0, 100);
        }
    }

    public void Dispence()
    {
        if (isCooking)
        {
            GameObject droppedItem;
            if (currentTime < cookTime)
            {
                droppedItem = Instantiate(Resources.Load(itemName, typeof(GameObject))) as GameObject;
                droppedItem.transform.position = dispensePoint.position;
                droppedItem.GetComponent<Item>().timeCooked = currentTime;
            }
            if(currentTime >= cookTime && currentTime < explodeTime)
            {
                switch (itemName)
                {
                    case "ItemBlue":
                        droppedItem = Instantiate(Resources.Load("ItemBlueCooked", typeof(GameObject))) as GameObject;
                        droppedItem.transform.position = dispensePoint.position;
                        break;
                    case "ItemRed":
                        droppedItem = Instantiate(Resources.Load("ItemRedCooked", typeof(GameObject))) as GameObject;
                        droppedItem.transform.position = dispensePoint.position;
                        break;
                    case "ItemYellow":
                        droppedItem = Instantiate(Resources.Load("ItemYellowCooked", typeof(GameObject))) as GameObject;
                        droppedItem.transform.position = dispensePoint.position;
                        break;
                }
            }
            
            overcooked = false;
            isCooking = false;
            itemName = null;
        }
    }

    public void Repair()
    {
        currentRepair += repairRate;
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, explosiveRadius);
        foreach (Collider hit in colliders)
        {
            if (hit.GetComponent<Rigidbody>() != null)
            {
                Rigidbody rigidbody = hit.GetComponent<Rigidbody>();
                rigidbody.AddExplosionForce(explosiveForce, this.transform.position, explosiveRadius, upForce, ForceMode.Impulse);
            }
        }
        
        overcooked = false;
        isCooking = false;
        itemName = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
         if(collision.gameObject.GetComponent<Item>() != null)
        {
            Debug.Log("asdfljasl;fkajsd;lf");

            if (collision.gameObject.GetComponent<Item>().isCooked == false && isCooking == false)
            {
                
                cookTime = collision.gameObject.GetComponent<Item>().cookTime;
                explodeTime = collision.gameObject.GetComponent<Item>().explodeTime;
                itemName = collision.gameObject.GetComponent<Item>().itemName;
                currentTime = 0f;
                isCooking = true;
                //collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                Destroy(collision.gameObject);
            }
        }
        
    }
}

