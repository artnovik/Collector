using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int score = 0;
    public GameObject[] Stars;
    public GameObject playerObj;
    private int amntStarsOnScreen = 5;
    private float SpawnX1 = 45.0f, SpawnX2 = 65.0f;
    private float StarLength = 50.0f;
    private float SafeZone = 50.0f;

    private List<GameObject> ActiveStars;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;

        ActiveStars = new List<GameObject>();

        for (int i = 0; i < amntStarsOnScreen; i++)
        {
            SpawnStar1();
            SpawnStar2();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if ((playerObj.transform.position.x - SafeZone) > (SpawnX1 - amntStarsOnScreen * StarLength))
        {
            SpawnStar1();
            SpawnStar2();
            DeleteStar();
        }
    }

    private void SpawnStar1(int blockIndex = -1)
    {
        GameObject block;
        block = Instantiate(Stars[0]) as GameObject;
        block.transform.SetParent(transform);
        block.transform.position = (Vector2.right * (SpawnX1 + Random.Range(-10,0))) + Vector2.up * Random.Range(-12,-5);
        SpawnX1 += StarLength;
        ActiveStars.Add(block);
    }

    private void SpawnStar2(int blockIndex = -1)
    {
        GameObject block;
        block = Instantiate(Stars[0]) as GameObject;
        block.transform.SetParent(transform);
        block.transform.position = (Vector2.right * (SpawnX2 + Random.Range(0, 10))) + Vector2.up * Random.Range(2, 12);
        SpawnX2 += StarLength;
        ActiveStars.Add(block);
    }

    private void DeleteStar()
    {
        Destroy(ActiveStars[0]);
        ActiveStars.RemoveAt(0);
    }
    
    public void ScoreUpdate()
    {
        score++;
    }
}
