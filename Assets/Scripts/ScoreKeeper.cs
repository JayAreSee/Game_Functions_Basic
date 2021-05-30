using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    static public int score = 0;
    public Text ScoreText;

    public void IncreaseScore() // clicking on + button increases score
    {
        score += 1;
        ScoreText.text = score.ToString();
        Debug.Log("Score Increased to: " + score);
    }

    public void DecreaseScore() // clicking on - button decreases score
    {
        score -= 1;
        ScoreText.text = score.ToString();
        Debug.Log("Score Decreased to: " + score);
    }
 
}
