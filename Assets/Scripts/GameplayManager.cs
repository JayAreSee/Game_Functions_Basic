using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public TimeKeeper timeKeeper;
    public Text playerLivesText;
    //public Text playerSizeText;

    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayerLivesUI();
        playerLivesText.text = GameDataManager.playerLives.ToString();

        //UpdatePlayerSizeUI();
       // playerSizeText.text = GameDataManager.playerSize.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeKeeper.isTimerExpired())
        {
            // Load next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void EndGame()
    {
        // Load next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void UpdatePlayerLivesUI()
    {
        switch (GameDataManager.playerLives)
        {
            case 1:
                playerLivesText.text = "1";
                break;
            case 2:
                playerLivesText.text = "2";
                break;
            case 3:
                playerLivesText.text = "3";
                break;
            case 4:
                playerLivesText.text = "4";
                break;
            case 5:
                playerLivesText.text = "5";
                break;
            case 6:
                playerLivesText.text = "6";
                break;
            case 7:
                playerLivesText.text = "7";
                break;
            case 8:
                playerLivesText.text = "8";
                break;
            case 9:
                playerLivesText.text = "9";
                break;
        }
    }
    /*
    public void UpdatePlayerSizeUI()
    {
        switch (GameDataManager.playerSize)
        {
            case 1:
                playerSpeedText.text = "Small";
                break;
            case 2:
                playerSpeedText.text = "Normal";
                break;
            case 3:
                playerSpeedText.text = "Large";
                break;
        }
    }*/
}
