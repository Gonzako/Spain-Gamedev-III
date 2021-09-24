using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class KeyboardControl : MonoBehaviour
{

    [SerializeField]
    private IntGameEvent EventToSend;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            EventToSend.Raise(4);
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            EventToSend.Raise(5);
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            EventToSend.Raise(0);
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            EventToSend.Raise(3);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            EventToSend.Raise(2);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            EventToSend.Raise(1);
        }
    }
}
