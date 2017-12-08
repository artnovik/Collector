using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{

    private float cameraSpeed;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        cameraSpeed = GameObject.Find("Player").GetComponent<PlayerController>().horizontalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<CharacterController>().Move(Vector2.right * cameraSpeed * Time.deltaTime);
    }
    

}
