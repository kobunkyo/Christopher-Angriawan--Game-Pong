using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Games");
        
    }

    public void Author()
    {
        Debug.Log("Created by Christopher Angriawan");
    }
}
