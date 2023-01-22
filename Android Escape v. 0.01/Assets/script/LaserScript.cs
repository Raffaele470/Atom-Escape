using System.Collections;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public GameObject laser;
    public GameObject player;

    bool active;

    Collider2D laserCollider;
    Collider2D playerCollider;

    public ParticleSystem laserFx;

    private void Start()
    {

        laserCollider = transform.GetComponent<Collider2D>();
        playerCollider = player.GetComponent<Collider2D>();
        active = false;
    }

    void Update()
    {
            if(!active)
        {
            active = true;
            laser.SetActive(true);
            laserFx.gameObject.SetActive(false);
            laserCollider.enabled = true;
            StartCoroutine(LaserWaitRoutine());
        }
           
    }


    IEnumerator LaserWaitRoutine()
    {
        yield return new WaitForSeconds(4f);
        laser.SetActive(false);
        laserFx.gameObject.SetActive(true);
        laserCollider.enabled = false;
        yield return new WaitForSeconds(4f);
        active = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)  //when player touch the laser
    {



        if (collision.gameObject.tag == "player")
        {
            Physics2D.IgnoreCollision(playerCollider, laserCollider);
            StartCoroutine(LaserDamageWaitRoutine());
        }

        IEnumerator LaserDamageWaitRoutine()
        {
            yield return new WaitForSeconds(3f);
            Physics2D.IgnoreCollision(playerCollider, laserCollider, false);
        }



    }
}
