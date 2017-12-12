using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


	public GameObject[] hazards;
	public Vector3 spawnPosition;
    
    public int NHazards;
    public float waveTime;
    public float startTime,intervalTime;
    private int score;
    public Text scoreText,restartText,gameOverText;
    private bool gameOver, restart;


    public GameObject obstruction; 



	void Start () {
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        restartText.text = "";
        score = 0;
        UpdateScore(); 
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //Application.LoadLevel(Application.loadedLevel);
                SceneManager.LoadScene("main"); 
            }
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score; 
    }

    public void AddScore()
    {
        score += 1;
        UpdateScore(); 
    }

    //IEnumerator SpawnWaves()
    //{
    //    yield return new WaitForSeconds(startTime);
    //    while (gameOver!= true)
    //    {
    //        yield return new WaitForSeconds(waveTime);        
    //        for (int i = 0; i < NHazards; i++)
    //        {
    //            GameObject hazard = hazards[Random.Range(0, hazards.Length)];
    //            Vector3 spawnTransform = new Vector3(Random.Range(-spawnPosition.x, spawnPosition.x), spawnPosition.y, spawnPosition.z);
    //            Quaternion spawnRotation = Quaternion.identity;
    //            Instantiate(hazard, spawnTransform, spawnRotation);
    //            yield return new WaitForSeconds(intervalTime);
    //        }
    //    }
    //}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startTime);
        while (gameOver != true)
        {
            Instantiate(obstruction);
            yield return new WaitForSeconds(intervalTime);
        }
    }



    public void GameOver()
    {
        gameOver = true;
        restart = true; 
        gameOverText.text = "Game Over Dude!";
        restartText.text = "Press 'R' To Restart";
    }
}