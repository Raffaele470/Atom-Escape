using UnityEngine;
using UnityEngine.UI;

public class ButtonSelectLevelMenu : MonoBehaviour
{

    
    int isCompleted;

    private Button button;


    public GameObject previousLevel;
    int previousLevelIsCompleted;

    GameObject xSign;


    void Start()
    {

        button = GetComponent<Button>();

        var colors = button.colors;

        colors.normalColor = new Color(1f, 0.92f, 0.016f, 1f);

        previousLevelIsCompleted = PlayerPrefs.GetInt("LevelCompleted" + previousLevel.name);

        isCompleted = PlayerPrefs.GetInt("LevelCompleted" + gameObject.name);

        if(gameObject.name != "1")
        {
            xSign = transform.Find("X").gameObject;
        }

        if (isCompleted == 1)
        {
            button.colors = colors;
        }

        if (checkCompletedPreviousLevel() && gameObject.name!="1")
        {
            button.interactable = true;
            xSign.SetActive(false);
        }

        else if (!checkCompletedPreviousLevel() && gameObject.name != "1")
        {
            button.interactable = false;
            xSign.SetActive(true);
        }

    }

    public bool checkCompletedPreviousLevel()
    {
        bool completed = false;

        if (previousLevelIsCompleted == 1)
        {
            completed = true;
        }
        return completed;
    }

}

