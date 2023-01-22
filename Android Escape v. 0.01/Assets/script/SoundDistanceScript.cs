using UnityEngine;

public class SoundDistanceScript : MonoBehaviour
{

    [SerializeField]
    private AudioSource sound;

    GameObject player;

    float playerPositionX;
    float soundPositionX;

    public static bool dead = false;
    float dist;

    private void Start()
    {
        if (!dead)
        {
            player = GameObject.Find("Player").gameObject;
        }
    }



    void Update()
    {
        soundPositionX = transform.position.x;

        if (!dead)
        {

            if (player.activeSelf)
            {
                dead = false;
                playerPositionX = player.transform.position.x;
                if (soundPositionX > playerPositionX)
                {
                    dist = Mathf.Abs(soundPositionX - 32f - playerPositionX);
                }
                else if (soundPositionX <= playerPositionX)
                {
                    dist = Mathf.Abs(playerPositionX - soundPositionX + 32f);
                }
            }

            if (!player.activeSelf)
            {
                dead = true;
                playerPositionX = 0;
                dist = 99999;
            }

            if (dist < 30)
            {
                sound.mute = false;
            }

            else
            {
                sound.mute = true;
            }
        }

    }
}