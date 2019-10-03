using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class GateScript : MonoBehaviour
{
    private SessionManager _sm;
    private MoveShip _mShip;
    public GameObject switch1;
    public GameObject switch2;

    public Animator animatorDoorL;
    public Animator animatorDoorR;

    private GameObject _switch1;
    private GameObject _switch2;

    public int _localscore;
     
     void Start(){
    _sm = GameObject.Find("SessionManager").GetComponent<SessionManager>();
        //_mShip = GameObject.Find("SHIP(Clone)").GetComponent<MoveShip>();

        
       
}
     
     private void OnTriggerEnter(Collider other) {

        if (switch1.GetComponent<ShipGateSwitch>().isShipGateSwitch == true && switch2.GetComponent<ShipGateSwitch>().isShipGateSwitch == true)
        {
           /* animatorDoorL.SetBool("open", true);
            animatorDoorR.SetBool("open", true);
            */

           /* if (other.gameObject.tag == "readyFood")
            {
                Destroy(other.gameObject);
                _localscore += 100;
                _sm.IncreaseScore(100);


                if (_localscore > 50)
                {
                    GameObject.Find("SHIP").GetComponent<MoveShip>().goingHome();
                }

            }*/
        }

        
   }

   void Update (){
        
        if (switch1.GetComponent<ShipGateSwitch>().isShipGateSwitch == true && switch2.GetComponent<ShipGateSwitch>().isShipGateSwitch == true)
        {
            animatorDoorL.SetBool("open", true);
            animatorDoorR.SetBool("open", true);
        } else
        {
            animatorDoorL.SetBool("open", false);
            animatorDoorR.SetBool("open", false);
        }
        

   }
}
