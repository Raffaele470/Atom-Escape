using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using TMPro;


public class FinalLevelCollision : MonoBehaviour
{

    [SerializeField]
    private string _colliderScript;

    [SerializeField]
    private UnityEvent _collisionEntered;

    [SerializeField]
    private UnityEvent _collisionExit;

    TimerScoreScript timerScript;
    LevelManager levelScript;

    public GameObject level;

    private void Start()
    {
        timerScript = level.GetComponent<TimerScoreScript>();
        levelScript = level.GetComponent<LevelManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent(_colliderScript))
        {
            _collisionEntered?.Invoke();
        }
    }

    public void ActiveFinalLevelMenu(GameObject finalLevelMenu)
    {       
        finalLevelMenu.SetActive(true);
        levelScript.SetlevelCompleted();
        StartCoroutine(StopTimeWait());
    }

    public void ShowCurrentTime(TextMeshProUGUI currentTime)
    {
        currentTime.text = "Current time: " + timerScript.GetCurrentTime().ToString("#.00");   
    }

    public void ShowBestTime(TextMeshProUGUI bestTime)
    {
        bestTime.text = "Best time: " + timerScript.GetBestTime().ToString("#.00");
    }

    IEnumerator StopTimeWait()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0f; //stop time
    }

}
