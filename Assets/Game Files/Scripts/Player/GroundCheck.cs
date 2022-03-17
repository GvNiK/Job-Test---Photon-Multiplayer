using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        Debug.Log(playerController);
    }

   private void OnTriggerEnter(Collider other) 
   {
        if(other.gameObject == playerController.gameObject)
            return;

        playerController.SetGroundState(true);
   }

   private void OnTriggerStay(Collider other) 
   {
        if(other.gameObject == playerController.gameObject)
            return;

        playerController.SetGroundState(true);
   }

   private void OnTriggerExit(Collider other) 
   {
        if(other.gameObject == playerController.gameObject)
            return;

        playerController.SetGroundState(false);
   }

//    private void OnCollisionEnter(Collision other) 
//    {
//         if(other.gameObject == playerController.gameObject)
//             return;

//         playerController.SetGroundState(true);  
//    }

//    private void OnCollisionStay(Collision other) 
//    {
//         if(other.gameObject == playerController.gameObject)
//             return;

//         playerController.SetGroundState(true); 
//    }

//    private void OnCollisionExit(Collision other) 
//    {
//         if(other.gameObject == playerController.gameObject)
//             return;

//         playerController.SetGroundState(false);
//    }
}
