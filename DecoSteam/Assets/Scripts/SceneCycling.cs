using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCycling : MonoBehaviour 
{
    //This script essentially works as a point system to determine which scene the players should be playing on

    public PlayerCombat comb1;
    public PlayerCombat comb2;
    public string currentScene;
    public int turf;
    public LoadingScene sceneLoader;

    public void Awake()
    {
        //Get components
        comb1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerCombat>();
        comb2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerCombat>();
        sceneLoader = GetComponent<LoadingScene>();

        currentScene = SceneManager.GetActiveScene().name; //get current scene name

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

    private void SwitchScene()
    {
        switch (turf)
        {
            case 0:
                Debug.Log("left win");
                break;
            case 1:
                Debug.Log("switch scene");
                sceneLoader.LoadScene("Docks");
                break;
            case 2:
                Debug.Log("switch scene");
                sceneLoader.LoadScene("Sewers");
                break;
            case 3:
                Debug.Log("switch scene");
                sceneLoader.LoadScene("CityCentre");
                break;
            case 4:
                Debug.Log("switch scene");
                sceneLoader.LoadScene("Market");
                break;
            case 5:
                Debug.Log("switch scene");
                sceneLoader.LoadScene("Blimp");
                break;
            case 6:
                Debug.Log("right win");
                break;
        }
    }

    //F
}