using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text counterText, sliderText;

    private int score = 0;

    public int desiredScore;

    public GameObject levelWonPanel;

    public Slider angleSlider;

    // Update is called once per frame
    public void Update()
    {
        sliderText.text = angleSlider.value.ToString();
        if (Input.GetKeyDown(KeyCode.R))
            RestartTheLevel();
    }
    public void Score()
    {
        score += 1;
        counterText.text = "Score : " + score;
        Camera.main.GetComponent<AudioSource>().Play();
        if(score == desiredScore)
        {
            LevelCleared();
        }
    }
    public void LevelCleared()
    {
        levelWonPanel.SetActive(true);
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartTheLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
