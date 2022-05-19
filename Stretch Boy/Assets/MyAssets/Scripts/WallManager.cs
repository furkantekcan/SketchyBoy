using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public List<GameObject> wallList = new List<GameObject>();
    public GameObject startWall;

    private Transform nextSpawnPosition;
    private GameObject newWall;
    private GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnPosition = startWall.transform.GetChild(0).transform;
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    private void SpawnNewWall()
    {
        wall = wallList[Random.Range(0, wallList.Count)];
        newWall = Instantiate(wall, nextSpawnPosition.position, Quaternion.identity);
        nextSpawnPosition = newWall.transform.GetChild(0).transform;
    }

    private void OnEnable()
    {
        WallTrigger.OnTriggerIn += SpawnNewWall;
    }

    private void OnDisable()
    {
        WallTrigger.OnTriggerIn -= SpawnNewWall;
    }

}
