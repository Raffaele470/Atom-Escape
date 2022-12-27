using UnityEngine;

public class BoxScript : MonoBehaviour
{

    public GameObject player;
    Animator playerAnimator;
    Animator boxAnimator;

    Collider2D boxCollider;

    [SerializeField]
    AudioSource boxDestroy;
    void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
        boxAnimator = GetComponent<Animator>();

        boxCollider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)  //when player touch the box  and he's dashing
    {

        if ((collision.gameObject.tag == "player") && playerAnimator.GetBool("dash"))
        {
            boxDestroy.Play();
            boxCollider.enabled = false;
            boxAnimator.SetTrigger("broken");
            Destroy(this.gameObject,2f);
        }
    }
   }
