using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCycling : MonoBehaviour 
{
    //This script essentially works as a point system to determine which scene the players should be playing on

    public PlayerCombat comb1;
    public PlayerCombat comb2;
    public string currentScene = null;
    public int turf;
    public LoadingScene sceneLoader;

    public void Awake()
    {
        //Get components
        currentScene = SceneManager.GetActiveScene().name; //get current scene name
        Debug.Log(currentScene);
        if (currentScene != "Main Menu")
        {
            comb1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerCombat>();
            comb2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerCombat>();
        }
        sceneLoader = GetComponent<LoadingScene>();

        switch (currentScene) //Initialize turf points, to make sure they're correct
        {
            case "Docks":
                turf = 1;
                break;
            case "Sewers":
                turf = 2;
                break;
            case "CityCentre":
                turf = 3;
                break;
            case "Market":
                turf = 4;
                break;
            case "Blimp":
                turf = 5;
                break;
        }
    }

    public void Update()
    {
        if (currentScene != "Main Menu")
        {
            if (comb1.dead) //RIGHT WIN
            {
                turf += 1;
                SwitchScene();
            }
            else if (comb2.dead) //LEFT WIN
            {
                turf -= 1;
                SwitchScene();
            }
        }
    }

    private void SwitchScene()
    {
        switch (turf)
        {
            case 0:
                Debug.Log("left win");
                break;
            case 1:
                sceneLoader.LoadScene("Docks");
                break;
            case 2:
                sceneLoader.LoadScene("Sewers");
                break;
            case 3:
                sceneLoader.LoadScene("CityCentre");
                break;
            case 4:
                sceneLoader.LoadScene("Market");
                break;
            case 5:
                sceneLoader.LoadScene("Blimp");
                break;
            case 6:
                Debug.Log("right win");
                break;
        }
    }

    //F
}