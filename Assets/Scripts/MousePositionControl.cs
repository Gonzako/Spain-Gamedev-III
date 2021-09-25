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

    [SerializeField]
    private float linearDifferenceXY;


    void Awake()
    {
        CheckScreenSize();
        InvokeRepeating("CheckScreenSize", 2f, 5f);
    }

    void CheckScreenSize()
    {
        ScreenCenter = new Vector2(Screen.width/2, Screen.height/2);
    }

    void Update()
    {
        MouseDifference = (Vector2)Input.mousePosition - ScreenCenter;

        if(MouseDifference.y > 0)
        {
            if(Mathf.Abs(MouseDifference.x/linearDifferenceXY) > MouseDifference.y)
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
            if(Mathf.Abs(MouseDifference.x/linearDifferenceXY) > Mathf.Abs(MouseDifference.y))
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
