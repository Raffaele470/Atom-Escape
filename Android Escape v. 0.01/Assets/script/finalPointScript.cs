using UnityEngine;
using UnityEngine.Events;

public class finalPointScript : MonoBehaviour
{
    [SerializeField]
    private string _colliderScript;

    [SerializeField]
    private UnityEvent _collisionEntered;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent(_colliderScript))
        {
            _collisionEntered?.Invoke();
        }
    }


}
