using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour
{

    [SerializeField]
    private Text livesText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private GameObject pauseMenuUI;

    public static bool GameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Unpause()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    

public void SaveGameButton()
    {
        // 1
        Save save = CreateSaveGameObject();

        // 2
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        // 3
        LivesTracker.livesValue = 9;
        ScoreKeeper.score = 0;
        TimeKeeper.gameTimer = 30;
        GameDataManager.currentPlayerName = "New Player";

        livesText.text = "" + LivesTracker.livesValue;
        scoreText.text = "" + ScoreKeeper.score;
        timerText.text = "" + TimeKeeper.gameTimer;
        nameText.text = "" + GameDataManager.currentPlayerName;
       
        Debug.Log("Game Saved");
        //Unpause();
    }

    public void NewGame()
    {
        LivesTracker.livesValue = 9;
        ScoreKeeper.score = 0;
        TimeKeeper.gameTimer = 30;
        GameDataManager.currentPlayerName = "Player Name";

        livesText.text = "" + LivesTracker.livesValue;
        scoreText.text = "" + ScoreKeeper.score;
        timerText.text = "" + TimeKeeper.gameTimer;
        nameText.text = "" + GameDataManager.currentPlayerName;

        PauseMenu.GameIsPaused = false;
        Debug.Log("New Game");
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();

        save.livesValue = LivesTracker.livesValue;
        save.score = ScoreKeeper.score;
        save.gameTimer = (int)TimeKeeper.gameTimer;
        save.currentPlayerName = GameDataManager.currentPlayerName;

        return save;
    }

    public void AddLives()
    {
        LivesTracker.livesValue++;
        livesText.text = "Lives: " + LivesTracker.livesValue;
    }

    public void AddScore()
    {
        ScoreKeeper.score++;
        scoreText.text = "Score: " + ScoreKeeper.score;
    }

    public void AddTimer()
    {
        TimeKeeper.gameTimer++;
        timerText.text = "Timer: " + TimeKeeper.gameTimer;
    }

    public void AddName()
    {
        nameText.text = "Name: " + GameDataManager.currentPlayerName;
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            livesText.text = "" + save.livesValue;
            scoreText.text = "" + save.score;
            timerText.text = "" + save.gameTimer;
            nameText.text = "" + save.currentPlayerName;

            LivesTracker.livesValue = save.livesValue;
            ScoreKeeper.score = save.score;
            TimeKeeper.gameTimer = save.gameTimer;
            GameDataManager.currentPlayerName = save.currentPlayerName;

            Debug.Log("Game Loaded");

            PauseMenu.GameIsPaused = false;
            Unpause();
        }
        else
        {
            Debug.Log("No game Saved");
        }
    }

    public void SaveAsJSON()
    {
        Save save = CreateSaveGameObject();
        string json = JsonUtility.ToJson(save);

        Debug.Log("Saving as JSON: " + json);
    }
}
