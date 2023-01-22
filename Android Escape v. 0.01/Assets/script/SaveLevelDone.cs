using UnityEngine;

public class SaveLevelDone : MonoBehaviour
{

    public int LevelDone;

    LevelManager levelManagerScript;
    int levelNumber;

    TimerScoreScript timeScript;

    private void Update()
    {
        LevelDone = PlayerPrefs.GetInt("LevelCompleted" + levelNumber);
    }

    private void Start()
    {
        timeScript = GetComponent<TimerScoreScript>();
        levelManagerScript = GetComponent<LevelManager>();
        levelNumber = timeScript.GetLevelNumber();
    }

    public void setLevelComplete()
    {
        if (levelManagerScript.levelCompleted == true)
        {
            PlayerPrefs.SetInt("LevelCompleted" + levelNumber, 1);
        }
    }

    public void saveLevelCompleted()
    {
        setLevelComplete();
        PlayerPrefs.Save();
    }

 

}
