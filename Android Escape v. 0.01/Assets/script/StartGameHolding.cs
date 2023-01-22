using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StartGameHolding : MonoBehaviour
{

    float timeHolded;
    float maxTime = 100;
    bool holded;

    public Slider holdSlider;

    [SerializeField]
    private UnityEvent _ArrivedAtMax;

    public bool otherMenuIsOpened;
    void Start()
    {
        otherMenuIsOpened = false;
        holded = false;
        timeHolded = 0;
        holdSlider.value = 0;
    }

    
    void Update()
    {
        /* Old system
        if (Input.GetKey(KeyCode.Space) && timeHolded <= maxTime && !holded){
            timeHolded += 50f * Time.deltaTime;
            holdSlider.value = timeHolded/100;
        }

        if(!(Input.GetKey(KeyCode.Space)) && timeHolded >= 0 && !holded)
        {
            timeHolded -= 50f * Time.deltaTime;
            holdSlider.value = timeHolded / 100;
            
        }
        */

        //new system
        if (Input.anyKey && timeHolded <= maxTime && !holded && !otherMenuIsOpened)
        {
            timeHolded += 50f * Time.deltaTime;
            holdSlider.value = timeHolded / 100;
        }

        if (!(Input.anyKey) && timeHolded >= 0 && !holded)
        {
            timeHolded -= 50f * Time.deltaTime;
            holdSlider.value = timeHolded / 100;

        }

        if (timeHolded >= maxTime)
        {
            holded = true;
            _ArrivedAtMax?.Invoke();
        }
    }


    public void SetTrueOtherMenuOpened()
    {
        otherMenuIsOpened = true;
    }

    public void SetFalseOtherMenuOpened()
    {
        otherMenuIsOpened = false;
    }

}
