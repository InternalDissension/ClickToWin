using UnityEngine;
using System.Collections;

public class GameStateHandler : MonoBehaviour {

    private static bool startSpawn = false;
    private static bool mainGameRun = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (MenuHandler.getMenuState())
        {
            Debug.Log("stopped");
            Time.timeScale = 0;
        }

        else
        {
            Time.timeScale = 1;
            mainGameRun = true;
            startSpawn = true;
        }
	
	}

    public static bool getStartSpawnValue()
    {
        return startSpawn;
    }
}
