using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBin : MonoBehaviour
{
    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveItem(GameObject player)
    {
        GameObject givenItem = Instantiate(item, this.transform.position, this.transform.rotation);
        givenItem.GetComponent<Rigidbody>().isKinematic = true;
        givenItem.GetComponent<BoxCollider>().enabled = false;
        givenItem.transform.position = player.GetComponent<TempPlayerMove>().carryPoint.position;
        givenItem.transform.parent = player.transform;
        player.GetComponent<TempPlayerMove>().heldItem = givenItem;
        player.GetComponent<TempPlayerMove>().isHolding = true;

        Debug.Log("WE GOT HERE!!!");
    }
}
