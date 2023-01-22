using UnityEngine;

public class enemy1Movement : MonoBehaviour
{

    public float speed;
    private int direction; //if 1 is right, if -1 is left



    void Start()
    {
        direction = -1;
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(direction, 0, 0) * speed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)  //when enemy touch the wall
    {
        if (collision.gameObject.tag == "wall")
        {


            if (direction == -1)
            {
                direction = 1;

                Vector3 currentScale = transform.localScale;
                currentScale.x *= -1;
                transform.localScale = currentScale;

            }

            else if (direction == 1)
            {
                direction = -1;

                Vector3 currentScale = transform.localScale;
                currentScale.x *= -1;
                transform.localScale = currentScale;

            }
        }
    }
}
    
