using System.Collections;
using UnityEngine;

public class PlayerAfterDeath : MonoBehaviour
{
    Rigidbody2D playerdDead;
    public float force;

    private void Start()
    {
        playerdDead = GetComponent<Rigidbody2D>();
        playerdDead.AddForce(transform.up * force, ForceMode2D.Impulse);

    }
}
