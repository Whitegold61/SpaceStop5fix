using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    public float timeSince, spawnRate, timeScaling, scaleLimit;
    public GameObject asteroidPrefab;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSince += Time.deltaTime + timeScaling;
        if (timeSince >= spawnRate)
        {
            int i = Random.RandomRange(0, spawnPoints.Length);
            GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPoints[i].transform.position, this.transform.rotation);
            newAsteroid.GetComponent<Astroid>().targetDestination = this.transform;
            newAsteroid.GetComponent<Astroid>().spawner = this;
            timeSince = 0f;
            if(timeScaling >= scaleLimit)
            {
                timeScaling = 0f;
            }
        }
    }
}
