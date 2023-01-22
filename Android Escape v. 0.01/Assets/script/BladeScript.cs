using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeScript : MonoBehaviour
{

    public GameObject player;

    Collider2D bladeCollider;
    Collider2D playerCollider;

    void Start()
    {
        bladeCollider = transform.GetComponent<Collider2D>();
        playerCollider = player.GetComponent<Collider2D>();
    }

     private void OnCollisionEnter2D(Collision2D collision)  //when player touch the blade
    {



        if (collision.gameObject.tag == "player")
        {
            Physics2D.IgnoreCollision(playerCollider, bladeCollider);
            StartCoroutine(LaserDamageWaitRoutine());
        }

        IEnumerator LaserDamageWaitRoutine()
        {
            yield return new WaitForSeconds(3f);
            Physics2D.IgnoreCollision(playerCollider, bladeCollider, false);
        }



    }
}
