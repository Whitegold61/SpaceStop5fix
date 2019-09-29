using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevelManager : MonoBehaviour
{
    private float timer;
    
   
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("1Interact") || Input.GetButtonDown("2Interact") || Input.anyKey)
        {
            SceneManager.LoadScene(1);
            Debug.Log("LoadScene");
        }

        
        
    }


}

