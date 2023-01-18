using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class KeyBinding : MonoBehaviour
{

    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public TextMeshPro Key;

    void Start()
    {
        keys.Add("Jump", KeyCode.Space);
    }


    void Update()
    {
        
    }
}
