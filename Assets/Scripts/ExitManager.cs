using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitManager : MonoBehaviour
{
    public Text currentGameStatsText;
    // Start is called before the first frame update
    void Start()
    {
        if (ScoreKeeper.score > 0)
        {
            GameDataManager.highScores.Add(new KeyValuePair<string, int>(GameDataManager.currentPlayerName, ScoreKeeper.score));
            GameDataManager.SaveHighScores();
        }
        currentGameStatsText.text = GameDataManager.currentPlayerName;
        currentGameStatsText.text += "\nScore: " + ScoreKeeper.score;
        currentGameStatsText.text += "\nLives Left: " + LivesTracker.livesValue;
;
    }

 
    public void ReplayGame()
    {
        // Load first scene - Intro
        //SceneManager.LoadScene(0);

        //PlayerPrefs.DeleteKey("name");
        //PlayerPrefs.SetString("name", "");
        PlayerPrefs.DeleteKey("gameTimer");
        PlayerPrefs.SetInt("count", 0);
        ScoreKeeper.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);


        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();

        Debug.Log("Quitting the game...");
        PlayerPrefs.SetString("name", "");
        PlayerPrefs.SetFloat("livesValue", 9);
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();

    }
}
