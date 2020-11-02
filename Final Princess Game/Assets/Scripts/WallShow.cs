using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallShow : MonoBehaviour
{
    public bool isWallOn;
    public GameObject obj;
    private static int keyAmount;  //  A new Static variable to hold our amount of keys.
    public bool collided;

    void Start () {

        obj.SetActive(true);
        isWallOn = true;
    }

    void Update () {
        keyAmount = PlayerManager.keyCount;
    
        if (keyAmount == 1 || keyAmount == 2) {

            if (isWallOn == true) {

                obj.SetActive(false);
                isWallOn = false;
            }

        }
    }
}
