using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("DemoLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
