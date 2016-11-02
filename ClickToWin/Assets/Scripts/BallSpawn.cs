using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BallSpawn : MonoBehaviour {

    public GameObject[] Balls = new GameObject[4];
    private GameObject[] Spawners;
    List<GameObject> activeBalls;
    public float fallRate;
    public float threshold;

    private bool spawn = true;                              //Used to track when a new spawn should happen
    public float spawnTimer;                                //Determines time between spawns

	// Use this for initialization
	void Start() {
        Transform spawners = GameObject.Find("Spawners").transform;
        Spawners = new GameObject[spawners.childCount];
        activeBalls = new List<GameObject>();
        for (int i = 0; i < spawners.childCount; i++)
        {
            Spawners[i] = spawners.transform.GetChild(i).gameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (!MenuHandler.getMenuState())
        {
            if (spawn)
            { 
            foreach (GameObject obj in Spawners)
            {
                GameObject o = GameObject.Instantiate(Balls[getRandomBall()]);
                o.transform.position = obj.transform.position;
                activeBalls.Add(o);

            }

            spawn = false;
            StartCoroutine(SpawnCycle());
            }

            Debug.Log(activeBalls.Count);
            dropBalls();
            destroyBalls();
        }

        if (MenuHandler.getGameState())
        {
            Debug.Log("ending");
            foreach (GameObject ball in activeBalls)
            {
                activeBalls.Remove(ball);
                Destroy(ball);
            }

            MenuHandler.refreshGameState();
        }
	
	}

    private int getRandomBall()
    {
        return UnityEngine.Random.Range(0, 4);
    }

    IEnumerator SpawnCycle()
    {
            yield return new WaitForSeconds(spawnTimer);
            spawn = true;
    }

    private void dropBalls()
    {
        foreach (GameObject ball in activeBalls)
        {
            ball.transform.position = Vector3.Lerp(ball.transform.position, ball.transform.position - new Vector3(0, fallRate, 0), 0.3f);
        }
    }

    private void destroyBalls()
    {
        foreach (GameObject ball in activeBalls)
        {
            if (ball.transform.position.y < threshold)
            {
                Destroy(ball);
                activeBalls.Remove(ball);
            }

        }
    }
}
