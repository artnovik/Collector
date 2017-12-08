using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorDown : MonoBehaviour {

    public GameObject[] WallsDown;
    public GameObject playerObj;
    private int amntBlocksOnScreen = 5;
    private float SpawnX = 175.0f;
    private float BlockLength = 50.0f;
    private float SafeZone = 50.0f;
    private int lastBlockIndex = 0;

    private List<GameObject> ActiveWallsDown;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;

        ActiveWallsDown = new List<GameObject>();

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

    }

    private void SpawnBlock(int blockIndex = -1)
    {
        GameObject block;
        block = Instantiate(WallsDown[RandomBlockIndex()]) as GameObject;
        block.transform.SetParent(transform);
        block.transform.position = (Vector2.right * SpawnX) - Vector2.up * 15;
        SpawnX += BlockLength;
        ActiveWallsDown.Add(block);
    }

    private void DeleteBlock()
    {
        Destroy(ActiveWallsDown[0]);
        ActiveWallsDown.RemoveAt(0);
    }

    private int RandomBlockIndex()
    {
        if (WallsDown.Length <= 1)
            return 0;

        int randomIndex = lastBlockIndex;
        while (randomIndex == lastBlockIndex)
        {
            randomIndex = Random.Range(0, WallsDown.Length);
        }

        lastBlockIndex = randomIndex;
        return randomIndex;
    }
}
