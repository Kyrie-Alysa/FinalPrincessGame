using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static int keyCount;
    public static int potionCount;

   public bool PickupItem(GameObject obj)
   {
       switch(obj.tag)
       {
            case "Key": 
                keyCount++;
                return true;
            case "Potion":
                potionCount++;
                return true;
            default: 
                Debug.LogWarning($"WARNING: No handler implemented for tag{obj.tag}.");
                return false;
       }

   }

}
