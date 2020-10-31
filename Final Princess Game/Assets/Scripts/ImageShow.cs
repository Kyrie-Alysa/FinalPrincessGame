 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 
 public class ImageShow : MonoBehaviour {
 
     public bool isImgOn;
     public Image img;
     private static int keyAmount;  //  A new Static variable to hold our amount of keys.
 
     void Start () {
 
         img.enabled = false;
         isImgOn = false;
     }
 
     void Update () {
         keyAmount = PlayerManager.keyCount;

         if (keyAmount == 1) {
 
             if (isImgOn == false) {
 
                 img.enabled = true;
                 isImgOn = true;
             }
 
         }
     }
 }
