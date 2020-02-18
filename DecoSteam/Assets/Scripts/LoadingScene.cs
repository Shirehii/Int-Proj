using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public void LoadScene(string sceneName) //Method for loading a scene. The scene name is given in the unity inspector
    {
        SceneManager.LoadScene(sceneName);
    }

    //F
}
