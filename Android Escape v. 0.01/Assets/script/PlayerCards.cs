using UnityEngine;

public class PlayerCards : MonoBehaviour
{

    public int cardsCounter;

    [SerializeField]
    private AudioSource keySound;

    void Start()
    {
        cardsCounter = 0;
    }

    public void updateCounter()
    {
        keySound.Play();
        cardsCounter = cardsCounter + 1;
    }

    
}
