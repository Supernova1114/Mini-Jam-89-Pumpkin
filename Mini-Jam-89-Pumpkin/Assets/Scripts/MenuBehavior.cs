using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame() 
    {
        Application.Quit();
    }
}