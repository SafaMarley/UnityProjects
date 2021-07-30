using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    public int levelDifficulty;
    
    private Button button;
    private GameManager gameManager;
    private Slider volumeSlider;
    private AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(setDifficulty);
        volumeSlider = gameManager.volumeSlider;
        backgroundMusic = FindObjectOfType<Camera>().GetComponent<AudioSource>();
        volumeSlider.onValueChanged.AddListener(setVolume);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void setDifficulty()
    {
        //Debug.Log(button.gameObject.name + " is clicked!");
        gameManager.StartGame(levelDifficulty);
        gameManager.menu.gameObject.SetActive(false);
    }

    void setVolume(float sliderValue)
    {
        backgroundMusic.volume = sliderValue;
    }
}
