using UnityEngine;
using TMPro;
using System.Collections;

public class LevelManager : MonoBehaviour
{

    public GameObject player;

    public GameObject Gate;

    Animator animatorGate;

    public int cardsNeeded;
    public int cardsOwned;

    public TextMeshProUGUI cardsCounterText;

    public bool levelCompleted;

    public GameObject gameOverMenu;
    PlayerHealthManager playerHealthScript;

    [SerializeField]
    private AudioSource finishLvlSound;

    [SerializeField]
    private AudioSource gateOpened;

    public bool openGate;
    public bool hasPlayed;

    private void Start()
    {
        hasPlayed = false;
        animatorGate = Gate.GetComponent<Animator>();
        levelCompleted = false;

        playerHealthScript = player.GetComponent<PlayerHealthManager>();
    }

    void Update()
    {

        cardsOwned = player.GetComponent<PlayerCards>().cardsCounter;

        cardsCounterText.text = cardsOwned.ToString() + " / " + cardsNeeded.ToString();

        if (cardsOwned == cardsNeeded)
        {
            openGate = true;
            animatorGate.SetBool("isOpened", true);
        }

        if (playerHealthScript.isDeath == true)
        {
            StartCoroutine(WaitDeathMenu());
        }

        if (openGate && !hasPlayed)
        {
            hasPlayed = true;
            gateOpened.Play();
            
        }

    }

    public void SetlevelCompleted()
    {
        levelCompleted = true;
        finishLvlSound.Play();
    }

    public bool GetlevelCompleted()
    {
        return levelCompleted;
    }

    IEnumerator WaitDeathMenu()
    {
        yield return new WaitForSeconds(1.5f);
        gameOverMenu.SetActive(true);

    }

}
