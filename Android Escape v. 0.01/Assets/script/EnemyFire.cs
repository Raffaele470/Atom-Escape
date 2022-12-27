using System.Collections;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{

    public Rigidbody2D rocket;
    public float speed = 4;

    bool dropped;


    private void Start()
    {
        dropped = false;
    }

    void Update()
    {
        if (!dropped)
        {
            Rigidbody2D p = Instantiate(rocket, transform.position, transform.rotation);
            p.velocity = transform.forward * speed;
            dropped = true;
            StartCoroutine(RocketWaitRoutine());
        }

            
    }


    IEnumerator RocketWaitRoutine()
    {

            yield return new WaitForSeconds(1.5f);
            dropped = false;

    }


}
