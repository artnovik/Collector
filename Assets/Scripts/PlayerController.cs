using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Text UIScore;
    public GameObject Stars;
    public CharacterController controller;
    public float horizontalSpeed = 25.0f,
          verticalSpeed = 20.0f;

    public bool isDead = false;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead)
        {
            return;
        }

        controller.Move(Vector2.right * horizontalSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            controller.Move(Vector2.up * verticalSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            controller.Move(Vector2.down * verticalSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Star"))
            {
                Destroy(other.gameObject);
                Stars.GetComponent<ScoreManager>().ScoreUpdate();
                UIScore.text = "Score: " + Stars.GetComponent<ScoreManager>().score;
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            Death();
        }
    }

    private void Death()
    {
        isDead = true;
        GameObject.Find("UI").GetComponent<UIManager>().ShowDeadMenu();
    }
}
