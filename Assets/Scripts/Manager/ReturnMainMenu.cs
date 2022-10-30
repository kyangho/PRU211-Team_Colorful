using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMainMenu : MonoBehaviour
{
    public void ReturnMenu()
    {
        SceneManager.LoadSceneAsync("Main");
    }
}
