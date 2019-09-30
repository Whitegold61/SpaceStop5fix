using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class GateScript : MonoBehaviour
{
    private SessionManager _sm;
    private MoveShip _mShip;

    public int _localscore;
     
     void Start(){
    _sm = GameObject.Find("SessionManager").GetComponent<SessionManager>();
    //_mShip = GameObject.Find("SHIP(Clone)").GetComponent<MoveShip>();
   
    

    
}
     
     private void OnTriggerEnter(Collider other) {
       if (other.gameObject.tag == "readyFood"){
           Destroy(other.gameObject);
           _localscore += 100;
           _sm.IncreaseScore(100);
            

            if (_localscore > 50){
                GameObject.Find("SHIP(Clone)").GetComponent<MoveShip>().goingHome();
            }
        
       }
   }

   void Update (){

       
            
   }
}
