using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public List<GameObject> targets;
    public List<GameObject> holes;
    private const float XOFFSET = 2.15f;
    private const float ZOFFSET = -3.5f;
    private const float SPAWNPOSY = -1.4f;
    public Text gameStartText;
    public Text scoreText;
    public Text timeText;
    public Text gameOverText;
    public Button restartButton;
    private float spawnRate = 1.5f;
    private int score;
    public float time;
    public bool isGameActive;
    private bool isOver;


    // Start is called before the first frame update
    void Start() {
        isGameActive = false;
        isOver = false;
        gameStartText.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    private void FixedUpdate() {
        if (!isGameActive && !isOver && Input.GetMouseButtonUp(0)) {
            StartGame();
        }

        if (isGameActive) {
            time -= Time.deltaTime;
            timeText.text = "Time: " + Mathf.Round(time);
            if (time <= 0) {
                GameOver();
            }
        }
    }

    public void StartGame() {
        isGameActive = true;
        gameStartText.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateStat(score, 0);
    }

    IEnumerator SpawnTarget() {
        while (isGameActive) {
            yield return new WaitForSeconds(spawnRate);
            GameObject target = targets[Random.Range(0, targets.Count)];
            Vector3 holePos = holes[Random.Range(0, holes.Count)].transform.position;
            Instantiate(target, new Vector3(holePos.x + XOFFSET, SPAWNPOSY, holePos.z + ZOFFSET), target.transform.rotation);
        }
    }

    public void UpdateStat(int scoreToAdd, int timeToMinus) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        time -= timeToMinus;
    }

    public void GameOver() {
        isGameActive = false;
        isOver = true;
        gameOverText.text = "Game Over\r\nScore: " + score;
        scoreText.gameObject.SetActive(false);
        timeText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
