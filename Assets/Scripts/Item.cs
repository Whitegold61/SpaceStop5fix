using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float cookTime;
    public float explodeTime;
    public string itemName;
    public float timeCooked = 0f;
    public bool isCooked;
    private BoxCollider collider;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp(GameObject parent)
    {
        rigidbody.isKinematic = true;
        collider.enabled = false;
        this.transform.position = parent.GetComponent<TempPlayerMove>().carryPoint.position;
        this.transform.parent = parent.transform;
        parent.GetComponent<TempPlayerMove>().heldItem = this.gameObject;
    }
}
