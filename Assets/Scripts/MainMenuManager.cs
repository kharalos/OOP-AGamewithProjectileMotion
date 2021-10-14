using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject levelSelectPanel;
    public Text credit;
    Color newColor;
    private void Start()
    {
        StartCoroutine(ChangeColor());
    }
    private void Update()
    {
        credit.color = Color.Lerp(credit.color, newColor, 2 * Time.deltaTime);
        
    }
    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(.5f);
        newColor = Random.ColorHSV();
        StartCoroutine(ChangeColor());
    }
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void SelectLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }
    public void LevelPanel(bool onOff)
    {
        levelSelectPanel.SetActive(onOff);
    }
    public void Music()
    {
        FindObjectOfType<MusicController>().PlayStopMusic();
    }
}
