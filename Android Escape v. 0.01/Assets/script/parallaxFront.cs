using UnityEngine;

public class parallaxFront : MonoBehaviour
{

    private float length, startpos, posYStart;
    public GameObject cam;
    public float parallaxEffect;


    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

        posYStart = transform.position.y;
    }


    void Update()
    {



        float temp = (cam.transform.position.x * (1 - parallaxEffect));

        float distance = (cam.transform.position.x * parallaxEffect);



        if (temp > startpos + length)
        {
            startpos += length;
        }
        else if (temp < startpos - length)
        {
            startpos -= length;
        }


    }




}
