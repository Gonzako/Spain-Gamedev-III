using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class KeyboardControl : MonoBehaviour
{

    [SerializeField]
    private IntGameEvent EventToSend;

    private bool PressedRecently = false;

    void Update()
    {
        if (!PressedRecently)
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                EventToSend.Raise(4);PressedRecently = true; StartCoroutine(refreshPressRoutine());
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                EventToSend.Raise(5); PressedRecently = true; StartCoroutine(refreshPressRoutine());
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                EventToSend.Raise(0); PressedRecently = true; StartCoroutine(refreshPressRoutine());
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                EventToSend.Raise(3); PressedRecently = true; StartCoroutine(refreshPressRoutine());
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                EventToSend.Raise(2); PressedRecently = true; StartCoroutine(refreshPressRoutine());
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                EventToSend.Raise(1); PressedRecently = true; StartCoroutine(refreshPressRoutine());
            } 

        }
    }

    IEnumerator refreshPressRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        PressedRecently = false;
    }
}
