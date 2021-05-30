using UnityEngine;
using UnityEngine.UI;

public class LivesTracker : MonoBehaviour
{
    public static int livesValue = 9;
    public Text LivesRemaining;

    public Dropdown ValueOfDropdown;
    public Text ValueOfSlider;

    public void DecreaseLives()
    {
        livesValue -= 1;
        LivesRemaining.text = livesValue.ToString();
        Debug.Log("Lives now Decreased to: " + livesValue);
    }
    public void IncreaseLives()
    {
        livesValue += 1;
        LivesRemaining.text = livesValue.ToString();
        Debug.Log("Lives now Increased to: " + livesValue);
    }

    
}
