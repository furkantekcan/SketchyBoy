using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public GameObject wall;
    private Transform nextSpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnPosition = wall.transform.GetChild(0).transform;
        InvokeRepeating("ExampleCoroutine", 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnNewWall()
    {
        GameObject newWall = Instantiate(wall, nextSpawnPosition.position, Quaternion.identity);

        nextSpawnPosition = newWall.transform.GetChild(0).transform;
    }

    private void ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.

        //After we have waited 1 seconds print the time again.
        SpawnNewWall();
    }

}
