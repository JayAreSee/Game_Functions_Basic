using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    public Toggle useUserPrefs;
    //public Dropdown playerSizeDropdown;
    public Slider TimerSlider;
    public Text ValueOfSlider;
    public Dropdown gameLivesDropdown;
    public InputField playerName;
    internal static float gameTimer;
    

    // Start is called before the first frame update
    void Start()
    {
        GameDataManager.LoadGameOptions();
        UpdateUserPrefsUI();

    }


    public void toggleUserPrefs(bool value)
    {
        //playerSpeedSlider.interactable = value;
        gameLivesDropdown.interactable = value;
        TimerSlider.interactable = value;
        GameDataManager.useUserPrefs = value;
        GameDataManager.SaveGameOptions();

        if (!value)
        {
            GameDataManager.LoadDefaultOptions();
        }
    }

    public void UserPrefs(bool value)
     {
         TimerSlider.interactable = value;
         //playerSizeDropdown.interactable = value;
         gameLivesDropdown.interactable = value;
         GameDataManager.useUserPrefs = value;
         GameDataManager.SaveGameOptions();

         if (!value)
         {
             GameDataManager.LoadDefaultOptions();
         }
     }
    
    public void SliderTimer()
    {
        TimeKeeper.gameTimer = (int)TimerSlider.value;
        Debug.Log("Game Timer Set To: " + TimerSlider.value);

        ValueOfSlider.text = TimerSlider.value.ToString("f2");
        GameDataManager.SaveGameOptions();
    }

    /*public void changePlayerSize()
    {
        GameDataManager.playerSize = playerSizeDropdown.value + 1;
        GameDataManager.SaveGameOptions();
    }*/

    public void ChangeGameLives()
    {
        LivesTracker.livesValue = gameLivesDropdown.value + 1;
        GameDataManager.SaveGameOptions();
        Debug.Log("Player Lives Set To: " + gameLivesDropdown.value);
    }

    private void UpdateUserPrefsUI()
    {
        useUserPrefs.isOn = GameDataManager.useUserPrefs;
        //playerSizeDropdown.value = GameDataManager.playerSize - 1;
        TimerSlider.value = GameDataManager.gameTimer;
        gameLivesDropdown.value = GameDataManager.playerLives - 1;
       
    }

    public void PlayGame()
    {

            //if (!string.IsNullOrWhiteSpace(playerName.text))
            //{
                GameDataManager.currentPlayerName = playerName.text;

                // Load next scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //}
        }
    
}

