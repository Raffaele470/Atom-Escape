using UnityEngine;
using UnityEngine.Events;

public class KeyCollisionDetector : MonoBehaviour
{
    [SerializeField]
    private string _colliderScript;

    [SerializeField]
    private UnityEvent _collisionEntered;

    [SerializeField]
    private UnityEvent _collisionExit;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent(_colliderScript))
        {
            _collisionEntered?.Invoke();
        }
    }


}
