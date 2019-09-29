using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shipSpawn : MonoBehaviour
{
    Vector3[] shipSpawnPoints = { new Vector3 { x = -19f, y = 1.16f, z = 20f }, new Vector3 { x = 20f, y = 1.16f, z = 19f }, new Vector3 { x = 19f, y = 1.16f, z = -21f }, new Vector3 { x = -21f, y = 1.16f, z = -19f }
                          };
    public GameObject spawnShip;
    public GameObject[] shipArray = new GameObject[4];
    public bool canSpawn = true;
    public int[] randships = new int[4];
    public int shipsOut;
    private MoveShip MoveShip;
    


    // Start is called before the first frame update
    void Start()
    {
       
        

        shipArray[0] = Instantiate(spawnShip, shipSpawnPoints[0], Quaternion.Euler(new Vector3(90, 0, 45)));

        //  public GameObject cube0 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //  cube0.transform.position = new Vector3(-3.67f, 1.6f, 6);
        shipArray[1] = Instantiate(spawnShip, shipSpawnPoints[1], Quaternion.Euler(new Vector3(90, 0, -46)));
        // public GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //  cube1.transform.position = new Vector3(8.3f, 1.6f, 5.1f);
        shipArray[2] = Instantiate(spawnShip, shipSpawnPoints[2], Quaternion.Euler(new Vector3(90, 0, -134)));
        //  public GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //   cube2.transform.position = new Vector3(8f, 1.6f, -5);
        shipArray[3] = Instantiate(spawnShip, shipSpawnPoints[3], Quaternion.Euler(new Vector3(90, 0, 130)));
        //public GameObject cube3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //  cube3.transform.position = new Vector3(-3.67, 1.6f, -5f);
        // Instantiate(spawnShip, shipSpawnPoints[0], Quaternion.Euler(new Vector3(90, 0, 45)));

        waveLaunch();
        MoveShip = GameObject.Find("SHIP").GetComponent<MoveShip>();
    }
    /*
    public void SetCanSpawn()
    {
         canSpawn = true;
        Debug.Log("RELAUNCH");
        for (int i = 0; i < randships.Length; i++)
        {
            
            shipArray[i].SetActive(false);

        }
        
        waveLaunch();}*/
        


   public void waveLaunch()
    {
        if (canSpawn) { 
          //  public int[] randships = new int[4];
            randships[0] = Random.Range(1, 2);
            randships[1] = Random.Range(0, 2);
            randships[2] = Random.Range(0, 2);
            randships[3] = Random.Range(0, 2);




            for (int j = 0; j < randships.Length;j++)
            {
                
                    if (randships[j] == 1)

                    {
                    //shipMover(j);
                    shipArray[j].SetActive(true);
                    shipsOut++;
                    //canSpawn = false;

                    }
                
                
            }

            }
        }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}