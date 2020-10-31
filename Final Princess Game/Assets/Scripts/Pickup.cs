using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other) 
   {
       PlayerManager manager = other.GetComponent<PlayerManager>();
       if (manager) 
       {
           bool pickedUp = manager.PickupItem(gameObject);
           if (pickedUp) 
           {
               Destroy(gameObject);
           }
       }

   }

}
