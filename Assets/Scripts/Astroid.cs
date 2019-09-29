using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    public float travelSpeed;
    public Transform targetDestination;
    public AstroidSpawner spawner;
    public GameObject impactEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, targetDestination.position, travelSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Shield")
        {
            GameObject impactEffect = Instantiate(impactEffectPrefab, this.transform.position, this.transform.rotation);
            Destroy(impactEffect, 10f);
            spawner.timeScaling += .5f;
            Destroy(this.gameObject);
        }
        else
        {
            GameObject impactEffect = Instantiate(impactEffectPrefab, this.transform.position, this.transform.rotation);
            Destroy(impactEffect, 10f);
            spawner.timeScaling = Mathf.Clamp(spawner.timeScaling - 1f, 0, 100f);
            SessionManager.isSlowed = true;
            Destroy(this.gameObject);
        }
    }
}
