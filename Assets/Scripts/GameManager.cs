using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Score elements")]
    public int score;
    public Text scoreText;
    public int highscore;
    public Text highscoreText;
    [Header("Game over elements")]
    public GameObject gameOverPanel;
    [Header("Sound")]
    public AudioClip[] sliceSounds;
    public AudioClip[] bombSounds;
    public AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GetHighscore();
    }

    public void GetHighscore ()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = "Best: " + highscore.ToString();
    }



    public void IncreaseScore(int addedPoints)
    {
        score += addedPoints;
        scoreText.text = score.ToString();

        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscoreText.text = "Best: " + score.ToString();
            
        }

    }

    public void OnBombHit()
    {
        Debug.Log("Bomb hit");
        gameOverPanel.SetActive(true);
        PlayBombSound();




    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void PlayRandomeSliceSound()
    {
        AudioClip randomeSound = sliceSounds[Random.Range(0, sliceSounds.Length)];
        audioSource.PlayOneShot(randomeSound);
    }

    public void PlayBombSound()
    {
        AudioClip randomeBombSound = bombSounds[Random.Range(0, bombSounds.Length)];
        audioSource.PlayOneShot(randomeBombSound);
    }
}
