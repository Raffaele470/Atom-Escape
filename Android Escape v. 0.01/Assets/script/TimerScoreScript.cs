using TMPro;
using UnityEngine;


public class TimerScoreScript : MonoBehaviour
{
    [SerializeField] int levelNumber;

    float currentTime = 0;
    float bestTime;
    int timeRegistered;
    bool timerActive;

    public TextMeshProUGUI CurrentTimeText;
    public TextMeshProUGUI BestTimeText;
    public TextMeshProUGUI NewRecordText;

    ShowTutorial tutorialIsActive;

    private void Start()
    {
        bestTime = PlayerPrefs.GetFloat("bestTimeScore" + levelNumber);
        timeRegistered = PlayerPrefs.GetInt("timeRegistered" + levelNumber);

        if(levelNumber != 1)
        {
            timerActive = true;
        }

        else if(levelNumber == 1)
        {
            timerActive = false;
            tutorialIsActive = GetComponent<ShowTutorial>();
        }
    }

    void Update()
    {

        if(levelNumber == 1)
        {
            if (tutorialIsActive.tutorialActive)
            {
                timerActive = false;
            }

            else if (!tutorialIsActive.tutorialActive)
            {
                timerActive = true;
            }
        }


        if (levelNumber !=1)
        {
            timerActive = true;
        }


        if (timerActive)
        {
            currentTime += Time.deltaTime;
        }

        CurrentTimeText.text = "Current time: " + currentTime.ToString("#.00");


        if (timeRegistered == 0)
        {
            BestTimeText.text = "No time registered yet";
        }

        if(timeRegistered == 1)
        {
            BestTimeText.text = "Best time registered: " + PlayerPrefs.GetFloat("bestTimeScore" + levelNumber).ToString("#.00");
        }

}


    public void StopTimer()
    {

        timerActive = false;

        CurrentTimeText.gameObject.SetActive(false);

        if (timeRegistered != 1)
        {
            NewRecordText.enabled = true;
            bestTime = currentTime;
            timeRegistered = 1;
            SaveTimeScore();
        }

        else if (timeRegistered == 1)
        {
            if(currentTime < bestTime)
            {
                NewRecordText.enabled = true;
                bestTime = currentTime;
                SaveTimeScore();
            }
        }
    }

    public void SaveTimeScore()
    {
        PlayerPrefs.SetInt("timeRegistered" + levelNumber, timeRegistered);
        PlayerPrefs.SetFloat("bestTimeScore" + levelNumber, bestTime);
        PlayerPrefs.Save();
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }

    public float GetBestTime()
    {
        return PlayerPrefs.GetFloat("bestTimeScore" + levelNumber);
    }

    public int GetLevelNumber()
    {
        return levelNumber;
    }

}
