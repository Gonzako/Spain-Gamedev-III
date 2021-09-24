using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;


public class MouseControl : MonoBehaviour
{

    #region PrivateFields

    [SerializeField]
    private IntGameEvent ClickEvent; // Este Evento solo se activa con Click, y es el que en verdad interactua con el juego.

    [SerializeField]
    private IntGameEvent MoveEvent; // Este Evento solo sirve para la animación de las flechas indicando el movimiento del mouse.
    
    private int direction;
    private int previous_direction;

    private float X_mouse;
    private float Y_mouse;


    [Space]
    [Header("Mouse Movement Dead Zone")]
    [SerializeField, Range(0,4f)]
    private float X_DeadZone;
    [SerializeField, Range(0,4f)]
    private float Y_DeadZone;

    public bool PressedRecently { get; private set; }

    #endregion


    void Update()
    {
        X_mouse = Input.GetAxisRaw("Mouse X");
        Y_mouse = Input.GetAxisRaw("Mouse Y");
        

        if(Y_mouse > Y_DeadZone)
        {
            if(X_mouse > X_DeadZone)
            {
                direction = 0;
            }
            else if(X_mouse < -X_DeadZone)
            {
                direction = 4;
            }
            else
            {
                direction = 5;
            }
        }
        else if(Y_mouse < -Y_DeadZone)
        {
            if(X_mouse > X_DeadZone)
            {
                direction = 1;
            }
            else if(X_mouse < -X_DeadZone)
            {
                direction = 3;
            }
            else
            {
                direction = 2;
            }
        }
        else // El eje Y no cambia
        {
            if(X_mouse > X_DeadZone)
            {
                if(direction == 4 || direction == 5)
                {
                    direction = 0;
                }
                else if(direction == 3 || direction == 2)
                {
                    direction = 1;
                }
            }
            else if(X_mouse < -X_DeadZone)
            {
                if(direction == 5 || direction == 0)
                {
                    direction = 4;
                }
                else if(direction == 2 || direction == 1)
                {
                    direction = 3;
                }
            }
        }


        if(previous_direction != direction)
        {
            MoveEvent.Raise(direction);
            previous_direction = direction;
        }

        if(Input.GetMouseButtonDown(0) && !PressedRecently)
        {
            ClickEvent.Raise(direction);
            PressedRecently = true;
            StartCoroutine(refreshPressRoutine());
        }

        Debug.Log(X_mouse + " " + Y_mouse);
    }
    IEnumerator refreshPressRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        PressedRecently = false;
    }
}
