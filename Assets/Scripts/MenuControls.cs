using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("Intro");
    }

    public void DisplayInstructions()
    {
        Debug.Log("Instructions displayed");
    }

}
