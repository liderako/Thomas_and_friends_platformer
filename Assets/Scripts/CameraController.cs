using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public PlayerController[] players;
    public int currentPlayer;
    public String nextScene;
    public String currentScene;
    private bool end;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - players[0].transform.position;
        end = false;
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = players[currentPlayer].transform.position + offset;
        if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.Backspace))
        {
            SceneManager.LoadScene(currentScene, LoadSceneMode.Single);
        }
        if (!end && players[0].winPosition && players[1].winPosition && players[2].winPosition)
        {
            SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
            end = true;
        }
    }
}