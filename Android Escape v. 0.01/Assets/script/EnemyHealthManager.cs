using System.Collections;
using UnityEngine;


public class EnemyHealthManager : MonoBehaviour
{

    public Rigidbody2D explosion; 
    Vector3 addPosition;

    public GameObject player;
    Animator playerAnimator;
    Collider2D enemyCollider;
    Collider2D playerCollider;


    void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
        enemyCollider = GetComponent<Collider2D>();
        playerCollider = player.GetComponent<Collider2D>();

        addPosition = new Vector3(32.3f, 2.0f, 0.0f);


    }



    private void OnCollisionEnter2D(Collision2D collision)  //when enemy touch the player
    {

        if ((collision.gameObject.tag == "player") && playerAnimator.GetBool("dash"))
        {
            Rigidbody2D e = Instantiate(explosion, transform.position + addPosition, transform.rotation);
            Destroy(e.gameObject, 1.3f);
            gameObject.SetActive(false);
        }

        if ((collision.gameObject.tag == "player") && !(playerAnimator.GetBool("dash")))
        {
            Physics2D.IgnoreCollision(playerCollider, enemyCollider);
            StartCoroutine(EnemyWaitRoutine());
        }

        IEnumerator EnemyWaitRoutine()
        {
            yield return new WaitForSeconds(3f);
            Physics2D.IgnoreCollision(playerCollider, enemyCollider, false);
        }

   

    }

}
