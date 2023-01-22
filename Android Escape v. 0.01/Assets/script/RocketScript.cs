using System.Collections;
using UnityEngine;

public class RocketScript : MonoBehaviour
{

    public Rigidbody2D explosion;
    Vector3 addPosition;

    private void Start()
    {
        addPosition = new Vector3(32.3f, 2.0f, 0.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)  //when player touch the wall
    {
        if (collision.gameObject.tag == "player")
        {
            StartCoroutine(ExplosionRocketWaitRoutine());
            Rigidbody2D e = Instantiate(explosion, transform.position + addPosition, transform.rotation);
            Destroy(e.gameObject, 1.3f);
        }


        if (collision.gameObject.tag == "floor")
        {
            StartCoroutine(ExplosionRocketWaitRoutine());
            Rigidbody2D e = Instantiate(explosion, transform.position+addPosition, transform.rotation);
            Destroy(e.gameObject, 1.3f);
        }

    }


    IEnumerator ExplosionRocketWaitRoutine()
    {
        yield return new WaitForSeconds(0.05f);
        Destroy(this.gameObject);
    }

}