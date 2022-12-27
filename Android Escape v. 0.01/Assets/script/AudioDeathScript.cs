using UnityEngine;

public class AudioDeathScript : MonoBehaviour
{

    public AudioSource deathSound;
    GameObject player;
    public bool isLive;
    public bool hasPlayed;

    private void Start()
    {
        hasPlayed = false;
        player = GameObject.Find("Player").gameObject;
        isLive = true;
    }

    void Update()
    {
        if (!player.activeInHierarchy) {
            isLive = false;
        }

        if (isLive == false && hasPlayed==false)
        {
            deathSound.Play();
            hasPlayed = true;
        }
    }
}
