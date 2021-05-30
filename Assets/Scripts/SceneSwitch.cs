using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

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
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void GoToScene0()
    {
        Debug.Log("Loading Menu");
        SceneManager.LoadScene(0);
    }

    public void GoToScene1()
    {
        Debug.Log("Loading Main");
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("CurrentScore", 0);
        //Score.CurrentScore = 0;
        Unpause();
    }

    public void GoToScene2()
    {
        Debug.Log("Loading End");
        SceneManager.LoadScene(2);
    }

    public void RestartScene()
    {
        Debug.Log("Restarting the game...");
        PlayerPrefs.DeleteKey("name");
        PlayerPrefs.SetString("name", "");
        PlayerPrefs.SetInt("count", 0);
       //Score.CurrentScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Unpause();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        PlayerPrefs.SetString("name", "");
        PlayerPrefs.SetFloat("livesValue", 9);
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }


}
