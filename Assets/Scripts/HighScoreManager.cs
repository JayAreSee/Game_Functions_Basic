using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    //public Text highScoreNames;
    //public Text highScoreValues;
    public Text highScoresText;
    //public InputField playerName;

    // Start is called before the first frame update
    void Start()
    {
        GameDataManager.LoadHighScores();
        ShowHighScores();
    }

    private void ShowHighScores()
    {
        if (GameDataManager.highScores.Count > 0)
        {
            for (int entry = 1; entry <= GameDataManager.highScores.Count; entry++)
            {
                string playerName = GameDataManager.highScores[entry - 1].Key;
                string playerScore = GameDataManager.highScores[entry - 1].Value.ToString();

                if (entry == 1)
                {
                   // if (highScoreNames)
                        //highScoreNames.text = playerName;

                   // if (highScoreValues)
                        //highScoreValues.text = playerScore;

                    if (highScoresText)
                        highScoresText.text = playerName + " - " + playerScore;
                }
                else
                {
                   // if (highScoreNames)
                        //highScoreNames.text += '\n' + playerName;

                    //if (highScoreValues)
                       // highScoreValues.text += '\n' + playerScore;

                    if (highScoresText)
                        highScoresText.text += '\n' + playerName + " - " + playerScore;
                }
            }
        }
        else
        {
            //if (highScoreNames)
            //    highScoreNames.text = "---";

            //if (highScoreValues)
            //    highScoreValues.text = "---";

            if (highScoresText)
            highScoresText.text = "Player Name - 00";
        }
    }

    public static void ClearHighScores()
    {

        GameDataManager.ClearHighScores();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("CLEAR HIGHSCORES");

    }

    

}
