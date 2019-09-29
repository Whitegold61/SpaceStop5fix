using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ATTACH TO A SPHERE CENTERED AT ORIGIN AND WITH A SPHERE COLLIDER
// MAKE SURE TO USE A TRASPARENT MATERIAL

public class ForceField : MonoBehaviour
{
    public float waitTime = 3.0f;
    public bool isEnabled = false;
    public float transparency = 0.1f;
    private float counter = 0.0f;




    void Start()
    {
         this.GetComponent<MeshRenderer>().enabled = false;
         this.GetComponent<SphereCollider>().enabled = false;

    }
    void Update()
    {        
        if(isEnabled) counter += Time.deltaTime;

        if((counter >= waitTime) && (isEnabled==true)){
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
            isEnabled = false;
            Debug.Log("FIELD OFF");
            counter = 0.0f;
            
        }  

        if(Input.GetKeyDown(KeyCode.Space) && isEnabled == false){
            SwitchActive();
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "asteroid"){
            
            Debug.Log("I FOUND AN ASTEROID");
            Destroy(other.gameObject);

        }
    }

    private void SwitchActive(){
        this.gameObject.GetComponent<SphereCollider>().enabled = true;
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, transparency);
        isEnabled = true;
        Debug.Log("FIELD ON");
    }
}
