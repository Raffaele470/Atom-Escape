using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{

    public GameObject player;
    public float height;


    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, height, transform.position.z);
    }
}
