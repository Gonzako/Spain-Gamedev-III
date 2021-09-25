using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class MousePositionControl : MonoBehaviour
{

    [SerializeField]
    private IntGameEvent ClickEvent;

    [SerializeField]
    private IntGameEvent MoveEvent;


    private int direction;
    private int previous_direction;

    private Vector2 ScreenCenter;
    private Vector2 MouseDifference;

    void Awake()
    {
        ScreenCenter = new Vector2(Screen.width/2, Screen.height/2);
    }

    void CheckScreenSize()
    {

    }

    void Update()
    {
        MouseDifference = (Vector2)Input.mousePosition - ScreenCenter;
        //Debug.Log(MouseDifference);

        if(MouseDifference.y > 0)
        {
            if(Mathf.Abs(MouseDifference.x/2) > MouseDifference.y)
            {
                if(MouseDifference.x > 0)
                {
                    direction = 0;
                }
                else
                {
                    direction = 4;
                }
            }
            else
            {
                direction = 5;
            }
        }
        else if(MouseDifference.y < 0)
        {
            if(Mathf.Abs(MouseDifference.x/2) > Mathf.Abs(MouseDifference.y))
            {
                if(MouseDifference.x > 0)
                {
                    direction = 1;
                }
                else
                {
                    direction = 3;
                }
            }
            else
            {
                direction = 2;
            }
        }

        if(previous_direction != direction)
        {
            MoveEvent.Raise(direction);
            previous_direction = direction;
        }
    }
}
