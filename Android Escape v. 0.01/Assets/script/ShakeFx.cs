using System.Collections;
using UnityEngine;

public class ShakeFx : MonoBehaviour
{
    public bool startShake = false;
    public float duration = 1f;
    Vector3 startPosition;
    public AnimationCurve curve;

    private void Update()
    {
        if (startShake)
        {
            startShake = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while(elapsedTime < duration)
        {
            startPosition = transform.position;
            elapsedTime += Time.deltaTime;
            float strenght = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strenght;
            yield return null;
        }

        transform.position = startPosition;

    }

    public void activeShaking()
    {
        startShake = true;
    }

}
