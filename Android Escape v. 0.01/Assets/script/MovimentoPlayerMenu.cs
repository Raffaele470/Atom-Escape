using System.Collections;
using UnityEngine;

public class MovimentoPlayerMenu : MonoBehaviour
{
    public GameObject player;

    Animator animator;

    Rigidbody2D playerRigidBody;



    public float speed;
    private int direction; //if 1 is right, if -1 is left


    public bool isRunning;





    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        direction = 1;
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(direction, 0, 0) * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)  //when player touch the wall
    {
        if (collision.gameObject.tag == "wall")
        {


            if (direction == -1)
            {
                direction = 1;

                Vector3 currentScale = player.transform.localScale;
                currentScale.x *= -1;
                player.transform.localScale = currentScale;

            }

            else if (direction == 1)
            {
                direction = -1;

                Vector3 currentScale = player.transform.localScale;
                currentScale.x *= -1;
                player.transform.localScale = currentScale;

            }
        }

    }

}
