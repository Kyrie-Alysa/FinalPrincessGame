using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEndScreen : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
     {
        StartCoroutine("Wait");
     }

    IEnumerator Wait() {
        yield return new WaitForSeconds((float) 0.5);
        SceneManager.LoadScene("EndScreen"); // loads scene When player enter the trigger collider
    }
}
