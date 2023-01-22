using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelLoaderScript : MonoBehaviour
{


    public Animator transition;
    public float transitionTime;

    public bool transitionOn;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void RestartLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadMenuLevel()
    {
        StartCoroutine(LoadMenu());
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        Time.timeScale = 1f;    //start time
        transition.SetTrigger("start");

        transitionOn = true;

        yield return new WaitForSeconds(transitionTime);

        transitionOn = false;
        SoundDistanceScript.dead = false;
        SceneManager.LoadScene(levelIndex);

    }

    IEnumerator LoadMenu()
    {
        Time.timeScale = 1f;    //start time
        transition.SetTrigger("start");

        transitionOn = true;

        yield return new WaitForSeconds(transitionTime);

        transitionOn = false;

        SceneManager.LoadScene(0);
    }


    public void LoadSpecificLevel(int num)
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + num));
    }

    public void Quit()
    {
        Application.Quit();   
    }

}
