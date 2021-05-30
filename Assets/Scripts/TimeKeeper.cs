using UnityEngine;
using UnityEngine.UI;

public class TimeKeeper : MonoBehaviour
{
    public bool isTimerEnabled = true;
    public static float gameTimer = 60;
    public Text timerText;
 

    // Start is called before the first frame update
    void Start()
    {
        //SetGameTimer();
    }
  
    // Update is called once per frame
    void Update()
    {

        if (isTimerEnabled)
        {
            gameTimer -= Time.deltaTime;
            if (timerText)
                timerText.text = ((int)gameTimer).ToString();
        }
        else
        {
            if (timerText)
                timerText.text = "Unlimited";
        }

        if (gameTimer <= 0)
        {
            timerText.color = Color.red;
        }
    }

    public bool isTimerExpired()
    {
        return isTimerEnabled && gameTimer < 0;
    }
   
    
    

    private void SetGameTimer()
    {
       


    }


    /*
    private void SetGameTimer()
    {
        switch (GameDataManager.gameTimer)
        {
            case 1:
                gameTimer = 15;
                break;
            case 2:
                gameTimer = 30;
                break;
            case 3:
                gameTimer = 60;
                break;
            case 4:
                isTimerEnabled = false;
                break;
        }
    }*/
}
