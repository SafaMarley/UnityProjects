using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public int score;
    private int lives = 3;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public Slider volumeSlider;
    public Button restartButton;
    public GameObject menu;
    public GameObject pauseScreen;
    public bool gamePaused;
    
    private bool isGameActive;
    private float spawnRate = 1f;
    private AudioSource music;
    
    // Start is called before the first frame update
    void Start()
    {
        music = FindObjectOfType<Camera>().GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = Random.Range(0, targets.Count);
            Instantiate(targets[randomIndex]);
        }
    }

    public void UpdateScore(int scoreToUpdate)
    {
        score += scoreToUpdate;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        if (lives == 0)
        {
            isGameActive = false;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void StartGame(int levelDifficulty)
    {
        score = 0;
        isGameActive = true;
        spawnRate /= levelDifficulty;

        livesText.text = "Lives: " + lives;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    void pauseGame()
    {
        music.Pause();
        gamePaused = true;
        Time.timeScale = 0;
        pauseScreen.gameObject.SetActive(true);
    }

    void resumeGame()
    {
        music.UnPause();
        gamePaused = false;
        Time.timeScale = 1;
        pauseScreen.gameObject.SetActive(false);
    }
}
