using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class KeyboardControl : MonoBehaviour
{

    [SerializeField]
    private IntGameEvent EventToSend;
    [SerializeField]
    private IntGameEvent SelectEvent;

    private bool PressedRecently = false;

    void Update()
    {
        if (!PressedRecently)
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                EventToSend.Raise(4);PressedRecently = true; StartCoroutine(refreshPressRoutine());
                SelectEvent?.Raise(4);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                EventToSend.Raise(5); PressedRecently = true; StartCoroutine(refreshPressRoutine());

                SelectEvent?.Raise(5);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {

                SelectEvent?.Raise(0);
                EventToSend.Raise(0); PressedRecently = true; StartCoroutine(refreshPressRoutine());
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {

                SelectEvent?.Raise(3);
                EventToSend.Raise(3); PressedRecently = true; StartCoroutine(refreshPressRoutine());
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {

                SelectEvent?.Raise(2);
                EventToSend.Raise(2); PressedRecently = true; StartCoroutine(refreshPressRoutine());
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {

                SelectEvent?.Raise(1);
                EventToSend.Raise(1); PressedRecently = true; StartCoroutine(refreshPressRoutine());
            } 

        }
    }

    IEnumerator refreshPressRoutine()
    {
        yield return new WaitForSeconds(0.15f);
        PressedRecently = false;
    }
}
