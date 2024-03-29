﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gamecontroller : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text ScoreText;
    public Text RestartText;
    public Text GameOverText;

    private bool gameOver;
    private bool restart;
    private int score;

    void Start()
    {
       gameOver = false;
        restart = false;
        RestartText.text = "";
        GameOverText.text = ""; 
    score = 0;
    UpdateScore();
    StartCoroutine(SpawnWaves());
    }

    void Update ()
    {
        if (Input.GetKey("escape"))
     Application.Quit();
        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.R))
            {
                SceneManager.LoadScene("Main1");
            }
        }
    }
     IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
            }
            yield return new WaitForSeconds (waveWait);

            if (gameOver)
            {
                RestartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }


    public void AddScore(int newScoreValue)
    {
    score += newScoreValue;
    UpdateScore();
    }

    void UpdateScore()
    {
    ScoreText.text = "Score: " + score;
    }
    public void GameOver ()
    {
        GameOverText.text = "Game Over!";
        gameOver = true;
    }

}
