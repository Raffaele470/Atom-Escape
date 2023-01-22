using UnityEngine;
using UnityEngine.UI;
public class SelectDifficulty : MonoBehaviour
{

    public Toggle easyButton;
    public Toggle normalButton;
    public Toggle hardButton;

    public GameObject checkmarkEasy;
    public GameObject checkmarkNormal;
    public GameObject checkmarkHard;

    public int difficulty;

    private void Start()
    {
        
        if(PlayerPrefs.GetInt("difficulty") != 1 && PlayerPrefs.GetInt("difficulty") != 2 && PlayerPrefs.GetInt("difficulty") != 3)
            {
                difficulty = 2; //setto la difficoltà per default a 2
                PlayerPrefs.SetInt("difficulty", difficulty);
        }
        else //altrimenti se è stata già settata la vado a recuperare
        {
            difficulty = PlayerPrefs.GetInt("difficulty");
        }

        if (difficulty == 1)
        {
            easyButton.isOn = true;
            checkmarkEasy.SetActive(true);

            normalButton.isOn = false;
            checkmarkNormal.SetActive(false);

            hardButton.isOn = false;
            checkmarkHard.SetActive(false);

            difficulty = 1;
        }

        else if (difficulty == 2)
        {

            normalButton.isOn = true;
            checkmarkNormal.SetActive(true);

            easyButton.isOn = false;
            checkmarkEasy.SetActive(false);

            hardButton.isOn = false;
            checkmarkHard.SetActive(false);

            difficulty = 2;
        }

        else if(difficulty == 3)
        {

            hardButton.isOn = true;
            checkmarkHard.SetActive(true);

            easyButton.isOn = false;
            checkmarkEasy.SetActive(false);

            normalButton.isOn = false;
            checkmarkNormal.SetActive(false);

            difficulty = 3;
        }

        easyButton.onValueChanged.AddListener(EasyButtonValueChanged);
        normalButton.onValueChanged.AddListener(NormalButtonValueChanged);
        hardButton.onValueChanged.AddListener(HardButtonValueChanged);

    }

    private void EasyButtonValueChanged(bool isOn)
    {
        if (isOn)
        {
            normalButton.isOn = false;
            hardButton.isOn = false;
            checkmarkEasy.SetActive(true);
            checkmarkNormal.SetActive(false);
            checkmarkHard.SetActive(false);

            difficulty = 1;

        }
        else if (!easyButton.isOn && !normalButton.isOn && !hardButton.isOn)
        {
            easyButton.isOn = true;
        }

    }

    private void NormalButtonValueChanged(bool isOn)
    {
        if (isOn)
        {
            easyButton.isOn = false;
            hardButton.isOn = false;
            checkmarkEasy.SetActive(false);
            checkmarkNormal.SetActive(true);
            checkmarkHard.SetActive(false);

            difficulty = 2;

        }
        else if (!easyButton.isOn && !normalButton.isOn && !hardButton.isOn)
        {
            normalButton.isOn = true;
        }
    }

    private void HardButtonValueChanged(bool isOn)
    {
        if (isOn)
        {
            easyButton.isOn = false;
            normalButton.isOn = false;
            checkmarkEasy.SetActive(false);
            checkmarkNormal.SetActive(false);
            checkmarkHard.SetActive(true);

            difficulty = 3;

        }
        else if (!easyButton.isOn && !normalButton.isOn && !hardButton.isOn)
        {
            hardButton.isOn = true;
        }
    }

    public void SaveDifficulty()
    {
        PlayerPrefs.SetInt("difficulty", difficulty);
    }

}



