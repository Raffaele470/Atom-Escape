using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public bool stopped;
    public GameObject pauseMenu;

    LevelManager levelScript;
    public GameObject level;
    public GameObject player;

    public GameObject levelLoader;
    LevelLoaderScript levelLoadScript;

    PlayerHealthManager playerHealthScript;
    movimento movementScript;

    [SerializeField]
    private GameObject ui;

    GameObject optionMenu;
    GameObject quitMenu;
    public bool SecondMenuIsActive;

    private void Start()
    {
        levelScript = level.GetComponent<LevelManager>();
        levelLoadScript = levelLoader.GetComponent<LevelLoaderScript>();
        playerHealthScript = player.GetComponent<PlayerHealthManager>();
        movementScript = player.GetComponent<movimento>();

        SecondMenuIsActive = false;

    }

    [SerializeField]
    private AudioSource music;

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && levelScript.GetlevelCompleted() == false && levelLoadScript.transitionOn == false && playerHealthScript.deathBodyIsSpawned == false)    //if "P" or "ESC" key pressed, stop/resume the game
        {
            if (stopped && !SecondMenuIsActive)
            {
                resume();
            }

            else if (!stopped)
            {
                stop();
            }
        }

        if(levelLoadScript.transitionOn == true)
        {
            pauseMenu.SetActive(false);
        }

        optionMenu = ui.transform.Find("OptionsMenu").gameObject;
        quitMenu = ui.transform.Find("ConfirmQuit").gameObject;

        if(optionMenu.activeInHierarchy || quitMenu.activeInHierarchy)
        {
            SecondMenuIsActive = true;
        }

        else if (!optionMenu.activeInHierarchy & !quitMenu.activeInHierarchy)
        {
            SecondMenuIsActive = false;
        }

    }


    public void resume()
    {
        Time.timeScale = 1f;    //start time
        stopped = false;
        pauseMenu.SetActive(false);
        music.mute = false;
        movementScript.isOnPause = false;
    }

    public void stop()
    {
        Time.timeScale = 0f; //fermo il tempo
        stopped = true;
        pauseMenu.SetActive(true);
        music.mute = true;
        movementScript.isOnPause = true;
    }
}
