using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject levelWinPanel;

    public int CurrentLevelIndex;
    public int numOfPassingRings;

    [SerializeField] private TextMeshProUGUI currentLevelText;
    [SerializeField] private TextMeshProUGUI nextLevelText;

    [SerializeField] private Slider ProggressBar;

    private const string currentLevelKey = "CurrentLevelIndex";

    public static GameManager instance = null;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
        CurrentLevelIndex = PlayerPrefs.GetInt(currentLevelKey, 1);
        //currentLevelText.text = CurrentLevelIndex.ToString();
        //nextLevelText.text = (CurrentLevelIndex + 1).ToString();
        LevelText();
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
        numOfPassingRings = 0;
    }

    public void SetProgressBar()
    {
        //int proggress = numOfPassingRings * 100 / FindObjectOfType<HelixManager>().numOfRings;
        int proggress = numOfPassingRings * 100 / HelixManager.instance.numOfRings;
        ProggressBar.value = proggress;
    }
    private void LevelText()
    {
        currentLevelText.text = CurrentLevelIndex.ToString();
        nextLevelText.text = (CurrentLevelIndex + 1).ToString();
    }
    public void LevelWin()
    {
        SetTimeScale(0);
        levelWinPanel.SetActive(true);
    }
    public void GameOver()
    {
        SetTimeScale(0);
        gameOverPanel.SetActive(true);
    }
    public void NextLevel()
    {
        PlayerPrefs.SetInt(currentLevelKey, CurrentLevelIndex + 1);
        SceneManager.LoadScene(0);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
    private void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }
}