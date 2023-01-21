using UnityEngine;

public class DifficultyGameplayMode : MonoBehaviour
{

    public int difficulty;
    GameObject Lasers;
    GameObject Thorns;
    GameObject Player;

    private void Awake()
    {
        difficulty = PlayerPrefs.GetInt("difficulty");

        if (difficulty == 1) // se easy disattiviamo i laser e i thorns
        {
            Lasers = transform.Find("Lasers").gameObject;
            Lasers.SetActive(false);

            Thorns = transform.Find("Thorns").gameObject;
            Thorns.SetActive(false);

        }

        else if (difficulty == 2) // se normal reimposta tutto
        {
            Lasers = transform.Find("Lasers").gameObject;
            Lasers.SetActive(true);

            Thorns = transform.Find("Thorns").gameObject;
            Thorns.SetActive(true);
        }

        else if (difficulty == 3) // se hard aumentiamo la velocità del giocatore e riduciamo la vita
        {
            Player = transform.Find("Player").gameObject;
            Player.GetComponent<movimento>().speed += 2f;

            Player.GetComponent<PlayerHealthManager>().life -= 1;

        }

    }

}
