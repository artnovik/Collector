using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorUp : MonoBehaviour {

    public GameObject[] WallsUp;
    public GameObject playerObj, StartWalls;
    private int amntBlocksOnScreen = 5;
    private float SpawnX = 150.0f;
    private float BlockLength = 50.0f;
    private float SafeZone = 50.0f;
    private int lastBlockIndex = 0;

    private List<GameObject> ActiveWallsUp;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;

        ActiveWallsUp = new List<GameObject>();

        for (int i = 0; i < amntBlocksOnScreen; i++)
        {
            SpawnBlock();
        }
    }
	
	// Update is called once per frame
	void Update () {

        if ((playerObj.transform.position.x - SafeZone) > (SpawnX - amntBlocksOnScreen * BlockLength))
        {
            SpawnBlock();
            DeleteBlock();
        }

        if (playerObj.transform.position.x >= 200.0f)
        {
            Destroy(StartWalls);
            return;
        }
    }

    private void SpawnBlock(int blockIndex = -1)
    {
        GameObject block;
        block = Instantiate(WallsUp[RandomBlockIndex()]) as GameObject;
        block.transform.SetParent(transform);
        block.transform.position = (Vector2.right * SpawnX) + Vector2.up * 15;
        SpawnX += BlockLength;
        ActiveWallsUp.Add(block);
    }

    private void DeleteBlock()
    {
        Destroy(ActiveWallsUp[0]);
        ActiveWallsUp.RemoveAt(0);
    }

    private int RandomBlockIndex()
    {
        if (WallsUp.Length <= 1)
            return 0;

        int randomIndex = lastBlockIndex;
        while (randomIndex == lastBlockIndex)
        {
            randomIndex = Random.Range(0, WallsUp.Length);
        }

        lastBlockIndex = randomIndex;
        return randomIndex;
    }
}
