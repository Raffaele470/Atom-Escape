using UnityEngine;

public class ShowTutorial : MonoBehaviour
{

    public bool tutorialActive;
    public GameObject tutorialWindow;

    public GameObject player;
    movimento movimentoScript;

    float currentSpeed;


    private void Start()
    {
        movimentoScript = player.GetComponent<movimento>();
        tutorialActive = true;
        currentSpeed = movimentoScript.speed;
    }

    private void Update()
    {
        if(tutorialActive == false)
        {
            movimentoScript.speed = currentSpeed;
            movimentoScript.stopped = false;
        }

        if (tutorialActive == true)
        {
            movimentoScript.speed = 0;
            movimentoScript.stopped = true;
        }

    }

    public void setFalseTutorial()
    {
        tutorialActive = false;
    }


}
