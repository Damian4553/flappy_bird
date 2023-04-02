using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject loseUI;
    public int points = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public AudioSource audioSource;
    public AudioClip hit;
    public AudioClip die;
    public AudioClip wing;
    public AudioClip point;
    private int _highScore;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("highScore"))
        {
            PlayerPrefs.SetInt("highScore", 0);
        }

        _highScore = PlayerPrefs.GetInt("highScore");
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    private void ShowLoseUI()
    {
        loseUI.SetActive(true);
    }

    public void RepeatGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void playHit()
    {
        audioSource.PlayOneShot(hit);
    }
    public void playDie()
    {
        audioSource.PlayOneShot(die);
    }
    public void playWing()
    {
        audioSource.PlayOneShot(wing);
    }
    public void playPoint()
    {
        audioSource.PlayOneShot(point);
    }
    public void OnGameOver()
    {
        playHit();
        playDie();
        if (_highScore < points)
        {
            PlayerPrefs.SetInt("highScore", points);
        }

        _highScore = PlayerPrefs.GetInt("highScore");
        highScoreText.text = _highScore.ToString();

        ShowLoseUI();
        Time.timeScale = 0;
    }

    public void UpdateScore()
    {
        points++;
        scoreText.text = points.ToString();
    }
}