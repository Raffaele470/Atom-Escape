using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyBinding : MonoBehaviour
{

    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public TextMeshProUGUI jump;

    private GameObject currentKey;

    void Start()
    {
        keys.Add("Jump", KeyCode.Space);

        jump.text = keys["Jump"].ToString();
  

    }


    void Update()
    {
        if (Input.GetKeyDown(keys["Jump"]))
        {
            Debug.Log("jump");
        }
    }

    private void OnGUI()
    {
        if(currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = e.keyCode.ToString();
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;

    }

}
